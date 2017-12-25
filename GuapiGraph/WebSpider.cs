using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class WebSpider
    {
        //主页面
        private const string url = "https://www.nowcoder.com/recommend";
        //获取职位列表 ".../list?page=1&address=北京"
        private const string jobListUrl = "https://www.nowcoder.com/recommend-intern/list?";
        //获取工作详情 ".../70?jobId=1059"
        private const string jobDetailUrl = "https://www.nowcoder.com/recommend-intern/";

        //所有的地址
        private string[] addresses;
        //所有的岗位
        private List<JobInfo> jobList = new List<JobInfo>();

        public WebSpider()
        {
            ThreadPool.SetMaxThreads(50, 5000);
            ThreadPool.SetMinThreads(10, 3000);
        }

        //获取结果
        public List<JobInfo> GetJobList()
        {
            return jobList;
        }

        //开始
        public async Task Start()
        {
            await GetAddress();
            await GetDetail();
            Console.WriteLine("web spider end");

        }

        //获取城市地址
        private async Task GetAddress()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Method = "GET";
                //request.Timeout = 2000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.GetResponseStream();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                //处理添加html头
                string html = AddHtmlTag(sr);
                sr.Close();

                //Console.WriteLine("get address html = " + s);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var list = htmlDoc.DocumentNode.SelectNodes("//a[@class='js-address']");

                addresses = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    addresses[i] = list[i].InnerText;
                    Console.WriteLine("get address node = " + addresses[i]);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
            }
        }

        //获取每个地址下的岗位
        private async Task GetDetail()
        {
            ManualResetEvent[] _ManualEvents = new ManualResetEvent[addresses.Count()];
            for (int i = 0; i < addresses.Count(); i++)
            {
                _ManualEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetJobList),
                    new Tuple<string, EventWaitHandle>(addresses[i], _ManualEvents[i]));
            }
            WaitHandle.WaitAll(_ManualEvents);
            //All threads have completed.

            //foreach (var address in addresses)
            //{
            //    ParameterizedThreadStart start = new ParameterizedThreadStart(getJobList);
            //    Thread thread = new Thread(start);
            //    thread.Start(address);
            //}
        }

        //获取每个地址下每一页的岗位
        private void GetJobList(Object param)
        {
            var p = (Tuple<string, EventWaitHandle>)param;

            int page = 1;
            int size = 0;

            do
            {
                //获取json数据
                string json = GetJobPageJson(p.Item1, page);

                //解析json
                JObject o = JObject.Parse(json);

                //获取pagesize
                size = Convert.ToInt32(o["data"]["totalPage"]);
                Console.WriteLine("get page size = " + size);

                //获取joblist
                IList<JToken> list = o["data"]["jobList"].Children().ToList();

                //输出
                //获取jobdetail
                //ThreadPool.QueueUserWorkItem(new WaitCallback(getJobDetail), list);
                //这样会被拉黑
                //ParameterizedThreadStart start = new ParameterizedThreadStart(getJobDetail);
                //Thread thread = new Thread(start);
                //thread.Start(list);

                //获取每一个工作的详情 ".../70?jobId=1059"
                foreach (var item in list)
                {
                    //Console.WriteLine("get job from joblist = " + item.Value<string>("title"));
                    GetJobDetail(item);
                }
            } while (++page <= size);

            p.Item2.Set();
        }

        //获取指定页job的json数据
        private string GetJobPageJson(string address, int page)
        {
            //获取json数据
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jobListUrl + page + "&address=" + address);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.GetResponseStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string json = @sr.ReadToEnd();

            sr.Close();
            response.Close();

            return json;
        }

        //获取职位详情
        private void GetJobDetail(JToken item)
        {
            string companyId = item.Value<string>("internCompanyId");
            string id = item.Value<string>("id");
            //时间戳
            string timeStamp = item.Value<string>("createTime");

            //获取json数据
            //获取工作详情 ".../70?jobId=1059"
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jobDetailUrl + companyId + "?jobId=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.GetResponseStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            //处理添加html头
            string html = AddHtmlTag(sr);
            sr.Close();

            Console.WriteLine("get job detail " + "company id = " + companyId + " id = " + id);
            //Console.WriteLine("get job detail html " + s);

            JobInfo job = FormJobBean(html, timeStamp);

            jobList.Add(job);

            Console.WriteLine(job.ToString());
        }

        //生成JobBean
        private JobInfo FormJobBean(string html, string timeStamp)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //工作名称
            string jobName = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/h2").First().InnerText.Trim();

            //工作职责
            var nodes = htmlDoc.DocumentNode.SelectNodes("//dl[@class='job-duty']");
            string duties = nodes[0].InnerHtml.Trim();
            duties = replaceHtml(duties);
            duties = duties.Substring(4);

            //工作需求
            nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/dl[2]");
            string qualifications;
            qualifications = nodes[0].InnerHtml.Trim();
            qualifications = replaceHtml(qualifications);
            qualifications = qualifications.Substring(4);

            //工作地
            string address = htmlDoc.DocumentNode.SelectNodes("//p[@class='com-lbs']").First().InnerText.Trim();

            //公司名称
            string companyName = htmlDoc.DocumentNode.SelectNodes("//h3[@class='teacher-name']").First().InnerText.Trim();

            //公司简介
            string companyRec = htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[1]").First().InnerText.Trim();

            //公司网址
            //注意：滴滴的有一个没有网址
            var temp = htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[last()]/a");
            string companySite = temp == null ? "" : temp.First().InnerText.Trim();

            JobInfo job = new JobInfo(companyName, address, timeStamp, jobName, duties, qualifications);
            return job;
        }

        //处理添加html头
        private string AddHtmlTag(StreamReader sr)
        {
            string s = @sr.ReadLine();
            s += @sr.ReadLine();
            s += @"<html>";
            s += @sr.ReadToEnd();

            return s;
        }

        //替换没用的html标签
        private string replaceHtml(string html)
        {
            string result = html;

            result = Regex.Replace(html, "<span.*?>", "");
            result = Regex.Replace(html, "</span>", "");

            result = result.Replace("<br>", "");
            result = result.Replace("<p>", "");
            result = result.Replace("</p>", "");
            result = result.Replace("\r", "");
            result = result.Replace("\n", "");
            result = result.Replace(" ", "");
            result = result.Replace("<dt>", "");
            result = result.Replace("</dt>", "");
            result = result.Replace("\"", "");
            result = result.Replace("'", "");
            result = result.Replace(",", "");
            result = result.Replace(";", "");

            return result;
        }
    }
}

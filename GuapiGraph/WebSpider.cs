using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class WebSpider
    {
        //主页面
        private const String url = "https://www.nowcoder.com/recommend";
        //获取职位列表 ".../list?page=1&address=北京"
        private const String jobListUrl = "https://www.nowcoder.com/recommend-intern/list?";
        //获取工作详情 ".../70?jobId=1059"
        private const String jobDetailUrl = "https://www.nowcoder.com/recommend-intern/";

        //所有的地址
        private String[] addresses;
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
                String html = AddHtmlTag(sr);
                sr.Close();

                //Console.WriteLine("get address html = " + s);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                var list = htmlDoc.DocumentNode.SelectNodes("//a[@class='js-address']");

                addresses = new String[list.Count];
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
                String json = GetJobPageJson(p.Item1, page);

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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jobListUrl  + page + "&address=" + address);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.GetResponseStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            String json = @sr.ReadToEnd();

            sr.Close();
            response.Close();

            return json;
        }

        //获取职位详情
        private void GetJobDetail(JToken item)
        {
            String companyId = item.Value<String>("internCompanyId");
            String id = item.Value<String>("id");
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
            String jobName = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/h2").First().InnerText.Trim();

            //工作职责
            //List<String> duties = new List<string>();
            String duties = "";
            var nodes = htmlDoc.DocumentNode.SelectNodes("//dl[@class='job-duty']/dt");
            for (int i = 1; i < nodes.Count; i++)
            {
                //jobDuty.Add(nodes[i].InnerText);
                duties += nodes[i].InnerText.Trim();
            }

            //工作需求
            //List<String> jobRequire = new List<string>();
            String qualifications = "";
            nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/dl[2]");
            for (int i = 1; i < nodes.Count; i++)
            {
                qualifications += nodes[i].InnerText.Trim();
            }

            //工作地
            String address = htmlDoc.DocumentNode.SelectNodes("//p[@class='com-lbs']").First().InnerText.Trim();

            //公司名称
            String companyName = htmlDoc.DocumentNode.SelectNodes("//h3[@class='teacher-name']").First().InnerText.Trim();

            //公司简介
            String companyRec = htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[1]").First().InnerText.Trim();

            //公司网址
            //注意：滴滴的有一个没有网址
            var temp = htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[last()]/a");
            String companySite = temp == null ? "" : temp.First().InnerText.Trim();

            JobInfo job = new JobInfo(companyName, address, timeStamp, jobName, duties, qualifications);
            return job;
        }

        //处理添加html头
        private string AddHtmlTag(StreamReader sr)
        {
            String s = @sr.ReadLine();
            s += @sr.ReadLine();
            s += @"<html>";
            s += @sr.ReadToEnd();

            return s;
        }
    }
}

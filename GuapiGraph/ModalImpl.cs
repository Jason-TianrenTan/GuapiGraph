using GuapiGraph.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class ModalImpl : DataModel
    {
        private static DBUtils db = new DBUtils();

        private static ModalImpl modal = new ModalImpl();

        private ModalImpl()
        {
            //新建数据库
            //db.ExecuteCmd("drop database if exists job;");
            db.ExecuteCmd(@"create database if not exists job;");

            db.ExecuteCmd(@"drop table if exists jobs,web;");

            //创建表
            db.ExecuteCmd(@"create table if not exists web (" +
                "companyName text," +
                "address text," +
                "createTime text," +
                "title text," +
                "duties text," +
                "qualifications text" +
                ");");
            db.ExecuteCmd(@"create table if not exists jobs (" +
                "company text," +
                "month text," +
                "position text," +
                "adjList text," +
                "skillList text" +
                ");");
        }

        /// <summary>
        /// 获取modal实例
        /// </summary>
        /// <returns></returns>
        public static ModalImpl GetInstance()
        {
            if (modal == null)
            {
                modal = new ModalImpl();
            }
            return modal;
        }

        /// <summary>
        /// 联网获取职位信息
        /// </summary>
        /// <returns>新版Bean集合</returns>
        public async Task<List<JobInfo>> readDataFromNet()
        {
            WebSpider spider = new WebSpider();
            return await Task.Run(async () =>
            {
                await spider.Start();
                Console.WriteLine("read Data From Net complete");

                //异步写入数据库
                foreach (JobInfo job in spider.GetJobList())
                    db.ExecuteCmd(@"insert into web values ('" +
                        job.companyName + "','" +
                        job.address + "','" +
                        job.createTime + "','" +
                        job.title + "','" +
                        job.duties + "','" +
                        job.qualifications + "'" +
                        ");");
                return spider.GetJobList();
            });
        }


        /// <summary>
        /// 获取某公司在月份的发布职位个数
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <param name="month">发布职位月份, 格式2017-12</param>
        /// <returns></returns>
        public int getJobCount(string company, string month)
        {
            int count = db.CountCmd(@"select count(*) from jobs where company like '%" + company + "%' " +
                "and month like '%" + month + "%');");
            Console.WriteLine("job in month count: " + count);
            return count;
        }


        /// <summary>
        /// 获取某公司各个位置的数量统计 (运维、前端)
        /// Dictionary中第一项为位置名称（即运维、前端），第二项为该公司该位置的统计数目
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <returns></returns>
        public Dictionary<string, int> getPositionCountInCompany(string company)
        {
            DataSet data = db.QueryCmd(@"select position from jobs where company like '%" + company + "%');");
            DataTable table = data.Tables[0];

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (DataRow row in table.Rows)
            {
                string position = Convert.ToString(row[0]);

                if (dictionary.ContainsKey(position))
                {
                    dictionary[position] = ++dictionary[position];
                }
                else
                {
                    dictionary.Add(position, 1);
                }
            }
            Console.WriteLine("get Company Position Dictionary");
            return dictionary;
        }


        /// <summary>
        /// 数据写入到数据库中
        /// </summary>
        /// <param name="beans"></param>
        public void writeData(List<JobBean> beans)
        {
            foreach (JobBean bean in beans)
            {
                db.ExecuteCmd(@"insert into jobs values ('" +
                     bean.company + "','" +
                     bean.month + "','" +
                     bean.position + "','" +
                     ListToString(bean.adjList) + "','" +
                     ListToString(bean.skillList) + "'" +
                    ");");
            }
        }


        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <returns></returns>
        public List<string> getCompanyList()
        {
            DataSet dataSet = db.QueryCmd(@"select company from jobs;");
            DataTable table = dataSet.Tables[0];
            List<string> company = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                company.Add(Convert.ToString(row[0]));
            }
            return company;
        }


        /// <summary>
        /// 获取该公司各项技能（java,安卓,Unix,数据库）统计数值
        /// Dictionary中第一项为技能名称（java/Unix) 第二项为该公司该技能统计数值
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <returns></returns>
        public Dictionary<string, int> getSkillCountInCompany(string company)
        {
            DataSet data = db.QueryCmd(@"select skillList from jobs where company like '%" + company + "%');");
            DataTable table = data.Tables[0];

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (DataRow row in table.Rows)
            {
                string[] skills = Convert.ToString(row[0]).Split(',');

                foreach (string skill in skills)
                {
                    if (dictionary.ContainsKey(skill))
                    {
                        dictionary[skill] = ++dictionary[company];
                    }
                    else
                    {
                        dictionary.Add(skill, 1);
                    }
                }
            }
            Console.WriteLine("get Company Skill Dictionary");

            return dictionary;
        }


        /// <summary>
        /// 获取某项技能的全部统计值
        /// </summary>
        /// <param name="skill">技能名称（java/Unix)</param>
        /// <returns>该项技能在所有公司中的统计总量</returns>
        public int getSkillCountInTotal(string skill)
        {
            int count = db.CountCmd(@"select count(*) from jobs where skillList like '%" + skill + "%'");
            Console.WriteLine("get Skill Count Total: " + count);
            return count;
        }

        /// <summary>
        /// 获取某个职位（运维/前端）需要的技能(java,unix)
        /// </summary>
        /// <param name="position">职位名字</param>
        /// <returns>所需技能列表</returns>
        public List<string> getSkillOfPosition(string position)
        {
            DataSet dataSet = db.QueryCmd(@"select skillList from jobs where skillList like '%" + position + "%'");
            DataTable table = dataSet.Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.AddRange(StringToList(Convert.ToString(row[0])));
            }
            Console.WriteLine("get Skill Of Position");
            return list;
        }

        /// <summary>
        /// 获取某月份某职位的个数
        /// </summary>
        /// <param name="position">职位名字（运维/前端）</param>
        /// <param name="month">月份，格式参考"2017-12"</param>
        /// <returns></returns>
        public int getPositionCountOfMonth(string position, string month)
        {
            int count = db.CountCmd(@"select position from jobs where month like '%" + month + "%'");
            Console.WriteLine("get Position Count Of Month : " + count);
            return count;
        }

        /// <summary>
        /// 获取职位列表(前端/运维/安全)
        /// 以及对应的哪些月份有岗位
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> getPosition_And_Months()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            DataSet dataSet = db.QueryCmd(@"select position,month from jobs;");
            DataTable table = dataSet.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                if (dictionary.ContainsKey(Convert.ToString(row[0]))) {
                    List<string> list = dictionary[Convert.ToString(row[0])];
                    if (!list.Contains(Convert.ToString(row[0]).Substring(0, 7)))
                    {
                        list.Add(Convert.ToString(row[0]));
                        dictionary[Convert.ToString(row[0])] = list;
                    }
                }
            }
            Console.WriteLine("get Position And Months");

            return dictionary;
        }


        //将list转为一定格式的string
        private string ListToString(List<string> list)
        {
            string s = "";
            foreach (string item in list)
            {
                s += item + ",";
            }
            return s.TrimEnd(',');
        }

        //将格式化的string转为List
        private List<string> StringToList(string form)
        {
            string[] strings = form.Split(',');
            return strings.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    public class JobInfo
    {
        //公司名称
        public string companyName { get; set; }
        //公司地址
        public string address { get; set; }
        //创建时间
        private string _createTime;
        public string createTime
        {
            get {
                return _createTime;
            }
            set {
                if (!value.Contains("-"))
                    _createTime = FormDate(value);
                else
                    _createTime = value;
            } }
        //职位名称
        public string title { get; set; }
        //岗位职责
        public string duties { get; set; }
        //岗位要求
        public string qualifications { get; set; }

        public JobInfo(
            string companyName,
            string address,
            string createTime,
            string title,
            string duties,
            string qualifications)
        {
            this.companyName = companyName;
            this.address = address;
            this.createTime = createTime;
            this.title = title;
            this.duties = duties;
            this.qualifications = qualifications;
        }

        //将时间戳转为日期
        private string FormDate(string timeStamp)
        {
            timeStamp = timeStamp.Substring(0, timeStamp.Length - 3);
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(Convert.ToDouble(timeStamp));
            System.Console.WriteLine("form date: " + dt.ToString("yyyy-MM-dd"));
            return dt.ToString("yyyy-MM-dd");
        }
        
        public override string ToString()
        {
            return "companyName: " + companyName +
                "address: " + address +
                "createTime: " + createTime +
                "title: " + title +
                "duties: " + duties +
                "qualifications: " + qualifications;
        }
    }
}

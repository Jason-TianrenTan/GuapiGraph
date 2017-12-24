using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    public class JobInfo
    {
        public string companyName { get; set; }
        public string address { get; set; }
        public string createTime { get; set; }
        public string expire { get; set; }
        public string id { get; set; }
        public string internCompanyId { get; set; }
        public string mark { get; set; }
        public string receiveResumeCount { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string updateTime { get; set; }

        public List<string> duties = new List<string>();//岗位职责
        public List<string> qualifications = new List<string>();//岗位要求

        public void addDuty(string duty)
        {
            duties.Add(duty);
        }

        public void addQualification(string qual)
        {
            qualifications.Add(qual);
        }

        public string getDuties()
        {
            StringBuilder sb = new StringBuilder();
            int length = 0;
            for (int i = 0; i < duties.Count; i++)
            {
                sb.Append(duties[i]);
                if (i < duties.Count - 1)
                    sb.Append(" ");
                length += duties[i].Length;
                if (length > 40)
                    break;
            }
            return sb.ToString();
        }

        public string getQualifications()
        {
            StringBuilder sb = new StringBuilder();
            int length = 0;
            for (int i = 0; i < qualifications.Count; i++)
            {
                sb.Append(qualifications[i]);
                if (i < qualifications.Count - 1)
                    sb.Append(" ");
                length += qualifications[i].Length;
                if (length > 40)
                    break;
            }
            return sb.ToString();
        }

        public string getDutiesEndl()
        {
            StringBuilder sb = new StringBuilder();
            int length = 0;
            for (int i = 0; i < duties.Count; i++)
            {
                sb.Append(duties[i] + "\n");
                length += duties[i].Length;
                if (length > 40)
                    break;
            }
            return sb.ToString();
        }

        public string getQualificationsEndl()
        {
            StringBuilder sb = new StringBuilder();
            int length = 0;
            for (int i = 0; i < qualifications.Count; i++)
            {
                sb.Append(qualifications[i] + "\n");
                length += qualifications[i].Length;
                if (length > 40)
                    break;
            }
            return sb.ToString();
        }
    }
}

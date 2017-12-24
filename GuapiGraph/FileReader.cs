using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GuapiGraph
{
    class FileReader : DataReader
    {
        public static string path = "data.base";
        void DataReader.readData()
        {
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            int total = int.Parse(reader.ReadLine());
            reader.ReadLine();
            for (int i=0;i<total;i++)
            {
                JobInfo jobInfo = new GuapiGraph.JobInfo();
                String address = reader.ReadLine();
                String title = reader.ReadLine();
                String companyId = reader.ReadLine();
                String qual = null;
                while (!(qual = reader.ReadLine()).Equals("#"))
                    jobInfo.addQualification(qual);
                String duty = null;
                while (!(duty = reader.ReadLine()).Equals("EOD"))
                    jobInfo.addDuty(duty);
                jobInfo.address = address;
                jobInfo.title = title;
                jobInfo.internCompanyId = companyId;
            }
        }
    }
}

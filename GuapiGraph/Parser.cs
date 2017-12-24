using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class Parser
    {
        public static JobBean Parse(Parsable obj)
        {
            JobBean ret = new JobBean();
            String name = obj.getName(),
                company = obj.getCompany();
            List<string> duties = obj.getDuties(),
                qualifications = obj.getQualifications();
            //parse...
            
            return ret;
        }
    }
}

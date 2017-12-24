using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    interface Parsable
    {
        string getName();//岗位名称
        string getDate();//2017-12-12
        List<string> getQualifications();//岗位要求
        List<string> getDuties();//岗位职责
        string getCompany();//公司
    }
}

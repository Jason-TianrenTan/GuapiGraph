using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class TempBean : Parsable
    {
        public string getCompany()
        {
            return "阿里巴巴";
        }

        public string getName()
        {
            return "网页搜索研发部数据挖掘实习研究员";
        }

        public string getDate()
        {
            return "2017-12-23";
        }

        public List<string> getDuties()
        {
            string[] quals = new string[] {"负责业务系统的核心功能需求拆解和开发", "负责业务系统的核心功能需求拆解和开发" };
            return new List<string>(quals);
        }

        public List<string> getQualifications()
        {
            string[] duties = new string[] { "JAVA基础扎实，数据结构和算法扎实、多线程编程，掌握常用的设计模式；熟悉JVM，包括内存模型、类加载机制及性能优化",
                "熟悉spring 、mybatis，mysql等Java系技术栈", "对技术有热情，喜欢钻研，较强的团队沟通和协作能力和自我驱动能力" };
            return new List<string>(duties);
        }

    }
}

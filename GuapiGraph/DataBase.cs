using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class DataBase : DataReader
    {
        /*
         * 每个月份的岗位个数
         */
        private static Dictionary<int, int> monthCount = new Dictionary<int, int>();


        /*
         * Java/Python/C++
         */
        private static Dictionary<String, int> skillCount = new Dictionary<string, int>();

        /*
         *  运维/前端/分布式
         */
        private static Dictionary<String, int> positionCount = new Dictionary<string, int>();

        
        /*
         * 实例化接口
         */
        void DataReader.readData()
        {

        }
    }
}

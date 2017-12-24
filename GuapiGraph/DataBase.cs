using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class DataBase
    {
        /*
         * 每个月份的岗位个数
         * 2016.10, 2017.2
         */
        private static Dictionary<string, int> monthCount;

        /*
         * Java/Python/C++
         */
        private static Dictionary<string, int> skillCount;

        /*
         *  运维/前端/分布式
         */
        private static Dictionary<string, int> positionCount;

        
        //init data
        public static void init()
        {
            monthCount = new Dictionary<string, int>();
            skillCount = new Dictionary<string, int>();
            positionCount = new Dictionary<string, int>();
        }


        public static void addMonth(string month)
        {
            if (monthCount.ContainsKey(month))
                monthCount[month]++;
            else monthCount.Add(month, 1);
        }


        public static void addSkill(string skill)
        {
            if (skillCount.ContainsKey(skill))
                skillCount[skill]++;
            else skillCount.Add(skill, 1);
        }


        public static void addPosition(string position)
        {
            if (positionCount.ContainsKey(position))
                positionCount[position]++;
            else positionCount.Add(position, 1);
        }

    }
}

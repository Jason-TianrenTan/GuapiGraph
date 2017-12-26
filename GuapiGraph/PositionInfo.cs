using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    class PositionInfo
    {
        public string Name { get; set; }//岗位名称
        List<MonthData> monthDataList { get; set; }//月份信息列表

        public PositionInfo(string postionName, List<MonthData> monthDatas)
        {
            this.Name = postionName;
            this.monthDataList = monthDatas;
        }

        
        public List<string> getMonths()
        {
            List<string> list = new List<string>();
            foreach (MonthData mData in monthDataList)
                list.Add(mData.monthName);
            return list;
        }

        
        public List<int> getCounts()
        {
            List<int> list = new List<int>();
            foreach (MonthData mData in monthDataList)
                list.Add(mData.positionCount);
            return list;
        }



        /*
         * 例如针对“前端”这一岗位，
         * 2017年11月有122份岗位，2017年12月有143份岗位，
         * 那么Name = "前端",
         * monthDataList里第一项monthName = "2017-11", positionCount = 122
         * monthDataList里第二项monthName = "2017-12", positionCount = 143
         */

    }
    public class MonthData
    {
        public string monthName { get; set; }//2017-12
        public int positionCount { get; set; }//2017年12月该position职位个数
    }

}

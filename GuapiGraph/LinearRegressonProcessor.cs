using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    //计算线性回归方程
    class LinearRegressonProcessor
    {
        private List<int> xList = null;
        private List<double> yList = null;

        public LinearRegressonProcessor(List<string> monthList, List<double> countList)
        {
            init(monthList, countList);
        }

        private void init(List<string> monthList, List<double> countList)
        {
            xList = new List<int>();
            foreach (string mStr in monthList)
            {
                Month month = new Month(mStr);
                xList.Add(month.convertToNumber());
            }
            yList = countList;
        }


        class Month
        {
            private int year;
            private int month;
            public Month(string str)
            {
                string[] arr = str.Split(new Char[] { '-' });
                year = int.Parse(arr[0]);
                month = int.Parse(arr[1]);
            }


            /// <summary>
            /// 转数字，用于计算线性回归
            /// </summary>
            /// <returns></returns>
            public int convertToNumber()
            {
                return year * 12 + month;
            }


            /// <summary>
            /// 转字符串，用于展示
            /// </summary>
            /// <returns></returns>
            public string convertToString()
            {
                return year + "-" + month;
            }


            public override string ToString()
            {
                return convertToString();
            }

        }
    }
}

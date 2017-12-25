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
        private List<int> yList = null;
        private int count = 0;

        public LinearRegressonProcessor(List<string> monthList, List<int> countList)
        {
            init(monthList, countList);
        }


        private void init(List<string> monthList, List<int> countList)
        {
            xList = new List<int>();
            int minX = -1;
            foreach (string mStr in monthList)
            {
                Month month = new Month(mStr);
                int monthValue = month.convertToNumber();
                if (minX == -1)
                    minX = monthValue;
                xList.Add(monthValue);
                minX = minX > monthValue ? monthValue : minX;
            }
            for (int i = 0; i < xList.Count; i++)
                xList[i] -= minX;
            yList = countList;
            count = xList.Count < yList.Count ? xList.Count : yList.Count;
        }


        public void Calculate(out double slope, out double intercept)
        {
            slope = 0;
            intercept = 0;
            if (this.count < 2)
                return;
            double sumX = 0, sumY = 0;
            double avgX, avgY;
            int count = xList.Count;

            for (int i = 0; i < xList.Count; i++)
            {
                sumX += xList[i];
                sumY += yList[i];
            }

            avgX = sumX / count;
            avgY = sumY / count;

            double SPxy = 0;
            double SSx = 0;
            double SSy = 0;
            for (int i = 0; i < count; i++)
            {
                SPxy += (xList[i] - avgX) * (yList[i] - avgY);
                SSx += (xList[i] - avgX) * (xList[i] - avgX);
                SSy += (yList[i] - avgY) * (yList[i] - avgY);
            }


            //y=bx+a
            slope = SPxy / SSx;
            intercept = avgY - slope * avgX;
        }
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

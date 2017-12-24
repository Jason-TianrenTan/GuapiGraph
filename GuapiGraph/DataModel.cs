using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    interface DataModel
    {
        //获取网络数据
        List<JobInfo> readDataFromNet();

        /// <summary>
        /// 获取某公司在月份的发布职位个数
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <param name="month">发布职位月份, 格式2017-12</param>
        /// <returns></returns>
        int getJobCount(string companyId, string month);

        void writeData(List<JobBean> beans);
    }
}

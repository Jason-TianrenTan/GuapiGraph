using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph
{
    interface DataModel
    {

        /// <summary>
        /// 联网获取职位信息
        /// </summary>
        /// <returns>新版Bean集合</returns>
        Task<List<JobInfo>> readDataFromNet();


        /// <summary>
        /// 获取某公司在月份的发布职位个数
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <param name="month">发布职位月份, 格式2017-12</param>
        /// <returns></returns>
        int getJobCount(string company, string month);


        /// <summary>
        /// 获取某公司各个位置的数量统计 (运维、前端)
        /// Dictionary中第一项为位置名称（即运维、前端），第二项为该公司该位置的统计数目
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <returns></returns>
        Dictionary<string,int> getPositionCountInCompany(string company);


        /// <summary>
        /// 数据写入到数据库中
        /// </summary>
        /// <param name="beans"></param>
        void writeData(List<JobBean> beans);


        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <returns></returns>
        List<string> getCompanyList();


        /// <summary>
        /// 获取该公司各项技能（java,安卓,Unix,数据库）统计数值
        /// Dictionary中第一项为技能名称（java/Unix) 第二项为该公司该技能统计数值
        /// </summary>
        /// <param name="company">公司名称</param>
        /// <returns></returns>
        Dictionary<string, int> getSkillCountInCompany(string company);


        /// <summary>
        /// 获取某项技能的全部统计值
        /// </summary>
        /// <param name="skill">技能名称（java/Unix)</param>
        /// <returns>该项技能在所有公司中的统计总量</returns>
        int getSkillCountInTotal(string skill);


        /* 2017-12-25更新 */
        /// <summary>
        /// 获取某个职位（运维/前端）需要的技能(java,unix)
        /// </summary>
        /// <param name="position">职位名字</param>
        /// <returns>所需技能列表</returns>
        List<string> getSkillOfPosition(string position);


        /// <summary>
        /// 获取某月份某职位的个数
        /// </summary>
        /// <param name="position">职位名字（运维/前端）</param>
        /// <param name="month">月份，格式参考"2017-12"</param>
        /// <returns></returns>
        int getPositionCountOfMonth(string position, string month);


        /// <summary>
        /// 获取职位列表(前端/运维/安全)
        /// </summary>
        /// <returns></returns>
        List<string> getPositions();
    }
}

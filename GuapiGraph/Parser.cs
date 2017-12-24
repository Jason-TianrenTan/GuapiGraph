using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiebaNet.Segmenter;
using System.Text.RegularExpressions;
using JiebaNet.Segmenter.PosSeg;
using JiebaNet.Analyser;

namespace GuapiGraph
{
    class Parser
    {
        public static JobBean Parse(Parsable obj)
        {
            JobBean ret = new JobBean();
            String name = obj.getName(),
                company = obj.getCompany(),
                date = obj.getDate();
            List<string> qualifications = obj.getQualifications();
            StringBuilder builder = new StringBuilder();
            foreach (string str in qualifications)
                builder.Append(str);
            string quals = builder.ToString();

            ret.position = getPosition(name);
            ret.company = company;
            ret.month = getMonth(date);
            ret.skillList = getSkills(quals);
            ret.adjList = getAdjs(quals);

            return ret;
        }


        //segmenter设置停词表有问题 暂用手动
        private static string getPosition(String name)
        {
            string[] stopwords = new string[] { "实习", "研发", "开发", "研究员", "实习生", "工程师" };
            var segmenter = new JiebaSegmenter();
            var nameSegs = segmenter.Cut(name);
            StringBuilder builder = new StringBuilder();
            foreach (string str in nameSegs)
            {
                if (stopwords.Contains<string>(str))
                    break;
                builder.Append(str);
            }
            return builder.ToString();
        }


        private static string getMonth(string date)
        {
            int index = date.LastIndexOf("-");
            return date.Substring(0, index);
        }


        private static List<string> getSkills(string quals)
        {
            String expr = @"[a-zA-Z]+";
            MatchCollection matches = Regex.Matches(quals, expr);
            List<string> ret = new List<string>();
            foreach (Match m in matches)
                ret.Add(m.ToString());
            return ret;
        }


        //助教所指adj "精通" "熟悉"等实为动词，这里提取v
        private static List<string> getAdjs(string quals)
        {
            var segmenter = new PosSegmenter();
            var tokens = segmenter.Cut(quals);
            List<string> words = new List<string>();
            foreach (var token in tokens)
                if (token.Flag == "v")
                    words.Add(token.Word);
            foreach (string word in words)
                Console.WriteLine(word);
            return null;    
        }
    }
}

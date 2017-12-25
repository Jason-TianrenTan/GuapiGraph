using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GuapiGraph
{
    public partial class Form1 : Form
    {

        private DataModel modal = null;//ModalImpl.GetInstance();

        public Form1()
        {
            InitializeComponent();
            string[] months = { "2016-12", "2017-1", "2017-2", "2017-3" };
            double[] count = { 30,40,50,60 };
            double k, b;
            new LinearRegressonProcessor(new List<string>(months), new List<double>(count)).Calculate(out k, out b);
            Console.WriteLine("k = " + k + ", b = " + b);
        }

        private void job_button_show_Click(object sender, EventArgs e)
        {
            get_job_chart();//展示图表结果
            
        }

       
        //技能树构造链表
        protected Dictionary<string, int> skill_tree_items = new Dictionary<string, int>();
        private void make_skill_Items() {
            skill_tree_items.Clear();//清空技能树构造链表
            string company = skill_job_list.SelectedItem.ToString();
            skill_tree_items = modal.getSkillCountInCompany(company);
        }
        /// <summary>
        /// 技能树页面，list双击事件
        /// </summary>
        private void skill_job_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            make_skill_Items();

        }

        private void menu_func_catchInfo_Click(object sender, EventArgs e)
        {
            string tips = "start catching information\n" + "target:https://www.nowcoder.com/recommend\n";
            MessageBox.Show(tips);
            //获取网络数据
            modal.readDataFromNet();
        }

      
        private void button_show_companyList_Click(object sender, EventArgs e)
        {
            get_companylist();

        }
       
        protected List<string> companyList = new List<string>();
        /// <summary>
        /// 得到公司列表展示在list
        /// </summary>
        private void get_companylist()
        {
            companyList = modal.getCompanyList();
            if (companyList.Count < 1)
                return;
            skill_job_list.Items.Add("we found " + companyList.Count + " company totally");
            foreach (string name in companyList)
            {
                skill_job_list.Items.Add(name);
            }
        }

        /// <summary>
        /// 得到柱状图
        /// </summary>
        string[] x = new string[] { "南山大队", "福田大队", "罗湖大队", "宝安大队", "指挥处", "大帝科技", "南山大队", "福田大队", "罗湖大队", "宝安大队", "指挥处", "大帝科技" };
        double[] y = new double[] { 541, 574, 345, 854, 684, 257, 541, 574, 345, 854, 684, 257 };
        private void get_job_chart()
        {
            //标题

            job_chart.Titles.Add("numbers-company chart");
            job_chart.Titles[0].ForeColor = Color.Black;
            job_chart.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
            job_chart.Titles[0].Alignment = ContentAlignment.TopCenter;

            //控件背景
            job_chart.BackColor = Color.Transparent;
            //图表区背景
            job_chart.ChartAreas[0].BackColor = Color.Transparent;
            job_chart.ChartAreas[0].BorderColor = Color.Transparent;
            //X轴标签间距
            job_chart.ChartAreas[0].AxisX.Interval = 1;
            job_chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            job_chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            job_chart.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
            job_chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;

            //X坐标轴颜色
            job_chart.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
            job_chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
            job_chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            //X轴网络线条
            job_chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            job_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            job_chart.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            job_chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
            job_chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //Y坐标轴标题
            job_chart.ChartAreas[0].AxisY.Title = "岗位数量";
            job_chart.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            job_chart.ChartAreas[0].AxisY.TitleForeColor = Color.Black;
            job_chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            //Y轴网格线条
            job_chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            job_chart.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
            job_chart.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
            job_chart.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
            Legend legend = new Legend("legend");
            legend.Title = "legendTitle";

            job_chart.Series[0].XValueType = ChartValueType.String;  //设置X轴上的值类型
            job_chart.Series[0].Label = "#VAL";                //设置显示X Y的值    
            job_chart.Series[0].LabelForeColor = Color.Black;
            job_chart.Series[0].ToolTip = "#VALX:#VAL";     //鼠标移动到对应点显示数值
            job_chart.Series[0].ChartType = SeriesChartType.Column;    //图类型(折线)


            job_chart.Series[0].Color = Color.Lime;
            job_chart.Series[0].LegendText = legend.Name;
            job_chart.Series[0].IsValueShownAsLabel = true;
            job_chart.Series[0].LabelForeColor = Color.Black;
            job_chart.Series[0].CustomProperties = "DrawingStyle = Cylinder";
            job_chart.Legends.Add(legend);
            job_chart.Legends[0].Position.Auto = false;

            job_chart.Series[0].Points.DataBindXY(x, y);
            job_chart.Series[0].Points[0].Color = Color.Black;
            job_chart.Series[0].Palette = ChartColorPalette.SeaGreen;
            job_chart.Visible = true;


        }

     


    }
}

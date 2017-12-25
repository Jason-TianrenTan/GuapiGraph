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

        private DataModel modal = null; // ModalImpl.GetInstance();

        public Form1()
        {
            InitializeComponent();
        }



        //技能树构造链表
        protected Dictionary<string, int> skill_tree_items = new Dictionary<string, int>();
        private void make_skill_Items()
        {
            skill_tree_items.Clear();//清空技能树构造链表
            string company = company_skill_list.SelectedItem.ToString();
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
            this.infomation_state.Text = "spider is working...";
            Task<List<JobInfo>> task = modal.readDataFromNet();
            
            this.infomation_state.Text = "infomation catched!";
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
            company_skill_list.Items.Add("we found " + companyList.Count + " company totally");
            company_job_list.Items.Add("we found " + companyList.Count + " company totally");
            foreach (string name in companyList)
            {
                company_job_list.Items.Add(name);
                company_skill_list.Items.Add(name);
            }
        }

        /// <summary>
        /// 得到柱状图
        /// </summary>
        private void get_job_chart(string companyName)
        {
            //数据库中提取公司中各岗位和数量
            Dictionary<string, int> kind_numbers = modal.getPositionCountInCompany(companyName);
            List<string> x = new List<string>();
            List<int> y = new List<int>();

            foreach(var kin_number in kind_numbers){
                x.Add(kin_number.Key);
                y.Add(kin_number.Value);
            }
          //标题
            job_chart.Titles.Add("numbers-jobs in" +companyName +"company chart");
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
            job_chart.ChartAreas[0].AxisY.Title = "岗位&数量";
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
            job_chart.Series[0].ChartType = SeriesChartType.Column;    //图类型


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
        /// <summary>
        /// 得到技能树图
        /// </summary>
       private void get_skill_chart(string companyName)
        {
            double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42, 55.9, 63.6, 55.2, 77.1 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy", "Spain", "Russia", "Sweden", "Japan" };
            radar_chart.Series[0].Points.DataBindXY(xValues, yValues);
            // //标题
            radar_chart.Titles.Add("skills-needed graph in "+ CompanyName );
            radar_chart.Titles[0].ForeColor = Color.White;
            radar_chart.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
            radar_chart.Titles[0].Alignment = ContentAlignment.TopCenter;
          
            //控件背景
            radar_chart.BackColor = Color.Transparent;
            radar_chart.ChartAreas[0].BackColor = Color.Transparent;
            radar_chart.ChartAreas[0].BorderColor = Color.Transparent;
            //X轴标签间距
            radar_chart.ChartAreas[0].AxisX.Interval = 1;
            radar_chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            radar_chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            radar_chart.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
            radar_chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;

            //X坐标轴颜色
            radar_chart.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
            radar_chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            radar_chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            
            //X轴网络线条
            radar_chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            radar_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            radar_chart.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            radar_chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            radar_chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
           
            //Y轴网格线条
            radar_chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            radar_chart.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            radar_chart.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
            radar_chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            radar_chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            radar_chart.ChartAreas[0].AxisX.IsInterlaced = false;
            radar_chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            //刻度线
            radar_chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            
            radar_chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            //背景渐变
            radar_chart.ChartAreas[0].BackGradientStyle = GradientStyle.None;
           
            //图例样式
            Legend legend4 = new Legend();
            legend4.Title = "图例";
            legend4.TitleBackColor = Color.Transparent;
            legend4.BackColor = Color.Transparent;
            legend4.TitleForeColor = Color.White;
            legend4.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            legend4.Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            legend4.ForeColor = Color.White;
            radar_chart.Legends.Add(legend4);
            radar_chart.Legends[0].Position.Auto = true;

            //Series1
            radar_chart.Series[0].XValueType = ChartValueType.String;
            radar_chart.Series[0].Label = "#VAL";
            radar_chart.Series[0].LabelForeColor = Color.White;
            radar_chart.Series[0].ToolTip = "#LEGENDTEXT:#VAL(宗)";
            radar_chart.Series[0].ChartType = SeriesChartType.Radar;
            radar_chart.Series[0]["RadarDrawingStyle"] = "Line";
            radar_chart.Series[0].LegendText = "2015年";
            radar_chart.Series[0].IsValueShownAsLabel = true;




            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            radar_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            radar_chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

            for (int i = 0; i < radar_chart.Series[2].Points.Count; i++)
            {
                radar_chart.Series[2].Points[i].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
                radar_chart.Series[2].Points[i].MarkerColor = Color.Red;//设置seires中折点的颜色   
                                                                 //    cht4.Series[1].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
                                                                 //    cht4.Series[1].Points[i].MarkerColor = Color.Blue;//设置seires中折点的颜色  
                                                                 //    cht4.Series[2].Points[i].MarkerStyle = MarkerStyle.Square;//设置折点的风格     
                                                                 //    cht4.Series[2].Points[i].MarkerColor = Color.Green;//设置seires中折点的颜色  
            }
            for (int i = 0; i < radar_chart.Series.Count; i++)
            {
                for (int j = 0; j < radar_chart.Series[i].Points.Count; j++)
                {
                    radar_chart.Series[i].Points[j].Label = " ";
                    //cht4.Series[i].Points[j].LabelToolTip = "string.Empty";
                }
            }
            //cht4.ImageType = ChartImageType.Jpeg;
            //反锯齿  
            radar_chart.AntiAliasing = AntiAliasingStyles.All;
            //调色板 磨沙:SemiTransparent  
            radar_chart.Palette = ChartColorPalette.BrightPastel;

            radar_chart.Series[0].ChartType = SeriesChartType.Radar;
            radar_chart.Series[1].ChartType = SeriesChartType.Radar;
            radar_chart.Series[2].ChartType = SeriesChartType.Radar;
            radar_chart.Width = 500;
            radar_chart.Height = 350;
        }

        private void menu_item_show_compannylist_Click(object sender, EventArgs e)
        {
            get_companylist();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

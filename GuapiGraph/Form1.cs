using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GuapiGraph
{
    public partial class Form1 : Form
    {
        List<PositionInfo> positionInfos;
        private DataModel modal = ModalImpl.GetInstance();
        bool inited = false;
        bool treeInit = false;
        bool columnInit = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void init()
        {
            initComboBox();
            initPredictonChart();
        }


        private void initComboBox()
        {
            Dictionary<string, List<string>> dict = modal.getPosition_And_Months();
            positionInfos = new List<PositionInfo>();
            foreach (var entry in dict)
            {
                string positionName = entry.Key;
                List<string> months = entry.Value;
                List<MonthData> monthDatas = new List<MonthData>();
                foreach (string month in months)
                {
                    MonthData monthData = new MonthData();
                    monthData.monthName = month;
                    monthData.positionCount = modal.getPositionCountOfMonth(positionName, month);
                    monthDatas.Add(monthData);
                }
                PositionInfo positionInfo = new PositionInfo(positionName, monthDatas);
                positionInfos.Add(positionInfo);
                positionComboBox.BeginInvoke((MethodInvoker)delegate (){
                    positionComboBox.Items.Add(positionName);
                });
               
            }
        }


        private void initPredictonChart()
        {
            if (!inited)
            {
                inited = true;
                getPredictionChart(0);
                //标题
                PredictionChart.BeginInvoke((MethodInvoker)delegate {
                    PredictionChart.Titles.Add("统计分析表");
                    PredictionChart.Titles[0].ForeColor = Color.Black;
                    PredictionChart.Titles[0].Font = new Font("Calibri", 16f, FontStyle.Regular);
                    PredictionChart.Titles[0].Alignment = ContentAlignment.TopCenter;

                    //控件背景
                    PredictionChart.BackColor = Color.Transparent;
                    //图表区背景
                    PredictionChart.ChartAreas[0].BackColor = Color.Transparent;
                    PredictionChart.ChartAreas[0].BorderColor = Color.Transparent;
                    //X轴标签间距
                    PredictionChart.ChartAreas[0].AxisX.Interval = 1;
                    PredictionChart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                    PredictionChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    PredictionChart.ChartAreas[0].AxisX.TitleFont = new Font("Calibri", 14f, FontStyle.Regular);
                    PredictionChart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;

                    //X坐标轴颜色
                    PredictionChart.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
                    PredictionChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                    PredictionChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Calibri", 10f, FontStyle.Regular);

                    //X轴网络线条
                    PredictionChart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                    PredictionChart.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

                    //Y坐标轴颜色
                    PredictionChart.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
                    PredictionChart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                    PredictionChart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Calibri", 10f, FontStyle.Regular);
                    //Y坐标轴标题
                    PredictionChart.ChartAreas[0].AxisY.Title = "职位数目";
                    PredictionChart.ChartAreas[0].AxisY.TitleFont = new Font("Calibri", 10f, FontStyle.Regular);
                    PredictionChart.ChartAreas[0].AxisY.TitleForeColor = Color.Black;
                    PredictionChart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                    //Y轴网格线条
                    PredictionChart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                    PredictionChart.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
                    PredictionChart.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
                    PredictionChart.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
                    Legend legend = new Legend("legend");
                    legend.Title = "legendTitle";

                    PredictionChart.Series[0].XValueType = ChartValueType.String;  //设置X轴上的值类型
                    PredictionChart.Series[0].Label = "#VAL";                //设置显示X Y的值    
                    PredictionChart.Series[0].LabelForeColor = Color.Black;
                    PredictionChart.Series[0].ToolTip = "#VALX:#VAL";     //鼠标移动到对应点显示数值
                    PredictionChart.Series[0].ChartType = SeriesChartType.Column;    //图类型


                    PredictionChart.Series[0].Color = Color.Lime;
                    PredictionChart.Series[0].LegendText = legend.Name;
                    PredictionChart.Series[0].IsValueShownAsLabel = true;
                    PredictionChart.Series[0].LabelForeColor = Color.Black;
                    PredictionChart.Series[0].CustomProperties = "DrawingStyle = Cylinder";
                    PredictionChart.Legends.Add(legend);
                    PredictionChart.Legends[0].Position.Auto = false;
                    //PredictionChart.Series[0].Points[0].Color = Color.Black;
                    PredictionChart.Series[0].Palette = ChartColorPalette.SeaGreen;
                    PredictionChart.Visible = true;
                });
               
               
            }
        }



        private void menu_func_catchInfo_Click(object sender, EventArgs e)
        {
            string tips = "start catching information\n" + "target:https://www.nowcoder.com/recommend\n";
            MessageBox.Show(tips);
            //获取网络数据
            this.infomation_state.Text = "spider is working...";
            Thread spiderThread = new Thread(spiderStart);
            spiderThread.Start();

        }

        private async void spiderStart()
        {
            List<JobInfo> jobInfoList = await modal.readDataFromNet();
            infomation_state.BeginInvoke((MethodInvoker)delegate ()
            {
                this.infomation_state.Text = "Parsing...";
            });
            List<JobBean> beanList = new List<JobBean>();
            foreach (JobInfo jobInfo in jobInfoList)
                beanList.Add(Parser.Parse(jobInfo));

            infomation_state.BeginInvoke((MethodInvoker)delegate ()
            {
                this.infomation_state.Text = "Writing into database...";
            });
            modal.writeData(beanList);
            init();
            get_companylist();
            infomation_state.BeginInvoke((MethodInvoker)delegate ()
            {
                this.infomation_state.Text = "infomation catched!" + companyList.Count + "  companies\' information has been catched!";
            });
            
        }


        /// <summary>
        /// 得到公司列表展示在list
        /// </summary>
        protected List<string> companyList = new List<string>();
        private void get_companylist()
        {
            if (modal == null)
            {
                return;
            }
            companyList = modal.getCompanyList();
            if (companyList.Count < 1)
                return;
            foreach (string name in companyList)
            {
                job_chart_combo.BeginInvoke((MethodInvoker)delegate ()
                {
                    job_chart_combo.Items.Add(name);
                });

                skill_tree_combo.BeginInvoke((MethodInvoker)delegate ()
                {
                    skill_tree_combo.Items.Add(name);
                });
                
            }
        }

        private void getPredictionChart(int index)
        {
            PositionInfo posInfo = positionInfos[index];
            List<int> yList = posInfo.getCounts();
            List<string> xList = posInfo.getMonths();
            PredictionChart.BeginInvoke((MethodInvoker)delegate
            {
                PredictionChart.Series[0].Points.DataBindXY(xList, yList);
            });
        }


        /// <summary>
        /// 得到柱状图
        /// </summary>
        private void get_job_chart(string companyName)
        {
            //数据库中提取公司中各岗位和数量
            if (modal == null)
                return;
            Dictionary<string, int> kind_numbers = modal.getPositionCountInCompany(companyName);
            List<string> x = new List<string>();
            List<int> y = new List<int>();
            foreach (var kin_number in kind_numbers)
            {
                x.Add(kin_number.Key);
                y.Add(kin_number.Value);
            }

            
            job_chart.Series[0].Points.DataBindXY(x, y);
            if (!columnInit)
            {
                columnInit = true;
                //标题
                job_chart.Titles.Add("numbers-jobs in" + companyName + "company chart");
                job_chart.Titles[0].ForeColor = Color.Black;
                job_chart.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
                job_chart.Titles[0].Alignment = ContentAlignment.TopLeft;

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

                job_chart.Series[0].Points[0].Color = Color.Black;
                job_chart.Series[0].Palette = ChartColorPalette.SeaGreen;
                job_chart.Visible = true;
            }
            job_chart.Titles[0].Text = ("numbers-jobs in" + companyName + "company chart");
        }


        /// <summary>
        /// 得到技能树图
        /// </summary>
        private void get_skill_chart(string companyName)
        {
            if (modal == null)
                return;

            Dictionary<string, int> skill_numbers = modal.getSkillCountInCompany(companyName);
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            foreach (var item in skill_numbers)
            {
                xValues.Add(item.Key);
                yValues.Add(item.Value);
            }
           
            radar_chart.Series[0].Points.DataBindXY(xValues, yValues);
            if (!treeInit)
            {
                treeInit = true;
                // //标题
                radar_chart.Titles.Add("skills-needed graph in " + companyName + " company");
                radar_chart.Titles[0].ForeColor = Color.Gray;
                radar_chart.Titles[0].Font = new Font("微软雅黑", 16f, FontStyle.Regular);
                radar_chart.Titles[0].Alignment = ContentAlignment.TopLeft;

                //控件背景
                radar_chart.BackColor = Color.Transparent;
                radar_chart.ChartAreas[0].BackColor = Color.Transparent;
                radar_chart.ChartAreas[0].BorderColor = Color.Transparent;
                //X轴标签间距
                radar_chart.ChartAreas[0].AxisX.Interval = 1;
                radar_chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                radar_chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                radar_chart.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
                radar_chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;

                //X坐标轴颜色
                radar_chart.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
                radar_chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                radar_chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

                //X轴网络线条
                radar_chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                radar_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

                //Y坐标轴颜色
                radar_chart.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
                radar_chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
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
                radar_chart.ChartAreas[0].BackGradientStyle = GradientStyle.Center;

                //图例样式
                Legend legend4 = new Legend();
                legend4.Title = "skill";
                legend4.TitleBackColor = Color.Transparent;
                legend4.BackColor = Color.Transparent;
                legend4.TitleForeColor = Color.Black;
                legend4.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
                legend4.Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                legend4.ForeColor = Color.Black;
                radar_chart.Legends.Add(legend4);
                radar_chart.Legends[0].Position.Auto = true;


                //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
               radar_chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1.5;
                //设置XY轴标题的名称所在位置位远  
                radar_chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;

                radar_chart.Series[0].Points[0].MarkerStyle = MarkerStyle.Circle;//设置折点的风格     
                radar_chart.Series[0].Points[0].MarkerColor = Color.Red;//设置seires中折点的颜色   
                radar_chart.Series[0].LegendText = "skill degree needed";

                //cht4.ImageType = ChartImageType.Jpeg;
                //反锯齿  
                radar_chart.AntiAliasing = AntiAliasingStyles.All;
                //调色板 磨沙:SemiTransparent  
                radar_chart.Palette = ChartColorPalette.BrightPastel;

                radar_chart.Series[0].ChartType = SeriesChartType.Radar;
                radar_chart.Width = 1012;
                radar_chart.Height =627;
                radar_chart.Visible = true;
            }
            radar_chart.Titles[0].Text = ("skills-needed graph in " + companyName + " company");
        }




        private void positionComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getPredictionChart(positionComboBox.SelectedIndex);
        }

        private void job_chart_combo_Click(object sender, EventArgs e)
        {
            if (job_chart_combo.SelectedItem == null){
                return;
            }
            get_job_chart(job_chart_combo.SelectedItem.ToString());
        }

        private void skill_tree_combo_Click(object sender, EventArgs e)
        {
            if (skill_tree_combo.SelectedItem ==null){
                return;
            }
            get_skill_chart(skill_tree_combo.SelectedItem.ToString());
        }
    }
}

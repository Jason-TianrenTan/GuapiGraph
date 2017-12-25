namespace GuapiGraph
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.menuitem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_func_catchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.TabControl();
            this.job_chart_page = new System.Windows.Forms.TabPage();
            this.company_job_chart_label = new System.Windows.Forms.Label();
            this.companyList_label = new System.Windows.Forms.Label();
            this.company_job_list = new System.Windows.Forms.ListBox();
            this.job_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.skill_tree_page = new System.Windows.Forms.TabPage();
            this.radar_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.companyList_skill_label = new System.Windows.Forms.Label();
            this.tree_view_label = new System.Windows.Forms.Label();
            this.company_skill_list = new System.Windows.Forms.ListBox();
            this.linearRegressionPage = new System.Windows.Forms.TabPage();
            this.LRText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.predictionLabel2 = new System.Windows.Forms.Label();
            this.predictionYearLabel1 = new System.Windows.Forms.Label();
            this.Split1 = new System.Windows.Forms.Label();
            this.PredictionsLabel = new System.Windows.Forms.Label();
            this.SelectPositionLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.predictionLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.state_label = new System.Windows.Forms.Label();
            this.infomation_state = new System.Windows.Forms.Label();
            this.menubar.SuspendLayout();
            this.table.SuspendLayout();
            this.job_chart_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.job_chart)).BeginInit();
            this.skill_tree_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radar_chart)).BeginInit();
            this.linearRegressionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitem_start});
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Size = new System.Drawing.Size(867, 28);
            this.menubar.TabIndex = 0;
            this.menubar.Text = "menu";
            // 
            // menuitem_start
            // 
            this.menuitem_start.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_func_catchInfo});
            this.menuitem_start.Name = "menuitem_start";
            this.menuitem_start.Size = new System.Drawing.Size(54, 24);
            this.menuitem_start.Text = "start";
            // 
            // menu_func_catchInfo
            // 
            this.menu_func_catchInfo.Name = "menu_func_catchInfo";
            this.menu_func_catchInfo.Size = new System.Drawing.Size(212, 26);
            this.menu_func_catchInfo.Text = "catch information";
            this.menu_func_catchInfo.Click += new System.EventHandler(this.menu_func_catchInfo_Click);
            // 
            // table
            // 
            this.table.Controls.Add(this.job_chart_page);
            this.table.Controls.Add(this.skill_tree_page);
            this.table.Controls.Add(this.linearRegressionPage);
            this.table.Location = new System.Drawing.Point(0, 41);
            this.table.Name = "table";
            this.table.SelectedIndex = 0;
            this.table.Size = new System.Drawing.Size(869, 633);
            this.table.TabIndex = 1;
            // 
            // job_chart_page
            // 
            this.job_chart_page.BackColor = System.Drawing.SystemColors.Control;
            this.job_chart_page.Controls.Add(this.company_job_chart_label);
            this.job_chart_page.Controls.Add(this.companyList_label);
            this.job_chart_page.Controls.Add(this.company_job_list);
            this.job_chart_page.Controls.Add(this.job_chart);
            this.job_chart_page.Location = new System.Drawing.Point(4, 36);
            this.job_chart_page.Name = "job_chart_page";
            this.job_chart_page.Padding = new System.Windows.Forms.Padding(3);
            this.job_chart_page.Size = new System.Drawing.Size(861, 593);
            this.job_chart_page.TabIndex = 0;
            this.job_chart_page.Text = "Overview";
            // 
            // company_job_chart_label
            // 
            this.company_job_chart_label.AutoSize = true;
            this.company_job_chart_label.Location = new System.Drawing.Point(575, 59);
            this.company_job_chart_label.Name = "company_job_chart_label";
            this.company_job_chart_label.Size = new System.Drawing.Size(100, 27);
            this.company_job_chart_label.TabIndex = 6;
            this.company_job_chart_label.Text = "Job chart";
            // 
            // companyList_label
            // 
            this.companyList_label.AutoSize = true;
            this.companyList_label.Location = new System.Drawing.Point(118, 59);
            this.companyList_label.Name = "companyList_label";
            this.companyList_label.Size = new System.Drawing.Size(133, 27);
            this.companyList_label.TabIndex = 5;
            this.companyList_label.Text = "company list";
            // 
            // company_job_list
            // 
            this.company_job_list.FormattingEnabled = true;
            this.company_job_list.ItemHeight = 27;
            this.company_job_list.Location = new System.Drawing.Point(13, 124);
            this.company_job_list.Name = "company_job_list";
            this.company_job_list.Size = new System.Drawing.Size(389, 436);
            this.company_job_list.TabIndex = 4;
            this.company_job_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.company_job_list_MouseDoubleClick);
            // 
            // job_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.job_chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.job_chart.Legends.Add(legend4);
            this.job_chart.Location = new System.Drawing.Point(452, 124);
            this.job_chart.Name = "job_chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.job_chart.Series.Add(series4);
            this.job_chart.Size = new System.Drawing.Size(376, 463);
            this.job_chart.TabIndex = 3;
            this.job_chart.Text = "job_cahrt";
            this.job_chart.Visible = false;
            // 
            // skill_tree_page
            // 
            this.skill_tree_page.BackColor = System.Drawing.SystemColors.Control;
            this.skill_tree_page.Controls.Add(this.radar_chart);
            this.skill_tree_page.Controls.Add(this.companyList_skill_label);
            this.skill_tree_page.Controls.Add(this.tree_view_label);
            this.skill_tree_page.Controls.Add(this.company_skill_list);
            this.skill_tree_page.Location = new System.Drawing.Point(4, 36);
            this.skill_tree_page.Name = "skill_tree_page";
            this.skill_tree_page.Padding = new System.Windows.Forms.Padding(3);
            this.skill_tree_page.Size = new System.Drawing.Size(861, 593);
            this.skill_tree_page.TabIndex = 1;
            this.skill_tree_page.Text = "Skill Trees";
            // 
            // radar_chart
            // 
            chartArea5.Name = "ChartArea1";
            this.radar_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.radar_chart.Legends.Add(legend5);
            this.radar_chart.Location = new System.Drawing.Point(445, 118);
            this.radar_chart.Name = "radar_chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.radar_chart.Series.Add(series5);
            this.radar_chart.Size = new System.Drawing.Size(385, 463);
            this.radar_chart.TabIndex = 7;
            this.radar_chart.Text = "radar_chart";
            this.radar_chart.Visible = false;
            // 
            // companyList_skill_label
            // 
            this.companyList_skill_label.AutoSize = true;
            this.companyList_skill_label.Location = new System.Drawing.Point(129, 69);
            this.companyList_skill_label.Name = "companyList_skill_label";
            this.companyList_skill_label.Size = new System.Drawing.Size(133, 27);
            this.companyList_skill_label.TabIndex = 6;
            this.companyList_skill_label.Text = "company list";
            // 
            // tree_view_label
            // 
            this.tree_view_label.AutoSize = true;
            this.tree_view_label.Location = new System.Drawing.Point(575, 69);
            this.tree_view_label.Name = "tree_view_label";
            this.tree_view_label.Size = new System.Drawing.Size(139, 27);
            this.tree_view_label.TabIndex = 3;
            this.tree_view_label.Text = "skill tree view";
            // 
            // company_skill_list
            // 
            this.company_skill_list.FormattingEnabled = true;
            this.company_skill_list.ItemHeight = 27;
            this.company_skill_list.Location = new System.Drawing.Point(17, 118);
            this.company_skill_list.Name = "company_skill_list";
            this.company_skill_list.Size = new System.Drawing.Size(389, 436);
            this.company_skill_list.TabIndex = 2;
            this.company_skill_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skill_job_list_MouseDoubleClick);
            // 
            // linearRegressionPage
            // 
            this.linearRegressionPage.Controls.Add(this.LRText);
            this.linearRegressionPage.Controls.Add(this.label1);
            this.linearRegressionPage.Controls.Add(this.predictionLabel2);
            this.linearRegressionPage.Controls.Add(this.predictionYearLabel1);
            this.linearRegressionPage.Controls.Add(this.Split1);
            this.linearRegressionPage.Controls.Add(this.PredictionsLabel);
            this.linearRegressionPage.Controls.Add(this.SelectPositionLabel);
            this.linearRegressionPage.Controls.Add(this.comboBox1);
            this.linearRegressionPage.Controls.Add(this.predictionLabel);
            this.linearRegressionPage.Controls.Add(this.chart1);
            this.linearRegressionPage.Location = new System.Drawing.Point(4, 36);
            this.linearRegressionPage.Name = "linearRegressionPage";
            this.linearRegressionPage.Padding = new System.Windows.Forms.Padding(3);
            this.linearRegressionPage.Size = new System.Drawing.Size(861, 593);
            this.linearRegressionPage.TabIndex = 2;
            this.linearRegressionPage.Text = "Predictions";
            this.linearRegressionPage.UseVisualStyleBackColor = true;
            // 
            // LRText
            // 
            this.LRText.AutoSize = true;
            this.LRText.Location = new System.Drawing.Point(405, 430);
            this.LRText.Name = "LRText";
            this.LRText.Size = new System.Drawing.Size(269, 27);
            this.LRText.TabIndex = 9;
            this.LRText.Text = "Linear Regression Formula:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Prediction for 2018-2";
            // 
            // predictionLabel2
            // 
            this.predictionLabel2.AutoSize = true;
            this.predictionLabel2.Location = new System.Drawing.Point(17, 495);
            this.predictionLabel2.Name = "predictionLabel2";
            this.predictionLabel2.Size = new System.Drawing.Size(217, 27);
            this.predictionLabel2.TabIndex = 7;
            this.predictionLabel2.Text = "Prediction for 2018-2";
            // 
            // predictionYearLabel1
            // 
            this.predictionYearLabel1.AutoSize = true;
            this.predictionYearLabel1.Location = new System.Drawing.Point(17, 460);
            this.predictionYearLabel1.Name = "predictionYearLabel1";
            this.predictionYearLabel1.Size = new System.Drawing.Size(217, 27);
            this.predictionYearLabel1.TabIndex = 6;
            this.predictionYearLabel1.Text = "Prediction for 2018-1";
            // 
            // Split1
            // 
            this.Split1.BackColor = System.Drawing.Color.Silver;
            this.Split1.Location = new System.Drawing.Point(13, 454);
            this.Split1.Name = "Split1";
            this.Split1.Size = new System.Drawing.Size(691, 1);
            this.Split1.TabIndex = 5;
            this.Split1.Text = "label1";
            // 
            // PredictionsLabel
            // 
            this.PredictionsLabel.AutoSize = true;
            this.PredictionsLabel.Font = new System.Drawing.Font("Calibri", 15F);
            this.PredictionsLabel.Location = new System.Drawing.Point(13, 430);
            this.PredictionsLabel.Name = "PredictionsLabel";
            this.PredictionsLabel.Size = new System.Drawing.Size(128, 31);
            this.PredictionsLabel.TabIndex = 4;
            this.PredictionsLabel.Text = "Predictions";
            // 
            // SelectPositionLabel
            // 
            this.SelectPositionLabel.AutoSize = true;
            this.SelectPositionLabel.Font = new System.Drawing.Font("Calibri", 16F);
            this.SelectPositionLabel.Location = new System.Drawing.Point(12, 390);
            this.SelectPositionLabel.Name = "SelectPositionLabel";
            this.SelectPositionLabel.Size = new System.Drawing.Size(172, 33);
            this.SelectPositionLabel.TabIndex = 3;
            this.SelectPositionLabel.Text = "Select Position";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(161, 393);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 35);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // predictionLabel
            // 
            this.predictionLabel.AutoSize = true;
            this.predictionLabel.Font = new System.Drawing.Font("Calibri", 16F);
            this.predictionLabel.Location = new System.Drawing.Point(6, 15);
            this.predictionLabel.Name = "predictionLabel";
            this.predictionLabel.Size = new System.Drawing.Size(391, 33);
            this.predictionLabel.TabIndex = 1;
            this.predictionLabel.Text = "Future Predictions(2018.1-2018.3)";
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(3, 45);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(845, 342);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Location = new System.Drawing.Point(12, 677);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(172, 27);
            this.state_label.TabIndex = 3;
            this.state_label.Text = "infomation state:";
            // 
            // infomation_state
            // 
            this.infomation_state.AutoSize = true;
            this.infomation_state.Location = new System.Drawing.Point(190, 677);
            this.infomation_state.Name = "infomation_state";
            this.infomation_state.Size = new System.Drawing.Size(46, 27);
            this.infomation_state.TabIndex = 4;
            this.infomation_state.Text = "null";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 708);
            this.Controls.Add(this.infomation_state);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.table);
            this.Controls.Add(this.menubar);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MainMenuStrip = this.menubar;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpiderStorm plus";
            this.menubar.ResumeLayout(false);
            this.menubar.PerformLayout();
            this.table.ResumeLayout(false);
            this.job_chart_page.ResumeLayout(false);
            this.job_chart_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.job_chart)).EndInit();
            this.skill_tree_page.ResumeLayout(false);
            this.skill_tree_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radar_chart)).EndInit();
            this.linearRegressionPage.ResumeLayout(false);
            this.linearRegressionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menubar;
        private System.Windows.Forms.ToolStripMenuItem menuitem_start;
        private System.Windows.Forms.ToolStripMenuItem menu_func_catchInfo;
        private System.Windows.Forms.TabControl table;
        private System.Windows.Forms.TabPage job_chart_page;
        private System.Windows.Forms.DataVisualization.Charting.Chart job_chart;
        private System.Windows.Forms.TabPage skill_tree_page;
        private System.Windows.Forms.ListBox company_skill_list;
        private System.Windows.Forms.Label tree_view_label;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label infomation_state;
        private System.Windows.Forms.Label company_job_chart_label;
        private System.Windows.Forms.Label companyList_label;
        private System.Windows.Forms.ListBox company_job_list;
        private System.Windows.Forms.Label companyList_skill_label;
        private System.Windows.Forms.DataVisualization.Charting.Chart radar_chart;
        private System.Windows.Forms.TabPage linearRegressionPage;
        private System.Windows.Forms.Label SelectPositionLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label predictionLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label PredictionsLabel;
        private System.Windows.Forms.Label LRText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label predictionLabel2;
        private System.Windows.Forms.Label predictionYearLabel1;
        private System.Windows.Forms.Label Split1;
    }
}


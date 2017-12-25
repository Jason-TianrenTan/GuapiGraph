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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.menuitem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_func_catchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_show_compannylist = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.TabControl();
            this.job_chart_page = new System.Windows.Forms.TabPage();
            this.company_job_chart_label = new System.Windows.Forms.Label();
            this.companyList_label = new System.Windows.Forms.Label();
            this.company_job_list = new System.Windows.Forms.ListBox();
            this.job_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.skill_tree_page = new System.Windows.Forms.TabPage();
            this.tree_view_label = new System.Windows.Forms.Label();
            this.company_skill_list = new System.Windows.Forms.ListBox();
            this.state_label = new System.Windows.Forms.Label();
            this.infomation_state = new System.Windows.Forms.Label();
            this.companyList_skill_label = new System.Windows.Forms.Label();
            this.radar_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menubar.SuspendLayout();
            this.table.SuspendLayout();
            this.job_chart_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.job_chart)).BeginInit();
            this.skill_tree_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radar_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitem_start,
            this.menu_show});
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
            // menu_show
            // 
            this.menu_show.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_item_show_compannylist});
            this.menu_show.Name = "menu_show";
            this.menu_show.Size = new System.Drawing.Size(59, 24);
            this.menu_show.Text = "show";
            // 
            // menu_item_show_compannylist
            // 
            this.menu_item_show_compannylist.Name = "menu_item_show_compannylist";
            this.menu_item_show_compannylist.Size = new System.Drawing.Size(200, 26);
            this.menu_item_show_compannylist.Text = "show companys";
            this.menu_item_show_compannylist.Click += new System.EventHandler(this.menu_item_show_compannylist_Click);
            // 
            // table
            // 
            this.table.Controls.Add(this.job_chart_page);
            this.table.Controls.Add(this.skill_tree_page);
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
            this.job_chart_page.Text = "overview of jobs";
            // 
            // company_job_chart_label
            // 
            this.company_job_chart_label.AutoSize = true;
            this.company_job_chart_label.Location = new System.Drawing.Point(575, 59);
            this.company_job_chart_label.Name = "company_job_chart_label";
            this.company_job_chart_label.Size = new System.Drawing.Size(106, 27);
            this.company_job_chart_label.TabIndex = 6;
            this.company_job_chart_label.Text = "jobs chart";
            // 
            // companyList_label
            // 
            this.companyList_label.AutoSize = true;
            this.companyList_label.Location = new System.Drawing.Point(110, 81);
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
            this.company_job_list.Size = new System.Drawing.Size(389, 463);
            this.company_job_list.TabIndex = 4;
            // 
            // job_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.job_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.job_chart.Legends.Add(legend1);
            this.job_chart.Location = new System.Drawing.Point(452, 124);
            this.job_chart.Name = "job_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.job_chart.Series.Add(series1);
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
            this.skill_tree_page.Text = "skill tree analysis";
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
            this.company_skill_list.Size = new System.Drawing.Size(389, 463);
            this.company_skill_list.TabIndex = 2;
            this.company_skill_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skill_job_list_MouseDoubleClick);
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
            // companyList_skill_label
            // 
            this.companyList_skill_label.AutoSize = true;
            this.companyList_skill_label.Location = new System.Drawing.Point(129, 69);
            this.companyList_skill_label.Name = "companyList_skill_label";
            this.companyList_skill_label.Size = new System.Drawing.Size(133, 27);
            this.companyList_skill_label.TabIndex = 6;
            this.companyList_skill_label.Text = "company list";
            // 
            // radar_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.radar_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.radar_chart.Legends.Add(legend2);
            this.radar_chart.Location = new System.Drawing.Point(441, 118);
            this.radar_chart.Name = "radar_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.radar_chart.Series.Add(series2);
            this.radar_chart.Size = new System.Drawing.Size(385, 463);
            this.radar_chart.TabIndex = 7;
            this.radar_chart.Text = "radar_chart";
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
        private System.Windows.Forms.ToolStripMenuItem menu_show;
        private System.Windows.Forms.Label company_job_chart_label;
        private System.Windows.Forms.Label companyList_label;
        private System.Windows.Forms.ListBox company_job_list;
        private System.Windows.Forms.ToolStripMenuItem menu_item_show_compannylist;
        private System.Windows.Forms.Label companyList_skill_label;
        private System.Windows.Forms.DataVisualization.Charting.Chart radar_chart;
    }
}


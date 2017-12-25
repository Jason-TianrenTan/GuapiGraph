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
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.menuitem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_func_catchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.TabControl();
            this.job_chart_page = new System.Windows.Forms.TabPage();
            this.job_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.job_result_label = new System.Windows.Forms.Label();
            this.job_result_text = new System.Windows.Forms.TextBox();
            this.job_button_show = new System.Windows.Forms.Button();
            this.skill_tree_page = new System.Windows.Forms.TabPage();
            this.button_show_companyList = new System.Windows.Forms.Button();
            this.tree_panel = new System.Windows.Forms.Panel();
            this.tree_view_label = new System.Windows.Forms.Label();
            this.skill_job_list = new System.Windows.Forms.ListBox();
            this.state_label = new System.Windows.Forms.Label();
            this.infomation_state = new System.Windows.Forms.Label();
            this.menubar.SuspendLayout();
            this.table.SuspendLayout();
            this.job_chart_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.job_chart)).BeginInit();
            this.skill_tree_page.SuspendLayout();
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
            this.table.Location = new System.Drawing.Point(0, 41);
            this.table.Name = "table";
            this.table.SelectedIndex = 0;
            this.table.Size = new System.Drawing.Size(869, 633);
            this.table.TabIndex = 1;
            // 
            // job_chart_page
            // 
            this.job_chart_page.BackColor = System.Drawing.SystemColors.Control;
            this.job_chart_page.Controls.Add(this.job_chart);
            this.job_chart_page.Controls.Add(this.job_result_label);
            this.job_chart_page.Controls.Add(this.job_result_text);
            this.job_chart_page.Controls.Add(this.job_button_show);
            this.job_chart_page.Location = new System.Drawing.Point(4, 36);
            this.job_chart_page.Name = "job_chart_page";
            this.job_chart_page.Padding = new System.Windows.Forms.Padding(3);
            this.job_chart_page.Size = new System.Drawing.Size(861, 593);
            this.job_chart_page.TabIndex = 0;
            this.job_chart_page.Text = "overview of jobs";
            // 
            // job_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.job_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.job_chart.Legends.Add(legend1);
            this.job_chart.Location = new System.Drawing.Point(25, 125);
            this.job_chart.Name = "job_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.job_chart.Series.Add(series1);
            this.job_chart.Size = new System.Drawing.Size(771, 420);
            this.job_chart.TabIndex = 3;
            this.job_chart.Text = "job_cahrt";
            this.job_chart.Visible = false;
            // 
            // job_result_label
            // 
            this.job_result_label.AutoSize = true;
            this.job_result_label.Location = new System.Drawing.Point(20, 49);
            this.job_result_label.Name = "job_result_label";
            this.job_result_label.Size = new System.Drawing.Size(161, 27);
            this.job_result_label.TabIndex = 2;
            this.job_result_label.Text = "statistical result:";
            // 
            // job_result_text
            // 
            this.job_result_text.Location = new System.Drawing.Point(206, 46);
            this.job_result_text.Multiline = true;
            this.job_result_text.Name = "job_result_text";
            this.job_result_text.Size = new System.Drawing.Size(447, 39);
            this.job_result_text.TabIndex = 1;
            // 
            // job_button_show
            // 
            this.job_button_show.Location = new System.Drawing.Point(700, 46);
            this.job_button_show.Name = "job_button_show";
            this.job_button_show.Size = new System.Drawing.Size(96, 39);
            this.job_button_show.TabIndex = 0;
            this.job_button_show.Text = "show";
            this.job_button_show.UseVisualStyleBackColor = true;
            this.job_button_show.Click += new System.EventHandler(this.job_button_show_Click);
            // 
            // skill_tree_page
            // 
            this.skill_tree_page.BackColor = System.Drawing.SystemColors.Control;
            this.skill_tree_page.Controls.Add(this.button_show_companyList);
            this.skill_tree_page.Controls.Add(this.tree_panel);
            this.skill_tree_page.Controls.Add(this.tree_view_label);
            this.skill_tree_page.Controls.Add(this.skill_job_list);
            this.skill_tree_page.Location = new System.Drawing.Point(4, 36);
            this.skill_tree_page.Name = "skill_tree_page";
            this.skill_tree_page.Padding = new System.Windows.Forms.Padding(3);
            this.skill_tree_page.Size = new System.Drawing.Size(861, 593);
            this.skill_tree_page.TabIndex = 1;
            this.skill_tree_page.Text = "skill tree analysis";
            // 
            // button_show_companyList
            // 
            this.button_show_companyList.Location = new System.Drawing.Point(146, 64);
            this.button_show_companyList.Name = "button_show_companyList";
            this.button_show_companyList.Size = new System.Drawing.Size(86, 37);
            this.button_show_companyList.TabIndex = 0;
            this.button_show_companyList.Text = "show";
            this.button_show_companyList.UseVisualStyleBackColor = true;
            this.button_show_companyList.Click += new System.EventHandler(this.button_show_companyList_Click);
            // 
            // tree_panel
            // 
            this.tree_panel.Location = new System.Drawing.Point(436, 118);
            this.tree_panel.Name = "tree_panel";
            this.tree_panel.Size = new System.Drawing.Size(396, 463);
            this.tree_panel.TabIndex = 4;
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
            // skill_job_list
            // 
            this.skill_job_list.FormattingEnabled = true;
            this.skill_job_list.ItemHeight = 27;
            this.skill_job_list.Location = new System.Drawing.Point(17, 118);
            this.skill_job_list.Name = "skill_job_list";
            this.skill_job_list.Size = new System.Drawing.Size(389, 463);
            this.skill_job_list.TabIndex = 2;
            this.skill_job_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skill_job_list_MouseDoubleClick);
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
        private System.Windows.Forms.Label job_result_label;
        private System.Windows.Forms.TextBox job_result_text;
        private System.Windows.Forms.Button job_button_show;
        private System.Windows.Forms.TabPage skill_tree_page;
        private System.Windows.Forms.ListBox skill_job_list;
        private System.Windows.Forms.Panel tree_panel;
        private System.Windows.Forms.Label tree_view_label;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label infomation_state;
        private System.Windows.Forms.Button button_show_companyList;
    }
}


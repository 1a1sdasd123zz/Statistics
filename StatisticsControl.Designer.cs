namespace Statistics
{
    partial class StatisticsControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button clearButton; // 添加清零按钮成员变量

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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hourChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button(); // 初始化清零按钮
            ((System.ComponentModel.ISupportInitialize)(this.hourChart)).BeginInit();
            this.SuspendLayout();
            // 
            // hourChart
            // 
            this.hourChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hourChart.Location = new System.Drawing.Point(0, 30);
            this.hourChart.Name = "hourChart";
            this.hourChart.Size = new System.Drawing.Size(600, 320);
            this.hourChart.Location = new System.Drawing.Point(0, 70);
            this.hourChart.Name = "hourChart";
            this.hourChart.Size = new System.Drawing.Size(600, 280);
            this.hourChart.TabIndex = 0;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalLabel.Location = new System.Drawing.Point(0, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Padding = new System.Windows.Forms.Padding(5);
            this.totalLabel.Size = new System.Drawing.Size(101, 41);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "总量: 0";

            // StatisticsControl 设置
            this.Controls.Add(this.hourChart);
            // StatisticsControl 设置
            this.Controls.Add(this.hourChart);

            // clearButton 设置
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearButton.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearButton.Location = new System.Drawing.Point(0, 41);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(600, 40);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清零当前班次数据";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StatisticsControl
            // 
            this.Controls.Add(this.hourChart);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.totalLabel);
            this.Name = "StatisticsControl";
            this.Size = new System.Drawing.Size(600, 350);
            ((System.ComponentModel.ISupportInitialize)(this.hourChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

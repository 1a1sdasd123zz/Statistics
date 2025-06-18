namespace Statistics
{
    partial class StatisticsControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hourChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hourChart)).BeginInit();
            this.SuspendLayout();

            // hourChart 设置
            this.hourChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hourChart.Location = new System.Drawing.Point(0, 30);
            this.hourChart.Name = "hourChart";
            this.hourChart.Size = new System.Drawing.Size(600, 320);
            this.hourChart.TabIndex = 0;

            // totalLabel 设置
            this.totalLabel.AutoSize = true;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalLabel.Location = new System.Drawing.Point(0, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Padding = new System.Windows.Forms.Padding(5);
            this.totalLabel.Size = new System.Drawing.Size(113, 29);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "总量: 0";

            // StatisticsControl 设置
            this.Controls.Add(this.hourChart);
            this.Controls.Add(this.totalLabel);
            this.Name = "StatisticsControl";
            this.Size = new System.Drawing.Size(600, 350);
            ((System.ComponentModel.ISupportInitialize)(this.hourChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            InitializeChart();
        }

        #endregion
    }
}

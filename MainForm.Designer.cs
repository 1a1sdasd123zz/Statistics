using System.Windows.Forms;

namespace Statistics
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shiftTabControl = new System.Windows.Forms.TabControl();
            this.incrementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // shiftTabControl 设置
            this.shiftTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftTabControl.Location = new System.Drawing.Point(0, 40);
            this.shiftTabControl.Name = "shiftTabControl";
            this.shiftTabControl.SelectedIndex = 0;
            this.shiftTabControl.Size = new System.Drawing.Size(800, 410);
            this.shiftTabControl.TabIndex = 0;

            // incrementButton 设置
            this.incrementButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.incrementButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.incrementButton.Location = new System.Drawing.Point(0, 0);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(800, 40);
            this.incrementButton.TabIndex = 1;
            this.incrementButton.Text = "增加当前小时数据";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.IncrementButton_Click);

            // MainForm 设置
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shiftTabControl);
            this.Controls.Add(this.incrementButton);
            this.Name = "MainForm";
            this.Text = "数据统计系统";
            this.ResumeLayout(false);
        }

        #endregion

        private TabControl shiftTabControl;
        private StatisticsControl dayShiftControl;
        private StatisticsControl nightShiftControl;
        private Button incrementButton;
    }
}
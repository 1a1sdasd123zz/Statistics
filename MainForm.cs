using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeShiftTabs();
        }

        private void InitializeShiftTabs()
        {
            // 创建白班Tab页
            TabPage dayShiftPage = new TabPage("白班 (8:00-20:00)");
            dayShiftControl = new StatisticsControl();
            dayShiftControl.SetShiftType(StatisticsControl.ShiftType.DayShift);
            dayShiftControl.Dock = DockStyle.Fill;
            dayShiftPage.Controls.Add(dayShiftControl);
            shiftTabControl.TabPages.Add(dayShiftPage);

            // 创建夜班Tab页
            TabPage nightShiftPage = new TabPage("夜班 (20:00-8:00)");
            nightShiftControl = new StatisticsControl();
            nightShiftControl.SetShiftType(StatisticsControl.ShiftType.NightShift);
            nightShiftControl.Dock = DockStyle.Fill;
            nightShiftPage.Controls.Add(nightShiftControl);
            shiftTabControl.TabPages.Add(nightShiftPage);
        }

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            // 根据当前时间增加对应班次的数据
            int currentHour = DateTime.Now.Hour;

            if (currentHour >= 8 && currentHour < 20)
            {
                dayShiftControl.IncrementCurrentHour();
                MessageBox.Show("已增加白班当前小时数据");
            }
            else
            {
                nightShiftControl.IncrementCurrentHour();
                MessageBox.Show("已增加夜班当前小时数据");
            }
        }
    }
}

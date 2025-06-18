using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Statistics
{
    public partial class StatisticsControl : UserControl
    {
        private Chart hourChart;
        private Label totalLabel;
        private List<int> hourData;
        private int totalCount;
        private ShiftType currentShift;

        public enum ShiftType
        {
            DayShift,  // 白班 (8:00-20:00)
            NightShift // 夜班 (20:00-8:00)
        }

        public StatisticsControl()
        {
            InitializeComponent();
            ResetData();
            InitializeChart();
        }


        private void InitializeChart()
        {
            // 设置图表区域
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "小时";
            chartArea.AxisY.Title = "数量";
            hourChart.ChartAreas.Add(chartArea);

            // 设置系列
            Series series = new Series("数据");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(78, 154, 236);
            series.IsValueShownAsLabel = true; // 显示数据标签
            hourChart.Series.Add(series);

            // 设置标题
            Title title = new Title("每小时数据统计", Docking.Top, new Font("Microsoft YaHei", 12F, FontStyle.Bold), Color.Black);
            hourChart.Titles.Add(title);
        }

        public void SetShiftType(ShiftType shiftType)
        {
            currentShift = shiftType;
            ResetData();
            UpdateChart();
        }

        private void ResetData()
        {
            hourData = new List<int>();

            if (currentShift == ShiftType.DayShift)
            {
                // 白班: 8点到20点
                for (int i = 0; i < 12; i++)
                    hourData.Add(0);
            }
            else
            {
                // 夜班: 20点到8点
                for (int i = 0; i < 12; i++)
                    hourData.Add(0);
            }

            totalCount = 0;
            UpdateTotalLabel();
        }

        public void IncrementCurrentHour()
        {
            int currentHour = DateTime.Now.Hour;
            int dataIndex;

            if (currentShift == ShiftType.DayShift)
            {
                if (currentHour < 8 || currentHour >= 20)
                    return; // 非白班时间

                dataIndex = currentHour - 8;
            }
            else
            {
                if (currentHour >= 8 && currentHour < 20)
                    return; // 非夜班时间

                dataIndex = currentHour >= 20 ? currentHour - 20 : currentHour + 4;
            }

            if (dataIndex >= 0 && dataIndex < hourData.Count)
            {
                hourData[dataIndex]++;
                totalCount++;
                UpdateTotalLabel();
                UpdateChart();
            }
        }

        private void UpdateTotalLabel()
        {
            totalLabel.Text = $"总量: {totalCount}";
        }

        private void UpdateChart()
        {
            hourChart.Series[0].Points.Clear();

            if (currentShift == ShiftType.DayShift)
            {
                for (int i = 0; i < 12; i++)
                {
                    int hour = i + 8;
                    // 添加数据点
                    hourChart.Series[0].Points.AddXY($"{hour:00}:00", hourData[i]);
                    // 通过索引获取新添加的数据点
                    DataPoint point = hourChart.Series[0].Points[hourChart.Series[0].Points.Count - 1];
                    point.Label = hourData[i].ToString(); // 设置数据标签
                    point.Color = Color.Green;
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    int hour = i >= 4 ? i - 4 : i + 20;
                    // 添加数据点
                    hourChart.Series[0].Points.AddXY($"{hour:00}:00", hourData[i]);
                    // 通过索引获取新添加的数据点
                    DataPoint point = hourChart.Series[0].Points[hourChart.Series[0].Points.Count - 1];
                    point.Label = hourData[i].ToString(); // 设置数据标签
                    point.Color = Color.Green;
                }
                }

            // 设置 Y 轴标签格式为整数
            hourChart.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResetData();
            UpdateChart();
            MessageBox.Show("当前班次数据已清零");
        }
    }
}
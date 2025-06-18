using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

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
            DayShift, // 白班 (8:00-20:00)
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

            // 设置 X 轴标签间隔为 1
            chartArea.AxisX.Interval = 1;

            hourChart.ChartAreas.Add(chartArea);

            // 设置系列
            Series series = new Series("数据");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(78, 154, 236);
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
            LoadData();
            if (hourData == null)
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
            }
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
                SaveData();
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
            SaveData();
        }

        private void SaveData()
        {
            string filePath = GetDataFilePath();
            var data = new
            {
                HourData = hourData,
                TotalCount = totalCount
            };
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        private void LoadData()
        {
            string filePath = GetDataFilePath();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                hourData = new List<int>();
                foreach (var item in data.HourData)
                {
                    hourData.Add((int)item);
                }
                totalCount = (int)data.TotalCount;
            }
        }

        private string GetDataFilePath()
        {
            string shiftName = currentShift == ShiftType.DayShift ? "DayShift" : "NightShift";
            return Path.Combine(Application.StartupPath, $"{shiftName}_Data.json");
        }
    }
}
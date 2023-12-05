using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;

namespace WpfApptemper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
           
            dayComboBox.Items.Add("Понедельник");
            dayComboBox.Items.Add("Вторник");
            dayComboBox.Items.Add("Среда");
            dayComboBox.Items.Add("Четверг");
            dayComboBox.Items.Add("Пятница");
            dayComboBox.Items.Add("Суббота");
            dayComboBox.Items.Add("Всокресенье");
            InitializePlotModel();
        }

        private void InitializePlotModel()
        {
            plotModel = new PlotModel();
            var series = new LineSeries();
            series.Points.Add(new DataPoint(0, 0));
            series.Points.Add(new DataPoint(1, 1));
            plotModel.Series.Add(series);

            temperatureChart.Model = plotModel;
        }

        private void DayComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedDay = (dayComboBox.SelectedItem as string);
            UpdateTemperatureChart(selectedDay);
        }

        private void UpdateTemperatureChart(string selectedDay)
        {
            plotModel.Series.Clear();

           
            var series = new LineSeries();

           
            for (int hour = 0; hour < 24; hour++)
            {
                
                double temperature = new Random().Next(10, 30);
                series.Points.Add(new DataPoint(hour, temperature));
            }

            // Добавляем линию к графику
            plotModel.Series.Add(series);

            // Обновляем график
            temperatureChart.InvalidatePlot(true);
        }
    }
}
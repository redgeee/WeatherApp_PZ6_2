using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            List<Weather> _dataWeatherFind = _weather.Weathers.Where(x => x.CityName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            WeatherDataGrid.DataSource = textBox1.Text == "" ? _weather.Weathers.ToList() : _dataWeatherFind;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            List<Weather> _dataWeatherFind = _weather.Weathers.Where(x => ((int)x.MeasureUnit) == comboBox1.SelectedIndex).ToList();
            WeatherDataGrid.DataSource = _dataWeatherFind;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            comboBox1.SelectedIndex = 3;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            List<Weather> _dataWeatherFind = _weather.Weathers.Where(x => x.Temperature >= 0).ToList();
            WeatherDataGrid.DataSource = _dataWeatherFind;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            List<Weather> _dataWeatherFind = _weather.Weathers.OrderByDescending(x => x.Temperature).ToList();
            WeatherDataGrid.DataSource = _dataWeatherFind;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WeatherAppFinal.Models;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Devices.Common;

namespace WeatherAppFinal
{
    public partial class MainPage : ContentPage
    {
        private LocationViewModel Model;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LocationViewModel();
            Model = new LocationViewModel();
        }
        private async void searchData_SearchButtonPressed(object sender, EventArgs e)
        {
            var data = searchData.Text;
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={data}&appid=65729266b67bb641932f9f13a49fc8bc";

            var result = await ApiCall.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<Rootobject>(result.Response);
                    var celsius = weatherInfo.main.temp - 273.15;
                    mainTemp.Text = $"{celsius.ToString("0.0")}°";
                    mainCondition.Text = weatherInfo.weather[0].description.ToUpper();
                    mainIcon.Source = $"w{weatherInfo.weather[0].icon}";
                    mainLocation.Text = weatherInfo.name.ToUpper();
                    wind.Text = $"{weatherInfo.wind.speed} m/s";
                    pressure.Text = $"{weatherInfo.main.pressure} hpa";
                    humidity.Text = $"{weatherInfo.main.humidity}";
                    cloudiness.Text = $"{weatherInfo.clouds.all} %";

                    var date = new DateTime().ToUniversalTime().AddSeconds(weatherInfo.dt);
                    mainTime.Text = date.ToString("dddd MMM dd").ToUpper();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
                await DisplayAlert("Alert", "no Info", "Ok");
        }
    }
}

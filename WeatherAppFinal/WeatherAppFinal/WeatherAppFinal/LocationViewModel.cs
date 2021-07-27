using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherAppFinal.Models;

namespace WeatherAppFinal
{
    public class LocationViewModel:INotifyPropertyChanged
    {

        private string country;
        public event PropertyChangedEventHandler PropertyChanged;
        public LocationViewModel()
        {
            var loc = new Location()
            {
                Country = CountryName
            };
        }
        public string CountryName  
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("CountryName");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shell : ContentPage
    {
        public Shell()
        {
            InitializeComponent();
        }
    }
}
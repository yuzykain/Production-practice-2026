using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AutoPodbor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                MainPage = new MainPage();
            }
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
   
    }
}

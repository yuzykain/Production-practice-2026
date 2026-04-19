using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AutoPodbor
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public static bool isAuth;
        public static string login;
        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            var current = Connectivity.NetworkAccess;
            isAuth = false;
            if (current == NetworkAccess.Internet)
            {
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")))
                {
                    Children.Add(new LoginingProfile());
                    isAuth = true;
                    login = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
                }
                else
                    Children.Add(new Profile());

                Children.Add(new Main());

                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")))
                {
                    CurrentPage = Children[1];
                }
            }
        }
    }
}

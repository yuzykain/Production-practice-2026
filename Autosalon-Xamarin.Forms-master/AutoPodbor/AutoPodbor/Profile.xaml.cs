using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoPodbor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private async void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Authorization());
        }
    }
}
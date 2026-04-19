using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoPodbor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            if (Account.Authorization(loginText.Text, passText.Text))
            {
                (Application.Current).MainPage = new MainPage();
            }
            else
            {
                await DisplayAlert("⚠ Ошибка!", "Введены неверные данные!", "OK");
            }

        }
    }
}
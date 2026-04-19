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
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            InputCars(Account.CheckFavorites(MainPage.login));
        }
        private void InputCars(List<Car> sortedCars)
        {
            if (sortedCars.Count == 0)
            {
                Frame1.IsVisible = false;
                Frame2.IsVisible = false;
                Frame3.IsVisible = false;
                Frame4.IsVisible = false;
                Frame5.IsVisible = false;
            }
            else if (sortedCars.Count == 1)
            {
                Frame1.IsVisible = true;
                Frame2.IsVisible = false;
                Frame3.IsVisible = false;
                Frame4.IsVisible = false;
                Frame5.IsVisible = false;
            }
            else if (sortedCars.Count == 2)
            {
                Frame1.IsVisible = true;
                Frame2.IsVisible = true;
                Frame3.IsVisible = false;
                Frame4.IsVisible = false;
                Frame5.IsVisible = false;
            }
            else if (sortedCars.Count == 3)
            {
                Frame1.IsVisible = true;
                Frame2.IsVisible = true;
                Frame3.IsVisible = true;
                Frame4.IsVisible = false;
                Frame5.IsVisible = false;
            }
            else if (sortedCars.Count == 4)
            {
                Frame1.IsVisible = true;
                Frame2.IsVisible = true;
                Frame3.IsVisible = true;
                Frame4.IsVisible = true;
                Frame5.IsVisible = false;
            }
            else if (sortedCars.Count == 5)
            {
                Frame1.IsVisible = true;
                Frame2.IsVisible = true;
                Frame3.IsVisible = true;
                Frame4.IsVisible = true;
                Frame5.IsVisible = true;
            }
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedCars[i].Mark + " " + sortedCars[i].Generation;
                        DiscriptionLabel_1.Text = sortedCars[i].Description;
                        AutoImg_1.Source = sortedCars[i].UrlImg;
                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = sortedCars[i].Mark + " " + sortedCars[i].Generation;
                        DiscriptionLabel_2.Text = sortedCars[i].Description;
                        AutoImg_2.Source = sortedCars[i].UrlImg;
                    }
                    if (i == 2)
                    {
                        NameLabel_3.Text = sortedCars[i].Mark + " " + sortedCars[i].Generation;
                        DiscriptionLabel_3.Text = sortedCars[i].Description;
                        AutoImg_3.Source = sortedCars[i].UrlImg;
                    }
                    if (i == 3)
                    {
                        NameLabel_4.Text = sortedCars[i].Mark + " " + sortedCars[i].Generation;
                        DiscriptionLabel_4.Text = sortedCars[i].Description;
                        AutoImg_4.Source = sortedCars[i].UrlImg;
                    }
                    if (i == 4)
                    {
                        NameLabel_5.Text = sortedCars[i].Mark + " " + sortedCars[i].Generation;
                        DiscriptionLabel_5.Text = sortedCars[i].Description;
                        AutoImg_5.Source = sortedCars[i].UrlImg;
                    }
                }
            }
            catch { }
        }

        private async void moreButton_1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoreInfo(Account.CheckFavorites(MainPage.login).FindAll(x => (x.Mark + " " + x.Generation) == NameLabel_1.Text).ToList()[0]));
        }

        private async void moreButton_2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoreInfo(Account.CheckFavorites(MainPage.login).FindAll(x => (x.Mark + " " + x.Generation) == NameLabel_2.Text).ToList()[0]));
        }

        private async void moreButton_3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoreInfo(Account.CheckFavorites(MainPage.login).FindAll(x => (x.Mark + " " + x.Generation) == NameLabel_3.Text).ToList()[0]));
        }

        private async void moreButton_4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoreInfo(Account.CheckFavorites(MainPage.login).FindAll(x => (x.Mark + " " + x.Generation) == NameLabel_4.Text).ToList()[0]));

        }

        private async void moreButton_5_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoreInfo(Account.CheckFavorites(MainPage.login).FindAll(x => (x.Mark + " " + x.Generation) == NameLabel_5.Text).ToList()[0]));
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            InputCars(Account.CheckFavorites(MainPage.login));
            refresh.IsRefreshing = false;
        }
    }
}
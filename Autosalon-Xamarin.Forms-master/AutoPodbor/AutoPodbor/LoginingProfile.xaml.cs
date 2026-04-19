using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoPodbor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginingProfile : ContentPage
    {
        public LoginingProfile()
        {
            InitializeComponent();
            nameText.Text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
            List<Request> requests = Request.AccountRequests(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")));
            requestsList.ItemsSource = requests.Select(n => n.ListViewText);
            if (File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")) == "W1zik")
            {
                adminButton.IsVisible = true;
            }
        }

        private void exitButton_Clicked(object sender, EventArgs e)
        {
            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
            (Application.Current).MainPage = new MainPage();

        }

        private async void adminButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminPanel());
        }

        private void requestsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void refresh_Refreshing(object sender, EventArgs e)
        {
            List<Request> requests = Request.AccountRequests(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")));
            requestsList.ItemsSource = requests.Select(n => n.ListViewText);
            refresh.IsRefreshing = false;
        }
    }
}
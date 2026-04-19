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
    public partial class AdminPanel : ContentPage
    {
        List<Request> req = Request.ReadRequests();
        public AdminPanel()
        {
            InitializeComponent();
            requestsList.ItemsSource = req.Select(n => n.ListViewText);
        }

        private async void requestsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var res = await DisplayAlert($"Заявка №{req[e.ItemIndex].Id}",
                $"Машина ID - {req[e.ItemIndex].Id_car}\n" +
                $"Пользователь - {req[e.ItemIndex].Login}[{req[e.ItemIndex].Id_account}]\n" +
                $"Дата и время - {req[e.ItemIndex].Date}", "Одобрить","Отклонить" );
            Request.SetState(res, req[e.ItemIndex].Id);
        }

        private void refresh_Refreshing(object sender, EventArgs e)
        {
            req = Request.ReadRequests();
            requestsList.ItemsSource = req.Select(n => n.ListViewText);
            refresh.IsRefreshing = false;
        }
    }
}
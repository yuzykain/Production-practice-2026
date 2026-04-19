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
    public partial class MoreInfo : ContentPage
    {
        private int carID;
        public MoreInfo(Car car)
        {
            InitializeComponent();
            if (car != null)
            {
                mark.Text = car.Mark + " " + car.Generation;
                img.Source = car.UrlImg;
                description.Text = car.Description;
                years.Text = car.YearStart + "-" + car.YearEnd;
                price.Text = car.Price + "$";
                engineVolume.Text= car.EngineVolume+" л";
                transmision.Text = car.Transmission;
                body.Text = car.Body;
                engine.Text = car.Engine;
                wheelDrive.Text = car.WheelDrive;
            }
            carID = car.Id;
        }

        private async void testDriveButton_Clicked(object sender, EventArgs e)
        {
            string time = DateTime.Now.AddHours(4).ToString("dd.MM.yy HH:mm");
            if (MainPage.isAuth)
            {
                string result = await DisplayPromptAsync("Запись на тест-драйв", "Напишите дату и время для тест-драйва.\nПример: ДД.ММ.ГГ ЧЧ:ММ \n После отправления заявки вам придёт ответ от администратора в профиль.",initialValue: time, maxLength: 14, keyboard: Keyboard.Text);
                if(result.Length>=10)
                    Request.WriteRequest(new Request(0, 0, carID, MainPage.login, "0", 0, "0", result, "0"));
                else
                    DisplayAlert("Ошибка!", "Введена неверная дата!", "ОК");

            }
            else
                DisplayAlert("Ошибка!", "Сначало войдите в аккаунт!", "ОК");

        }
    }
}
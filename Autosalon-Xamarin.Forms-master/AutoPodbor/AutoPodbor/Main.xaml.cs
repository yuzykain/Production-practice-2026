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
    public partial class Main : ContentPage
    {
        private List<Car> carsList = new List<Car>();
        private Random RND = new Random();
        
        public Main()
        {
            InitializeComponent();
            
            Car car = new Car();
            carsList = car.ReadCars(carsList);
            RandomViewCars();
        }
        private void RandomViewCars()
        {
            try
            {
                int[] mas = new int[carsList.Count];
                mas = Enumerable.Range(1, carsList.Count - 1)
                .OrderBy(_ => RND.NextDouble())
                .Take(10).ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR!!!");
            }
        }
           // string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null,cars.ForEach(p=>p.ToString()));
    }
}

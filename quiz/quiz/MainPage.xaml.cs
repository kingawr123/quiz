using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace quiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pytanieModel = FabrykaPytan.UtworzPytanie1();

            var pytanie = new Pytanie(pytanieModel);

            await App.Current.MainPage.Navigation.PushAsync(pytanie);
            Navigation.RemovePage(this);
        }
    }
}

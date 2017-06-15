using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quiz
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KoniecQuizu : ContentPage
    {
        public KoniecQuizu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LiczbaPunktow.Text = App.PunktyTekst();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);

            App.Punkty = 0;
        }
    }
}
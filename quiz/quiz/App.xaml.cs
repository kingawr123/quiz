using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace quiz
{
    public partial class App : Application
    {
        public static int Punkty { get; set; }

        public static string PunktyTekst() => "Twoja ilość punktów to: " + Punkty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new quiz.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            App.Punkty = 0;
        }
    }
}

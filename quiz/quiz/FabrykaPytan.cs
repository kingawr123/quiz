using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace quiz
{
    public static class FabrykaPytan
    {
        public static PytanieModel UtworzPytanie1()
        {
            return UtworzPytanie(
                "O czym jest ten quiz?",
                "O Władcy Pierścieni",
                "O Harrym Potterze",
                "O Krzyżakach",
                2,
                UtworzPytanie2);
        }

        public static PytanieModel UtworzPytanie2()
        {
            return UtworzPytanie(
                "Jak miał na imię znienawidzony przez Harrego nauczyciel eliksirów?",
                "Slughorn",
                "Albus",
                "Severus",
                3,
                UtworzPytanie3);
        }

        public static PytanieModel UtworzPytanie3()
        {
            return UtworzPytanie(
                "Który horkruks został zniszczony jako ostatni?",
                "Harry",
                "Nagini",
                "Diadem Roweny",
                2,
                UtworzPytanie4);
        }

        public static PytanieModel UtworzPytanie4()
        {
            return UtworzPytanie(
                "Jakie stworzenia ciągneły powozy do Hogwaru?",
                "Testrale",
                "Hipogryfy",
                "Konie",
                1,
                UtworzPytanie5);
        }

        public static PytanieModel UtworzPytanie5()
        {
            return UtworzPytanie(
                "Jak nazywali się rodzice najlepszego przyjaciela Harrego?",
                "James i Lily",
                "Remus i Tonks",
                "Molly i Artur",
                3,
                UtworzPytanie6);
        }

        public static PytanieModel UtworzPytanie6()
        {
            return UtworzPytanie(
                "Jakiego modelu była pierwsza miotła Harrego?",
                "Nimbus 2001",
                "Błyskawica",
                "Nimbus 2000",
                3,
                UtworzPytanie7);
        }

        public static PytanieModel UtworzPytanie7()
        {
            return UtworzPytanie(
                "Jakie zwierzę było w herbie Hufflepuff?",
                "Szop",
                "Borsuk",
                "Skunks",
                2,
                UtworzPytanie8,
                czyKoniec: false);
        }

        public static PytanieModel UtworzPytanie8()
        {
            return UtworzPytanie(
                "Jak nazywał się dom Rona?",
                "Nora",
                "Muszelka",
                "Dziupla",
                2,
                null,
                czyKoniec: true);
        }

        private static PytanieModel UtworzPytanie(
            string tekst,
            string odp1,
            string odp2,
            string odp3,
            int numerDobrejOdpowiedzi, //musi być od 1 do 3
            Func<PytanieModel> nastepnePytanie,
            bool czyKoniec = false
            )
        {
            return new PytanieModel(
                    tekst: tekst,
                    odp1: odp1,
                    odp2: odp2,
                    odp3: odp3,
                    odp1komenda: new Command(async () =>
                    {
                        await UtworzKomende(numerDobrejOdpowiedzi, 1, nastepnePytanie, czyKoniec);
                    }),
                    odp2komenda: new Command(async () =>
                    {
                        await UtworzKomende(numerDobrejOdpowiedzi, 2, nastepnePytanie, czyKoniec);
                    }),
                    odp3komenda: new Command(async () =>
                    {
                        await UtworzKomende(numerDobrejOdpowiedzi, 3, nastepnePytanie, czyKoniec);
                    })
                    );
        }

        private static async Task UtworzKomende(int numerDobrejOdpowiedzi, int numerOdpowiedzi, Func<PytanieModel> nastepnePytanie, bool czyKoniec)
        {
            if (numerDobrejOdpowiedzi == numerOdpowiedzi)
            {
                App.Punkty++;
                await App.Current.MainPage.DisplayAlert("Dobra odpowiedź", App.PunktyTekst(), "OK");
                if (!czyKoniec)
                {
                    var oldPage = (App.Current.MainPage as NavigationPage).CurrentPage;
                    await App.Current.MainPage.Navigation.PushAsync(new Pytanie(nastepnePytanie()));
                    App.Current.MainPage.Navigation.RemovePage(oldPage);
                }
                else
                {
                    var oldPage = (App.Current.MainPage as NavigationPage).CurrentPage;
                    await App.Current.MainPage.Navigation.PushAsync(new KoniecQuizu());
                    App.Current.MainPage.Navigation.RemovePage(oldPage);
                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Zła odpowiedź", App.PunktyTekst(), "OK");
                if (!czyKoniec)
                {
                    var oldPage = (App.Current.MainPage as NavigationPage).CurrentPage;
                    await App.Current.MainPage.Navigation.PushAsync(new Pytanie(nastepnePytanie()));
                    App.Current.MainPage.Navigation.RemovePage(oldPage);
                }
                else
                {
                    var oldPage = (App.Current.MainPage as NavigationPage).CurrentPage;
                    await App.Current.MainPage.Navigation.PushAsync(new KoniecQuizu());
                    App.Current.MainPage.Navigation.RemovePage(oldPage);
                }
            }
        }
    }
}

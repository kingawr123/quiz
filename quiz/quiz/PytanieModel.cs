using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz
{
    public class PytanieModel
    {
        public PytanieModel(string tekst, string odp1, string odp2, string odp3, ICommand odp1komenda, ICommand odp2komenda, ICommand odp3komenda)
        {
            TekstPytania = tekst;
            Odpowiedz1 = odp1;
            Odpowiedz2 = odp2;
            Odpowiedz3 = odp3;
            Odpowiedz1Komenda = odp1komenda;
            Odpowiedz2Komenda = odp2komenda;
            Odpowiedz3Komenda = odp3komenda;
        }

        public string TekstPytania { get; set; }
        public string Odpowiedz1 { get; set; }
        public string Odpowiedz2 { get; set; }
        public string Odpowiedz3 { get; set; }

        public ICommand Odpowiedz1Komenda { get; set; }

        public ICommand Odpowiedz2Komenda { get; set; }

        public ICommand Odpowiedz3Komenda { get; set; }

    }
}

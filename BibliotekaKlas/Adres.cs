using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaKlas
{
    public class Adres
    {
        private string ulica;  // Stworzenie prywatnych pól 
        private string numerDomu;
        private string miasto;
        public string Ulica     // Stworzenie publicznych właściwości zwracających i ustawiających warości
        {
            get { return ulica; }
            set { ulica = value; }
        }
        public string NumerDomu
        {
            get { return numerDomu; }
            set { numerDomu = value; }
        }
        public string Miasto
        {
            get { return miasto; }
            set { miasto = value; }
        }
        public Adres() // Bezargumentowy konstruktor domyślny 
        {
            ulica = "";
            numerDomu = "";
            miasto = "";
        }
        public Adres(string ulica, string numerDomu, string miasto) // Konstruktro z wszystkimi polami składowymi
        {
            this.ulica = ulica;
            this.numerDomu = numerDomu;
            this.miasto = miasto;
        }
        public Adres(Adres konstruktorKopiujacyAdres) // Konstruktor kopiujący 
        {
            this.ulica = konstruktorKopiujacyAdres.ulica;
            this.numerDomu = konstruktorKopiujacyAdres.numerDomu;
            this.miasto = konstruktorKopiujacyAdres.miasto;

        }
        public override string ToString() // Metoda zwraca łańcuch opisujący Adres
        {
            return string.Format(" {0} {1} {2} ", ulica, numerDomu, miasto);
        }
    }
}

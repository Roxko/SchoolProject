using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaKlas
{
    public class Sortowanie
    {
        public class PoNazwisku : IComparer<Pracownik> // Sortowanko dzięki interfejsowi IComparable
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }
        }

        public class PoZawodzie : IComparer<Pracownik> // Ta metoda porownoje ze soba 2 zmienne co pozwala sortowanko
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Zawod.CompareTo(y.Zawod);
            }
        }

        public class PoImieniu : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Imie.CompareTo(y.Imie);
            }
        }

        public class PodataUrodzeniaDzien : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.DataUrodzenia.Dzien.CompareTo(y.DataUrodzenia.Dzien);
            }
        }

        public class PodataUrodzeniaMiesiac : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.DataUrodzenia.Miesiac.CompareTo(y.DataUrodzenia.Miesiac);
            }
        }

        public class PodataUrodzeniaRok : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.DataUrodzenia.Rok.CompareTo(y.DataUrodzenia.Rok);
            }
        }

        public class PoadresZamieszkaniaUlica : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.AdresZamieszkania.Ulica.CompareTo(y.AdresZamieszkania.Ulica);
            }
        }

        public class PoadresZamieszkaniaNumerDomu : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.AdresZamieszkania.NumerDomu.CompareTo(y.AdresZamieszkania.NumerDomu);
            }
        }

        public class PoadresZamieszkaniaMiasto : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.AdresZamieszkania.Miasto.CompareTo(y.AdresZamieszkania.Miasto);
            }
        }
    }
}
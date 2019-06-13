using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaKlas
{
    public class Data
    {
        private int dzien;
        private int miesiac;
        private int rok;
        private static readonly string[] miesiace =
        { "styczeń", "luty", "marzec", "kwiecień", "maj", "czerwiec", "lipiec",
          "sierpień", "wrzesień", "październik", "listopad", "grudzień" };
        public int Dzien
        {
            get { return dzien; }
            set { dzien = value; }
        }
        public int Miesiac
        {
            get { return miesiac; }
            set { miesiac = value; }
        }
        public int Rok  // To samo co w dacie stworzenie prywatnych pol i publicznych właściwości w celu Hermetyzacji danych
        {
            get { return rok; }
            set { rok = value; }
        }
        public Data()
        {
            dzien = 1;
            miesiac = 1;
            rok = 2012;
        }
        public Data(int dzien, int miesiac, int rok)
        {
            this.dzien = dzien;
            this.miesiac = miesiac;
            this.rok = rok;
        }
        public Data(Data konstuktorKopiujacyData)  // Konstruktoy odpowiednio bezparametryczny / parametryczny / kopiujący
        {
            this.dzien = konstuktorKopiujacyData.dzien;
            this.miesiac = konstuktorKopiujacyData.miesiac;
            this.rok = konstuktorKopiujacyData.rok;

        }
        public override string ToString()
        {
            return string.Format(" {0} {1} {2} ", dzien, ZwrocMiesiac(miesiac), rok);
        }

        public static string ZwrocMiesiac(int miesiac)
        {
            if (miesiac < 1)
                miesiac = 1;
            if (miesiac > 12)
                miesiac = 12;
            return miesiace[miesiac - 1];
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BibliotekaKlas
{
    public class Lekarz : Pracownik // Tak samo jak w przypadku Informatyka 
    {
        string specjalizacja;
        string tytul;
        public string Specjalizacja
        {
            get { return specjalizacja; }
            set { specjalizacja = value; }
        }
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }
        public override Zawody Zawod
        {
            get { return Zawody.Lekarz; }
        }

        public Lekarz()
            : base()
        {
            specjalizacja = "";
            tytul = "";
        }

        public Lekarz(string imie, string nazwisko, int dzien, int miesiac, int rok, string ulica, string numerDomu, string miasto, string specjalizacja, string tytul) :
            base(imie, nazwisko, dzien, miesiac, rok, ulica, numerDomu, miasto)
        {
            this.specjalizacja = specjalizacja;
            this.tytul = tytul;
        }

        public Lekarz(Pracownik p, string specjalizacja, string tytul) : base(p)
        {
            this.specjalizacja = specjalizacja;
            this.tytul = tytul;
        }

        public Lekarz(Lekarz konstruktorKopiujacyLekarz) :
            base(konstruktorKopiujacyLekarz)
        {
            this.specjalizacja = konstruktorKopiujacyLekarz.specjalizacja;
            this.tytul = konstruktorKopiujacyLekarz.tytul;
        }

        public override Pracownik Clone()
        {
            return new Lekarz(this);
        }

        public override string SzczegolyZawodu()
        {
            return string.Format(" {0}\t{1} ", specjalizacja, tytul);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), SzczegolyZawodu());
        }

        public override string FormatWyjsciowy()
        {
            return string.Format("Zawód: {0}\n{1}\nDane dodatkowe: {2}", this.Zawod, base.FormatWyjsciowy(), SzczegolyZawodu());
        }

        public override void OdczytConsole()
        {
            base.OdczytConsole();
            System.Console.Write("Podaj specjalizację(lekarz): ");
            this.specjalizacja = System.Console.ReadLine();
            System.Console.Write("Podaj tytul(lekarz): ");
            this.tytul = System.Console.ReadLine();
        }

        public override void ZapisConsole()
        {
            System.Console.WriteLine(base.FormatWyjsciowy());
            System.Console.WriteLine(FormatWyjsciowy());
        }

        public override void OdczytXml(DataRow dr)
        {
            base.OdczytXml(dr);
            string[] szczegolyZawodu = dr.ItemArray[4].ToString().Split('\t');
            this.specjalizacja = szczegolyZawodu[0];
            this.tytul = szczegolyZawodu[1];
        }
    }
}

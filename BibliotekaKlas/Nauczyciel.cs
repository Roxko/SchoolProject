using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BibliotekaKlas
{
    public class Nauczyciel : Pracownik //Tak samo jak w przypadku Informatyka
    {

        string przedmiot;
        string tytul;

        public string Przedmiot
        {
            get { return przedmiot; }
            set { przedmiot = value; }
        }

        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        public override Zawody Zawod
        {
            get { return Zawody.Nauczyciel; }
        }

        public Nauczyciel() : base()
        {
            przedmiot = "";
            tytul = "";
        }

        public Nauczyciel(Pracownik p, string przedmiot, string tytul) : base(p)
        {
            this.przedmiot = przedmiot;
            this.tytul = tytul;
        }

        public Nauczyciel(string imie, string nazwisko, int dzien, int miesiac, int rok, string ulica, string numerDomu, string miasto, string przedmiot, string tytul) :
            base(imie, nazwisko, dzien, miesiac, rok, ulica, numerDomu, miasto)
        {
            this.przedmiot = przedmiot;
            this.tytul = tytul;
        }

        public Nauczyciel(Nauczyciel konstruktorKopiujacyNauczyciel) :
            base(konstruktorKopiujacyNauczyciel)
        {
            this.przedmiot = konstruktorKopiujacyNauczyciel.przedmiot;
            this.tytul = konstruktorKopiujacyNauczyciel.tytul;
        }

        public override Pracownik Clone()
        {
            return new Nauczyciel(this);

        }

        public override string SzczegolyZawodu()
        {
            return string.Format(" {0}\t{1} ", przedmiot, tytul);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), this.SzczegolyZawodu());
        }

        public override string FormatWyjsciowy()
        {
            return string.Format("Zawód: {0}\n{1}\nDane dodatkowe: {2}", this.Zawod, base.FormatWyjsciowy(), SzczegolyZawodu());
        }

        public override void OdczytConsole()
        {
            base.OdczytConsole();
            System.Console.Write("Podaj przedmiot(nauczyciel):");
            this.przedmiot = System.Console.ReadLine();
            System.Console.Write("\nPodaj tytul(nauczyciel): ");
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
            this.przedmiot = szczegolyZawodu[0];
            this.tytul = szczegolyZawodu[1];
        }

    }
}

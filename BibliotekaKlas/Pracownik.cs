using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BibliotekaKlas
{
    public class Pracownik : IComparable<Pracownik>
    {
        private string imie;
        private string nazwisko;
        private Data dataUrodzenia;
        private Adres adresZamieszkania;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko // Właściwość zwraca i ustawia wartość pola nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public Data DataUrodzenia
        {
            get { return dataUrodzenia; }
        }
        public Adres AdresZamieszkania // Adres i Data tylko zwracają wartość pola dataUrodzenia i adresZamieszkania
        {
            get { return adresZamieszkania; }
        }
        public virtual Zawody Zawod
        {
            get { return Zawody.Pracownik; }
        }
        public Pracownik() // Bezargumentowy konstruktor domyślny 
        {
            imie = "";
            nazwisko = "";
            dataUrodzenia = new Data();
            adresZamieszkania = new Adres();
        }
        public Pracownik(string imie, string nazwisko, int dzien, int miesiac, int rok, string ulica, string numerDomu, string miasto) // Konstruktor inicjalizujący pola składowe
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = new Data(dzien, miesiac, rok);
            this.adresZamieszkania = new Adres(ulica, numerDomu, miasto);
        }
        public Pracownik(Pracownik konstruktorKopiujacyPracownik)
        {
            this.imie = konstruktorKopiujacyPracownik.imie;
            this.nazwisko = konstruktorKopiujacyPracownik.nazwisko;
            this.dataUrodzenia = new Data(konstruktorKopiujacyPracownik.dataUrodzenia);
            this.adresZamieszkania = new Adres(konstruktorKopiujacyPracownik.adresZamieszkania);
        }
        public virtual Pracownik Clone() // Wywoładnie konstruktora kopiującgo
        {
            return new Pracownik(this);
        }

        public override string ToString() // Zwraca dane w postaci string 
        {
            return string.Format("{0} {1} {2} {3} ", imie, nazwisko, DataToString(), AdresToString());
        }
        public virtual string FormatWyjsciowy() // Zwraca dane pracawnika w formię jak niżej imię nazwisko i odpowiednio pola z daty i pola z Adresu
        {
            return string.Format("Imię, nazwisko:{0}, {1}\nData urodzenia:{2}\nAdres zamieszkania:{3}"
                , imie, nazwisko, DataToString(), AdresToString());
        }
        public virtual string SzczegolyZawodu() // Pracownik nie ma w sumie szczegulu to jest szablon
        {
            return string.Format("brak");
        }
        public string DataToString() // Zwraca Tylko Date w postaci stringa. Używasz tego wyżej np w Formacie Wyjsciowym żeby było krucej
        {
            return string.Format("{0}-{1}-{2}", dataUrodzenia.Dzien, dataUrodzenia.Miesiac, dataUrodzenia.Rok);
        }
        public string AdresToString() // To samo co w DataToString zamienia wszystko na stringa potrzebne do wypisania
        {
            return string.Format("{0},{1},{2}", adresZamieszkania.Ulica, adresZamieszkania.NumerDomu, adresZamieszkania.Miasto);
        }
        public virtual void OdczytConsole() // Konsolowe wczytanie danych z klawiatury uważaj co wpisujesz bo może bład wywalić jak zamiast inta dasz literke
        {
            
            System.Console.Write("\nPodaj Imię: ");
            imie = System.Console.ReadLine();
            System.Console.Write("pPodaj Nazwisko: ");
            nazwisko = System.Console.ReadLine();
            System.Console.Write("podaj dzień urodzenia(numer dnia w miesiącu): ");
            dataUrodzenia.Dzien = Convert.ToInt16(System.Console.ReadLine());
            System.Console.Write("podaj miesiąć urodzenia(numer miesiąca, cyfry arabskie): ");
            dataUrodzenia.Miesiac = Convert.ToInt16(System.Console.ReadLine());
            System.Console.Write("podaj rok urodzinia: ");
            dataUrodzenia.Rok = Convert.ToInt16(System.Console.ReadLine());
            System.Console.Write("podaj ulicę(adresZamieszkania): ");
            adresZamieszkania.Ulica = System.Console.ReadLine();
            System.Console.Write("podaj numer domu(adresZamieszkania, cyfry arabskie): ");
            adresZamieszkania.NumerDomu = System.Console.ReadLine();
            System.Console.Write("podaj miasto(adresZamieszkania): ");
            adresZamieszkania.Miasto = System.Console.ReadLine();
                
        }
           
        public virtual void ZapisConsole() // Wypisuje te dane które zostały wczytane w OdczytConsole. Czyli w metodzie OdczytConole Wpisujesz dane do programu i one tam "Wiszą" a metoda ZapisConsole te dane potrafi wypisac. Do tego wykorzystuje ona metode formatwyjsciowy wcześniej zadeklarowana
        {
            System.Console.WriteLine(FormatWyjsciowy());
        }

        public virtual void OdczytXml(DataRow dr)
        {
            try
            {
                this.imie = dr.ItemArray[0].ToString();
                this.nazwisko = dr.ItemArray[1].ToString();
                string[] data = dr.ItemArray[2].ToString().Split('-');
                this.dataUrodzenia.Dzien = int.Parse(data[0]);
                this.dataUrodzenia.Miesiac = int.Parse(data[1]);
                this.dataUrodzenia.Rok = int.Parse(data[2]);
                string[] adres = dr.ItemArray[3].ToString().Split(',');
                this.adresZamieszkania.Ulica = adres[0];
                this.adresZamieszkania.NumerDomu = adres[1];
                this.adresZamieszkania.Miasto = adres[2];

            }
            catch (FormatException e)
            {
                string info = e.Message;
            }
        }
        public int CompareTo(Pracownik other) // Interfejs IComparable wymaga od ciebie wykorzystnia tej metody. Jest ona zrealizowana w innej klasie dlatego piszesz dla niej wyjatek.
        {
            throw new NotImplementedException();
        }

    }
}

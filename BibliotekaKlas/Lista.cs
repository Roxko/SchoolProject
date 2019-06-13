using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace BibliotekaKlas
{

    public class Lista
    {
        private List<Pracownik> lista;
        private FormatDanych df;
        private FormatDanych fd;

        public Lista() // konstruktor domyślny wywołujący konstruktor klasy Lista
        {
            lista = new List<Pracownik>();
            foreach (Pracownik p in lista)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public void Dodaj(Pracownik pracownik) // Dodanie pracownika do listy pracowników
        {
            lista.Add(pracownik.Clone());
        }

        public void WstawWPolozenie(int indeks, Pracownik pracownik)
        {
            if (indeks < 0 || indeks > lista.Count)
            {
                System.Console.WriteLine("Zły indeks");
                return;
            }
            lista.Insert(indeks, pracownik.Clone());
        }

        public int Usun(string nazwisko) // Usuwanie pracownika wpisując jego nazwisko zwraca nr indeksu
        {
            foreach (Pracownik pracownik in lista)
            {
                if (pracownik.Nazwisko.Equals(nazwisko) == true)
                {
                    int i = lista.IndexOf(pracownik);
                    lista.Remove(pracownik);
                    return i;
                }
            }
            return -1;
        }

        public void Usun(int indeks) // Usuwa pracownika po indeksie Jeśli takiego nie ma wypisuje błąd i program dalej działą
        {
            if (indeks >= 0 && lista.Count > indeks)
                lista.RemoveAt(indeks);
            else
                System.Console.WriteLine("nieprawidłowy indeks");
        }

        public Pracownik Szukaj(string nazwisko) // Wyszukuje pracownika na liście jak znajdzie zwraca go
        {
            return lista.Find(Pracownik => Pracownik.Nazwisko.Equals(nazwisko));
        }

        public void Sortuj(IComparer<Pracownik> ic)
        {
            lista.Sort(ic);
        }

        public void SortConsole() // Metoda sortujaca korzystajaca z klasy Sortowanie 
        {
            IComparer<Pracownik> ic;
            int wybor;
            Console.WriteLine("Jak chcesz sortowac: \n");
            Console.WriteLine("\n1. Po nazwisku\n2. Po zawodzie\n3. Po Imieniu \n4. Po datcie Urodzenia - Dzien\n5. Po dacie Urodzenia - Miesiac\n6. Po dacie Urodzenia - Rok\n7. Po adresie Zamieszkania - Ulica,\n8. Po adresie Zamieszkania - NumerDomu\n9. Po adresie Zamieszkania - Miasto\n");
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    {
                        ic = new Sortowanie.PoNazwisku();
                        Console.WriteLine("Wykonano");
                        break;
                    }
                case 2: { ic = new Sortowanie.PoZawodzie(); break; }
                case 3: { ic = new Sortowanie.PoImieniu(); break; }
                case 4: { ic = new Sortowanie.PodataUrodzeniaDzien(); break; }
                case 5: { ic = new Sortowanie.PodataUrodzeniaMiesiac(); break; }
                case 6: { ic = new Sortowanie.PodataUrodzeniaRok(); break; }
                case 7: { ic = new Sortowanie.PoadresZamieszkaniaUlica(); break; }
                case 8: { ic = new Sortowanie.PoadresZamieszkaniaNumerDomu(); break; }
                case 9: { ic = new Sortowanie.PoadresZamieszkaniaMiasto(); break; }
                default:
                    {
                        ic = new Sortowanie.PoNazwisku(); // jak ktos wpisze cos poza 1-9 wykonuje sie default
                        Console.WriteLine("Pusto");
                        break;
                    }

            }
            Sortuj(ic);
        }

        public void ZapisConsole() // Wypisuje wszystkich pracowników z listy
        {
            Console.WriteLine("Lista pracownikow:");
            foreach (Pracownik pracownik in lista)
            {
                Console.WriteLine("pracownik o numerze:{0}", lista.IndexOf(pracownik));
                Console.WriteLine(pracownik.FormatWyjsciowy());
            }
        }

        public void Wyczysc() // Kasuje wszystko z Listy
        {
            lista.Clear();
        }

        public Pracownik this[int i]
        {
            get { return lista[i]; }
        }

        public int Rozmiar
        {
            get { return lista.Count; }
        }

        public void OdczytXml()
        {
            lista = fd.OdczytXml();
        }

        public void ZapisXml()
        {
            fd.ZapisXml(lista);
        }

        public string SciezkaDoPliku
        {
            get { return fd.Sciezka; }
            set { fd.Sciezka = value; }
        }

        public void OdczytConsole()
        {

            int menuuu = 1;
            while (menuuu == 1)
            {
                Console.WriteLine("\nJakiego pracownika chcesz stworzyc?\nA-Informatyk B-Lekarz C-Nauczyciel");
                char typ = char.Parse(Console.ReadLine());
                switch (typ)
                {
                    case 'A':
                        {
                            Informatyk pracownik = new Informatyk();
                            pracownik.OdczytConsole();
                            lista.Add(pracownik);
                            menuuu = 0;
                            break;
                        }
                    case 'B':
                        {
                            Lekarz pracownik = new Lekarz();
                            pracownik.OdczytConsole();
                            lista.Add(pracownik);
                            menuuu = 0;
                            break;
                        }
                    case 'C':
                        {
                            Nauczyciel pracownik = new Nauczyciel();
                            pracownik.OdczytConsole();
                            lista.Add(pracownik);
                            menuuu = 0;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public void Sortowanie()
        {
            SortConsole();
        }
    }
}
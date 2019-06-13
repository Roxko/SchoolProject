using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlas;

namespace WierszPolecen
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Lista lista = new Lista();
            for (; ; ) // Nieskonczona petla bez warunkow 
            {
                Console.WriteLine("\tAPLIKACJA PRACOWNICY");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Dodawanie pracownikow do listy");
                Console.WriteLine("2. Wstawianie pracownikow w dowolne miejsce na liscie");
                Console.WriteLine("3. Usuwanie pracownikow po nazwisku lub indeksie");
                Console.WriteLine("4. Wyszukiwanie pracownikow");
                Console.WriteLine("5. Sortowanie pracownikow");
                Console.WriteLine("6. Wyświetlanie danych pracownikow");
                Console.WriteLine("7. Czyszczenie zawartości listy pracownikow,");
                Console.WriteLine("8. Odczyt i zapis do pliku w formacie Xml");
                Console.WriteLine("9. Wyjscie z aplikacji");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Wybierz pozycje z menu: ");
                char typ = char.Parse(Console.ReadLine());
                switch (typ) // Wykorzystanie wszystkich metod wcześniej zainicjowanych do realnych dzialan
                {
                    case '1':
                        {
                            char zapytanieCaseA = 'n';
                            while (zapytanieCaseA == 'n')
                            {
                                lista.OdczytConsole(); // Ta metoda jest w klasie lista wypelnia to co tam jest napisane 
                                Console.WriteLine("\n***dodano pracownika:{0}***\n", i);
                                Console.WriteLine("Zakończyc zapis? (t/n)");
                                zapytanieCaseA = char.Parse(Console.ReadLine());
                            }

                            break;
                        }
                    case '2': // W casach jest tylko po kilka zdan i pojedyncze wywolania metod jak chcesz wiedziec jak one dzialaja to przechodzisz do nich i patrzysz jak dzialaja To sie tyczy całej klasy Program
                        {
                            Console.WriteLine("Podaj nazwisko pracownika którego chcesz wstawicw zadany indeks");
                            string nazwisko = Console.ReadLine();
                            Console.WriteLine("Podaj indeks listy do którego chcesz wstawic pracownika");
                            int indeks = int.Parse(Console.ReadLine());
                            lista.WstawWPolozenie(indeks, lista.Szukaj(nazwisko));

                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Usuwanie po nazwisku/indeksie (n/w)?");
                            char typCaseC = char.Parse(Console.ReadLine());
                            switch (typCaseC)
                            {
                                case 'n':
                                    {
                                        Console.WriteLine("Podaj nazwisko pracownika którego chcesz usunac");
                                        lista.Usun(Console.ReadLine());
                                        break;
                                    }
                                case 'w':
                                    {
                                        Console.WriteLine("Podaj index pracownika którego chcesz usunac");
                                        lista.Usun(int.Parse(Console.ReadLine()));
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Nieprawidlowe polecenie\n");
                                    break;
                            }
                            i = i - 1;
                            Console.WriteLine("Usunieto pracownika\naby kontynuowac naciśnij dowolny klawisz...");
                            Console.ReadLine();

                            break;
                        }
                    case '4':
                        {
                            try
                            {
                                Console.WriteLine("Podaj nazwisko pracownika którego szukasz:");
                                string nazwisko = Console.ReadLine();
                                Pracownik pracownik = new Pracownik();
                                pracownik = lista.Szukaj(nazwisko);
                                Console.WriteLine("indeks pracownika:{0}\n aby kontynuowac naciśnij dowolny klawisz...", pracownik.FormatWyjsciowy());
                                Console.ReadLine();
                            }
                            catch (System.NullReferenceException)
                            { Console.WriteLine("Nie ma takiego pracownika");
                                Console.WriteLine("Naciśniej dowolny klawisz ... ");
                                Console.ReadKey(true);
                            }

                            break;
                        }
                    case '5':
                        {
                            lista.Sortowanie();

                            break;
                        }
                    case '6':
                        {
                            lista.ZapisConsole();
                            Console.WriteLine("Dodawanie zakończone\nnaciśnij dowolny klawisz...\n");
                            Console.ReadLine();

                            break;
                        }
                    case '7':
                        {
                            lista.Wyczysc();
                            i = 0;
                            Console.WriteLine("lista wyczyszczona\naby kontynuowac naciśnij dowolny klawisz...");
                            Console.ReadLine();

                            break;
                        }
                    case '8':
                        {
                            Console.WriteLine("o - odczytXML\nz - ZapisXML\n");
                            char typCaseH = char.Parse(Console.ReadLine());
                            switch (typCaseH)
                            {
                                case 'o':
                                    {
                                        break;
                                    }
                                case 'z':
                                    {
                                        lista.ZapisXml();
                                        break;
                                    }
                            }

                            break;

                        }
                    case '9':
                        {
                            return;
                        }
                    default:
                        {
                            System.Console.Clear();
                            Console.WriteLine("BLAD - zly wybor");
                            break;

                        }
                }
                System.Console.Clear();
            }
        }
    }
}

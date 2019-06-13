using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BibliotekaKlas
{
    class FormatDanych
    {
        private string sciezka;
        private DataSet ds;
        private DataTable dt; // Większość masz opisane w instrukcjach 


        public string Sciezka
        {
            get { return sciezka; }
            set { sciezka = value; }
        }

        public void InicjalizujKomponent(string inicjatorpolaskladowego)
        {
            ds = new DataSet(inicjatorpolaskladowego);
            dt = new DataTable("Pracownicy");
        }

        public void StworzKomumny() // Tworzy kolumny 
        {
            dt.Columns.Clear();
            dt.Columns.Add("Imię", typeof(String));
            dt.Columns.Add("Nazwisko", typeof(String));
            dt.Columns.Add("Data urodzenia", typeof(String));
            dt.Columns.Add("Adres zamieszkania", typeof(String));
            dt.Columns.Add("Dane szczegółowe", typeof(String));
            dt.Columns.Add("Zawód", typeof(String));
            ds.Tables.Clear();
            ds.Tables.Add(dt);
        }

        public void ZapisXml(List<Pracownik> lista) 
        {
            ds.WriteXml(this.Sciezka);
            ds.ReadXml(this.Sciezka);
        }

        public void WypełnijTabele(List<Pracownik> lista) // Wypelnia tabele opis w instrukcji
        {
            dt.Rows.Clear();
            DataRow ds;
            foreach (Pracownik p in lista)
            {
                ds = dt.NewRow();
                ds["Imię"] = p.Imie;
                ds["Nazwisko"] = p.Nazwisko;
                ds["Data Urodzenia"] = p.DataToString();
                ds["Adres Zamieszkania"] = p.AdresToString();
                ds["Dane Szczegółowe"] = p.SzczegolyZawodu();
                ds["Zawód"] = p.Zawod;
                dt.Rows.Add(ds);
            }
        }
        public List<Pracownik> OdczytXml()
        {
            List<Pracownik> lista = new List<Pracownik>();
            ds = new DataSet();
            Pracownik p = new Pracownik();
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    switch ((dr["Zawód"]).ToString())
                    {
                        case "Informatyk":
                            {
                                Informatyk i = new Informatyk();
                                break;
                            }
                        case "Nauczyciel":
                            {
                                Nauczyciel n = new Nauczyciel();
                                break;
                            }
                        case "Lekarz":
                            {
                                Lekarz l = new Lekarz();
                                break;
                            }
                    }
                    p.OdczytXml(dr);
                    lista.Add(p);
                }

            }
            return lista;
        }
    }
}
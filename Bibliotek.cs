using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BibliotekHanteringAvancerad
{
    public class Bibliotek
    {
        public List<Bok> Böcker { get; set; }
        public List<Författare> Författarlista { get; set; }

        public const string Filnamn = "LibraryData.json";

        public Bibliotek()
        {
            Böcker = new List<Bok>();
            Författarlista = new List<Författare>();
            LaddaData();
        }

        public void LäggTillBok()
        {
            Console.WriteLine("Ange titel:");
            string titel = Console.ReadLine();

            Console.WriteLine("Ange Författare:");
            string författare = Console.ReadLine();

            Console.WriteLine("Ange genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Ange Publiceringsår:");
            int publiceringsår = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ange ISBN:");
            int iSBN = Convert.ToInt32(Console.ReadLine());

            
            Bok nybok = new Bok();

            nybok.Titel = titel;
            nybok.Författare = Skapaellerhitta(författare);
            nybok.Genre = genre;
            nybok.Publiceringsår= publiceringsår;
            nybok.ISBN = iSBN;

            Böcker.Add(nybok);
            SparaData();
            Console.WriteLine($"Boken '{nybok.Titel}' av {nybok.Författare.Namn} har lagts till i biblioteket");
        }

        public void LäggTillFörfattare()
        {
           Console.WriteLine("Ange namn på författern:");
            string name = Console.ReadLine();

            Författare nyförfattare = new Författare();

            nyförfattare = Skapaellerhitta(name);
            SparaData();
        }

        public void UppdateraBok()
        {
            Console.WriteLine("Ange bok du vill uppdatera:");
            string uppdaterabok = Console.ReadLine();

            var befintligBok = Böcker.Where(b => b.Titel == uppdaterabok).FirstOrDefault();

            if (befintligBok == null)
            {
                Console.WriteLine("Ingen bok hittades med detta namn");
                return; 

            }

            Console.WriteLine("Ange titel:");
            string titel = Console.ReadLine();

            Console.WriteLine("Ange Författare:");
            string författare = Console.ReadLine();

            Console.WriteLine("Ange genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Ange Publiceringsår:");
            int publiceringsår = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ange ISBN:");
            int iSBN = Convert.ToInt32(Console.ReadLine());


            

            befintligBok.Titel = titel;
            befintligBok.Författare = Skapaellerhitta(författare);
            befintligBok.Genre = genre;
            befintligBok.Publiceringsår = publiceringsår;
            befintligBok.ISBN = iSBN;

            Console.WriteLine($"Updaterade {befintligBok.Titel} Färdigt");
            SparaData();

        }

        public void UppdateraFörfattare()
        {
            Console.WriteLine("Ange författaren du vill uppdatera:");
            string uppdateraförfattare = Console.ReadLine();

            var befintligförfattare = Författarlista.Where(b => b.Namn == uppdateraförfattare).FirstOrDefault();

            if (befintligförfattare == null)
            {
                Console.WriteLine("Ingen författare hittades med detta namn");
                return;
            }

            Console.WriteLine("Ange författarens nya namn:");
            string nyförfattarenamn = Console.ReadLine();

            befintligförfattare.Namn = nyförfattarenamn;
            Console.WriteLine("Du har uppdaterat författarens namn");
            SparaData();
        }

        public void TaBortBok()
        {
            Console.WriteLine("Vilken bok vill du ta bort?");
            string bokattradera = Console.ReadLine();

            var bok = Böcker.Where(b => b.Titel == bokattradera).FirstOrDefault();
            if (bok == null)
            {
               Console.WriteLine("Boken existerar inte");
                return;
            }
            Böcker.Remove(bok);

            Console.WriteLine("Boken är raderad!");
            SparaData();
        }

        public void TaBortFörfattare()
        {
            Console.WriteLine("Vilken Författare vill du ta bort?");
            string författareattradera = Console.ReadLine();

            var författare = Författarlista.Where(b => b.Namn == författareattradera).FirstOrDefault();
            if (författare == null)
            {
                Console.WriteLine("Författaren existerar inte");
                return;
            }
            Författarlista.Remove(författare);

            Console.WriteLine("Författaren är raderad!");
            SparaData();
        }

        public void ListaBöcker()
        {
            foreach (var bok in Böcker)
            {
                Console.WriteLine("Böckerna i biblioteket ");
                Console.WriteLine($"Titel: {bok.Titel}, Författare: {bok.Författare.Namn}, Genre: {bok.Genre}, År: {bok.Publiceringsår}, ISBN: {bok.ISBN}");
            }
        }

        public void ListaFörfattare()
        {
            foreach (var författare in Författarlista)
            {
                Console.WriteLine("Våra författare:");
                Console.WriteLine($"Namn: {författare.Namn}");
            }
        }

        public Författare Skapaellerhitta(string namn)
        {
            var befintligförfattare = Författarlista.FirstOrDefault(f => f.Namn == namn);

            if (befintligförfattare != null)
            {
                return befintligförfattare;
            }

            Författare nyförfattare = new Författare();
            nyförfattare.Namn = namn;
            Författarlista.Add(nyförfattare);
            return nyförfattare;
        }

        public void SparaData()
        {
            var data = new Data
            {
                Böcker = Böcker, 
                Författarlista = Författarlista
            };

            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(Filnamn, jsonData);
            Console.WriteLine("Data har sparats.");
        }

        public void LaddaData()
        {
            if (File.Exists(Filnamn))
            {
                var jsonData = File.ReadAllText(Filnamn);
                var data = JsonConvert.DeserializeObject<Data>(jsonData);
                Böcker = data?.Böcker ?? new List<Bok>();
                Författarlista = data?.Författarlista ?? new List<Författare>();
            }
            else
            {
                Böcker = new List<Bok>();
                Författarlista = new List<Författare>();
            }
        }
    }
}

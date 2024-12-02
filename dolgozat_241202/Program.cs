using System;
using System.Collections.Generic;
using System.Linq;
    
namespace dolgozat_241202
{
    internal class Program
    {
        private static List<Book> konyvek = new List<Book>();
        private static Random rnd = new Random();
        public static void Main(string[] args)
        {
            konyvekLetrehozas(15);
            EladasSzimulalas(100);

            Console.ReadKey(true);
        }

        private static void konyvekLetrehozas(int mennyiseg)
        {
            var Cimek = new List<string> { "Bujkálás a sötétben", "Az elfeledett rejtekhely", "Kijutás a rémálomból", "A titkos puzzle", "Az utolsó menedék", "Félelem és remény", "A szomorú labirintus", "A boldogság árnyéka", "Izgalom a rejtélyben", "Fakadó könnyek", "A kísérlet vége", "A fák között", "A szív titkai", "Az éjszaka fogságában", "A gyász színe", "A győztes és a vesztes", "Az utolsó búvóhely", "A sötétség határán", "Rejtett érzelmek", "A boldogság keresése", "A múlt árnyai", "A csendes kiáltás", "A titkos ajtó", "A végső próba", "A remény fogságában", };

            for (int i = 0; i < mennyiseg; i++)
            {
                long isbn = EgyediISBNLetrehozas();

                var irokMennyiseg = rnd.Next(1, 4);
                List<Author> szerzo = new List<Author>();

                for (int j = 0; j < irokMennyiseg; j++)
                {
                    // Create a properly formatted author name
                    string lastName = "Vezetéknév" + (i + j + 1);
                    string firstName = "Keresztnév" + (i + j + 1);
                    string fullName = $"{lastName}, {firstName}";

                    szerzo.Add(new Author(fullName));
                }

                string Cim = Cimek[rnd.Next(Cimek.Count)];
                int Ev = rnd.Next(2000, 2025);
                string Nyelv = rnd.NextDouble() < 0.8 ? "magyar" : (rnd.NextDouble() < 0.5 ? "angol" : "német");
                int Keszlet = rnd.NextDouble() < 3 ? 0 : rnd.Next(5, 11);
                int Ar = rnd.Next(1000, 10001);

                konyvek.Add(new Book(isbn, szerzo, Cim, Ev, Nyelv, Keszlet, Ar));
            }
        }
        private static long EgyediISBNLetrehozas()
        {
            long isbn;
            do
            {
                isbn = rnd.Next(100000000, 999999999);
            } while (konyvek.Any(b => b.ISBN == isbn));
            return isbn;
        }

        private static void EladasSzimulalas(int mennyiseg)
        {
            int osszesEladas = 0;
            int kifogyottKeszlet = 0;
            int kezdetiKeszlet = konyvek.Sum(k => k.Keszlet);
            int kezdetiMennyiseg = konyvek.Count;

            for(int i = 0; i < mennyiseg; i++)
            {
                var konyvMegvasarlas = konyvek[rnd.Next(konyvek.Count)];

                if(konyvMegvasarlas.Keszlet > 0)
                {
                    konyvMegvasarlas.Keszlet--;
                    osszesEladas += konyvMegvasarlas.Ar;
                }
                else
                {
                    if(rnd.NextDouble() < 0.5)
                    {
                        konyvMegvasarlas.Keszlet += rnd.Next(1, 11);
                    }
                    else
                    {
                        konyvek.Remove(konyvMegvasarlas);
                        kifogyottKeszlet++;
                    }
                }
            }

            int jelenlegiMennyiseg = konyvek.Sum(k => k.Keszlet);

            Console.WriteLine($"Összes nyereség: {osszesEladas} Ft");
            Console.WriteLine($"Könyvek, amik kifogytak : {kifogyottKeszlet}");
            Console.WriteLine($"Kezdeti könyv készlet: {kezdetiMennyiseg}, jelenlegi készlet: {jelenlegiMennyiseg}, változás: {jelenlegiMennyiseg - kezdetiMennyiseg}");
        }
    }
}
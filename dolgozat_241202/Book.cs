using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_241202
{
    class Book
    {
        private static Random _random = new Random();

        public long ISBN { get; set; }
        public List<Author> Authors { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public string Nyelv { get; set; }
        public int Keszlet { get; set; }
        public int Ar {  get; set; }

        public Book(long iSBN, List<Author> authors, string cim, int ev, string nyelv, int keszlet, int ar)
        {
            ISBN = iSBN;
            Authors = authors;
            Cim = cim;
            Ev = ev;
            Nyelv = nyelv;
            Keszlet = keszlet;
            Ar = ar;
        }

        public Book(string cim, string iroNev)
        {
            ISBN = RandomISBN();
            Cim = cim;
            Authors = new List<Author> { new Author(iroNev) };
            Ev = 2024;
            Nyelv = "magyar";
            Keszlet = 0;
            Ar = 4500;
        }

        private long RandomISBN()
        {
            long isbn;
            do
            {
                isbn = _random.Next(1000000000, 999999999);
            } while (letezoISBN(isbn));
            return isbn;
        }

        private static HashSet<long> meglevoISBN = new HashSet<long>();

        public static bool letezoISBN(long isbn)
        {
            return meglevoISBN.Contains(isbn);
        }

        public override string ToString()
        {
            string iroSzoveg = Authors.Count == 1 ? "szerző: " : "szerzők: ";
            string keszletSzoveg = Keszlet == 0 ? "beszerzés alatt" : $"{Keszlet} db";

            return $"Cím: {Cim}, {iroSzoveg} {string.Join(", ", Authors.Select(a => a.VNev + " " + a.KNev))}, Kiadás éve: {Ev}, Nyelv: {Nyelv}, Készlet: {keszletSzoveg}, Ár: {Ar} Ft";
        }
    }
}

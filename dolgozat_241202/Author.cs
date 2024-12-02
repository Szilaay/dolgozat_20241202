using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_241202
{
    internal class Author
    {
        public string VNev { get; set; }
        public string KNev { get; set; }
        public Guid GUID { get; set; }

        public Author(string egeszNev)
        {
            var nevek = egeszNev.Split(',');
            if (nevek.Length != 2 || nevek[0].Length < 3 || nevek[1].Length < 3 || nevek[0].Length > 32 || nevek[1].Length > 32)
            {
                throw new ArgumentException("Helytelen szerző név");
            }   

            VNev = nevek[0];
            KNev = nevek[1];
            GUID = Guid.NewGuid();
        }
    }
}

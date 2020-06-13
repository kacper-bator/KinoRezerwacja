using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KinoRezerwacja
{
    class Film
    {
        string nazwa;
        int id;
        public string Nazwa { get => nazwa; set => nazwa = value; }

        public Film (int id,string nazwa)
        {
            this.id = id;
            this.nazwa = nazwa;
        }

        public int Id { get => id; }

    }
}

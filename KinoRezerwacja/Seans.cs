using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRezerwacja
{
    class Seans
    {
        int id, id_film, id_sala;
        DateTime data_sensu, godz_rozp;

        public DateTime Data_sensu { get => data_sensu; set => data_sensu = value; }

        public DateTime Godz_rozp { get => godz_rozp; set => godz_rozp = value; }


        public Seans(int id, int id_film, DateTime data_sensu, DateTime godz_rozp, int id_sala)
        {
            this.id = id;
            this.id_film = id_film;
            this.data_sensu = data_sensu;
            this.godz_rozp = godz_rozp;
            this.id_sala = id_sala;
        }

        public int Id { get => id; }

        public int Id_sala { get => id_sala; }

        public int Id_film { get => id_film; }
    }

}

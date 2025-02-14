using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisRowerowy.encje
{
        public class Zlecenie
        {
            public int ID_zlecenia { get; set; }                 // ID_zlecenia
            public DateTime Data_przyjecia { get; set; } // Data_przyjecia
            public string Status { get; set; }         // Status
            public string Opis_problemu { get; set; } // Opis_problemu
            public int Pracownik { get; set; }        // Pracownik (ID_pracownika)
            public int Rower { get; set; }            // Rower (ID_roweru)
        }

}

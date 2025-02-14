using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisRowerowy.encje
{
    public class Rower
    {
        public int ID { get; set; }            // ID_roweru
        public string Marka { get; set; }     // Marka
        public string Model { get; set; }     // Model
        public string Kolor { get; set; }     // Kolor
        public int Rok_produkcji { get; set; } // Rok_produkcji
        public int Wlasciciel { get; set; }   // Właściciel (ID_klienta)
    }
}


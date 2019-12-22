using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Przedmiot
    {
        public Przedmiot()
        {
            Ocena = new HashSet<Ocena>();
            PrzedmiotPoprzedzajacyIdPoprzednikNavigation = new HashSet<PrzedmiotPoprzedzajacy>();
            PrzedmiotPoprzedzajacyIdPrzedmiotNavigation = new HashSet<PrzedmiotPoprzedzajacy>();
        }

        public int IdPrzedmiot { get; set; }
        public string Przedmiot1 { get; set; }
        public string Symbol { get; set; }

        public ICollection<Ocena> Ocena { get; set; }
        public ICollection<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacyIdPoprzednikNavigation { get; set; }
        public ICollection<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacyIdPrzedmiotNavigation { get; set; }
    }
}

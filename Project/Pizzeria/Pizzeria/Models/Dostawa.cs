using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dostawa
    {
        public Dostawa()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string Adres { get; set; }
        public decimal CenaDostawy { get; set; }
        public DateTime CzasDostawy { get; set; }
        public string MiejsceDostawcy { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

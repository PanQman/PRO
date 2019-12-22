using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public bool CzyStudent { get; set; }
        public bool CzyRodzina { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

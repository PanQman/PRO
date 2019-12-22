using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string NazwaPromocji { get; set; }
        public float WartoscPromocji { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

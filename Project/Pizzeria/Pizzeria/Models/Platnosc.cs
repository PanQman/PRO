using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Platnosc
    {
        public Platnosc()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public bool CzyKarta { get; set; }
        public bool CzyGotowka { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

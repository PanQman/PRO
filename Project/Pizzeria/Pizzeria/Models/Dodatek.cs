using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string NazwaDodatku { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string NazwaSkladnika { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}

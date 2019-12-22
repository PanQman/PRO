using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Sos
    {
        public Sos()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string NazwaSosu { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}

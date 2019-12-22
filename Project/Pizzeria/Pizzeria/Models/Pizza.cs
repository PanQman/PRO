using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }
        public string NazwaPizzy { get; set; }
        public int SkladnikId { get; set; }
        public int SosId { get; set; }
        public decimal CenaPizzy { get; set; }

        public Skladnik Skladnik { get; set; }
        public Sos Sos { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

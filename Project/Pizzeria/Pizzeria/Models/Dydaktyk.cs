using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dydaktyk
    {
        public Dydaktyk()
        {
            InversePodlegaNavigation = new HashSet<Dydaktyk>();
            Ocena = new HashSet<Ocena>();
        }

        public int IdOsoba { get; set; }
        public int? IdStopien { get; set; }
        public int? Podlega { get; set; }

        public Osoba IdOsobaNavigation { get; set; }
        public StopnieTytuly IdStopienNavigation { get; set; }
        public Dydaktyk PodlegaNavigation { get; set; }
        public ICollection<Dydaktyk> InversePodlegaNavigation { get; set; }
        public ICollection<Ocena> Ocena { get; set; }
    }
}

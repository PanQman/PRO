using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Ocena
    {
        public int IdStudent { get; set; }
        public int IdPrzedmiot { get; set; }
        public DateTime DataWystawienia { get; set; }
        public int IdDydaktyk { get; set; }
        public decimal Ocena1 { get; set; }

        public Dydaktyk IdDydaktykNavigation { get; set; }
        public Przedmiot IdPrzedmiotNavigation { get; set; }
        public Student IdStudentNavigation { get; set; }
    }
}

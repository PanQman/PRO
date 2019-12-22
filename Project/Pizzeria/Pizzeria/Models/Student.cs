using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Student
    {
        public Student()
        {
            Ocena = new HashSet<Ocena>();
            StudentGrupa = new HashSet<StudentGrupa>();
        }

        public int IdOsoba { get; set; }
        public string NrIndeksu { get; set; }
        public DateTime DataRekrutacji { get; set; }

        public Osoba IdOsobaNavigation { get; set; }
        public ICollection<Ocena> Ocena { get; set; }
        public ICollection<StudentGrupa> StudentGrupa { get; set; }
    }
}

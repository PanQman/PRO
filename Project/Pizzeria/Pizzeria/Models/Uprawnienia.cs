using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Uprawnienia
    {
        public Uprawnienia()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Uprawnienia1 { get; set; }

        public ICollection<User> User { get; set; }
    }
}

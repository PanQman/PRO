using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int IdUprawnien { get; set; }

        public Uprawnienia IdUprawnienNavigation { get; set; }
    }
}

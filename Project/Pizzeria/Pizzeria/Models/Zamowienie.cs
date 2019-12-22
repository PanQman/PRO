using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa nie może być pusta")]
        public string Nazwa { get; set; }
        public int DodatekId { get; set; }
        public int PromocjaId { get; set; }
        [Required(ErrorMessage = "Klient jest wymagany")]
        public int KlientId { get; set; }
        public int DostawaId { get; set; }
        [Required(ErrorMessage = "Zamówienie musi posiadać co najmniej jedną pizze")]
        public int PizzaId { get; set; }
        public int PlatnoscId { get; set; }
        public decimal CenaZamowienia { get; set; }

        public Dodatek Dodatek { get; set; }
        public Dostawa Dostawa { get; set; }
        public Klient Klient { get; set; }
        public Pizza Pizza { get; set; }
        public Platnosc Platnosc { get; set; }
        public Promocja Promocja { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private _2019SBDContext _context;
        public MenuController(_2019SBDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMenus()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMenu(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.Id == id);
            if (pizza == null)
            {
                return NotFound();//404 Not found
            }
            return Ok(pizza);
        }

        [HttpDelete("{pizza:int}")]
        public IActionResult Deletepizza(Pizza pizza)
        {
            if (_context.Pizza.Count(e => e.Id == pizza.Id) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            _context.Pizza.Add(pizza);
            _context.SaveChanges();
            return StatusCode(201, pizza); //201
        }

        [HttpPut("{pizza:int}")]
        public IActionResult UpdatePizza(Pizza pizza)
        {
            if (_context.Pizza.Count(e => e.Id == pizza.Id) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(pizza);
            _context.Entry(pizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}

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
    public class OrderController : ControllerBase
    {
        private _2019SBDContext _context;
        public OrderController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.Id == id);
            if (order == null)
            {
                return NotFound();//404 Not found
            }
            return Ok(order);
        }
        
        [HttpPost]
        public IActionResult CreateOrder(Zamowienie order)
        {
            _context.Zamowienie.Add(order);
            _context.SaveChanges();
            return StatusCode(201, order); //201
        }

        [HttpPut("{order:int}")]
        public IActionResult UpdateOrder(Zamowienie order)
        {
            if (_context.Zamowienie.Count(e => e.Id == order.Id) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Attach(order);
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(order);
        }

        [HttpDelete("{order:int}")]
        public IActionResult DeleteOrder(Zamowienie order)
        {
            if (_context.Zamowienie.Count(e => e.Id == order.Id) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}
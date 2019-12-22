using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private _2019SBDContext _context;
        public ClientsController(_2019SBDContext context)
        {
            _context = context;
        }

        //api/clients
        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.User.ToList());
        }
        //api/clients/1
        [HttpGet("{id:int}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.User.FirstOrDefault(e => e.Id == id);
            if (client == null)
            {
                return NotFound();//404 Not found
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient(Klient client)
        {
            _context.Klient.Add(client);
            _context.SaveChanges();
            return StatusCode(201, client); 
        }
    }
}
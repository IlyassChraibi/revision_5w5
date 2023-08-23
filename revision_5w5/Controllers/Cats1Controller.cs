using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using revision_5w5.Data;
using revision_5w5.Models;

namespace revision_5w5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cats1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Cats1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cats1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCat()
        {
          if (_context.Cat == null)
          {
              return NotFound();
          }
            return await _context.Cat.ToListAsync();
        }

        // GET: api/Cats1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
          if (_context.Cat == null)
          {
              return NotFound();
          }
            var cat = await _context.Cat.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

   
        private bool CatExists(int id)
        {
            return (_context.Cat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

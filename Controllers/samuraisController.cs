using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ninja2021V.Models;

namespace Ninja2021V.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class samuraisController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public samuraisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/samurais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<samurai>>> GetSamurais()
        {
            return await _context.Samurais.ToListAsync();
        }

        // GET: api/samurais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<samurai>> Getsamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        // PUT: api/samurais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsamurai(int id, samurai samurai)
        {
            if (id != samurai.SamuraiId)
            {
                return BadRequest();
            }

            _context.Entry(samurai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!samuraiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/samurais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<samurai>> Postsamurai(samurai samurai)
        {
            _context.Samurais.Add(samurai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsamurai", new { id = samurai.SamuraiId }, samurai);
        }

        // DELETE: api/samurais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<samurai>> Deletesamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }

            _context.Samurais.Remove(samurai);
            await _context.SaveChangesAsync();

            return samurai;
        }

        private bool samuraiExists(int id)
        {
            return _context.Samurais.Any(e => e.SamuraiId == id);
        }
    }
}

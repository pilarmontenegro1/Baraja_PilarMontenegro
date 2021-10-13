using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Baraja_PilarMontenegro.Data;
using Baraja_PilarMontenegro.Models;

namespace Baraja_PilarMontenegro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarajaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BarajaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Baraja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Naipe>>> GetNaipe()
        {
            return await _context.Naipe.ToListAsync();
        }

        // GET: api/Baraja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Naipe>> GetNaipe(string id)
        {
            var naipe = await _context.Naipe.FindAsync(id);

            if (naipe == null)
            {
                return NotFound();
            }

            return naipe;
        }

        // PUT: api/Baraja/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaipe(string id, Naipe naipe)
        {
            if (id != naipe.NaipeId)
            {
                return BadRequest();
            }

            _context.Entry(naipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaipeExists(id))
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

        // POST: api/Baraja
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Naipe>> PostNaipe(Naipe naipe)
        {
            _context.Naipe.Add(naipe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NaipeExists(naipe.NaipeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNaipe", new { id = naipe.NaipeId }, naipe);
        }

        // DELETE: api/Baraja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaipe(string id)
        {
            var naipe = await _context.Naipe.FindAsync(id);
            if (naipe == null)
            {
                return NotFound();
            }

            _context.Naipe.Remove(naipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaipeExists(string id)
        {
            return _context.Naipe.Any(e => e.NaipeId == id);
        }
    }
}

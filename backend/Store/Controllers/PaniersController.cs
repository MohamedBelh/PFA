using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Model;
using Store.data;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaniersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> Getpaniers()
        {
          if (_context.paniers == null)
          {
              return NotFound();
          }
            return await _context.paniers.ToListAsync();
        }

        // GET: api/Paniers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panier>> GetPanier(int id)
        {
          if (_context.paniers == null)
          {
              return NotFound();
          }
            var panier = await _context.paniers.FindAsync(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        // PUT: api/Paniers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanier(int id, Panier panier)
        {
            if (id != panier.Id)
            {
                return BadRequest();
            }

            _context.Entry(panier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanierExists(id))
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

        // POST: api/Paniers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Panier>> PostPanier(Panier panier)
        {
          if (_context.paniers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.paniers'  is null.");
          }
            _context.paniers.Add(panier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanier", new { id = panier.Id }, panier);
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanier(int id)
        {
            if (_context.paniers == null)
            {
                return NotFound();
            }
            var panier = await _context.paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }

            _context.paniers.Remove(panier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanierExists(int id)
        {
            return (_context.paniers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

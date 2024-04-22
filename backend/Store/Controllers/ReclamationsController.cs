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
    public class ReclamationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReclamationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reclamations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reclamation>>> GetReclamations()
        {
          if (_context.Reclamations == null)
          {
              return NotFound();
          }
            return await _context.Reclamations.ToListAsync();
        }

        // GET: api/Reclamations/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Reclamation>> GetReclamation(int id)
        {
            var reclamation = await _context.Reclamations.FindAsync(id);
            if (reclamation == null)
                return NotFound($"La réclamation avec l'ID {id} n'a pas été trouvée.");

            return reclamation;
        }


        // PUT: api/Reclamations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReclamation(int id, Reclamation reclamation)
        {
            if (id != reclamation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reclamation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReclamationExists(id))
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

        // POST: api/Reclamations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reclamation>> PostReclamation(Reclamation reclamation)
        {
          if (_context.Reclamations == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Reclamations'  is null.");
          }
            _context.Reclamations.Add(reclamation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReclamation", new { id = reclamation.Id }, reclamation);
        }

        // DELETE: api/Reclamations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReclamation(int id)
        {
            if (_context.Reclamations == null)
            {
                return NotFound();
            }
            var reclamation = await _context.Reclamations.FindAsync(id);
            if (reclamation == null)
            {
                return NotFound();
            }

            _context.Reclamations.Remove(reclamation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReclamationExists(int id)
        {
            return (_context.Reclamations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

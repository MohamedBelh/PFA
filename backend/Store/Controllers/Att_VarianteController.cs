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
    public class Att_VarianteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Att_VarianteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Att_Variante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Att_Variante>>> Getatt_variantes()
        {
          if (_context.att_variantes == null)
          {
              return NotFound();
          }
            return await _context.att_variantes.ToListAsync();
        }

        // GET: api/Att_Variante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Att_Variante>> GetAtt_Variante(int id)
        {
          if (_context.att_variantes == null)
          {
              return NotFound();
          }
            var att_Variante = await _context.att_variantes.FindAsync(id);

            if (att_Variante == null)
            {
                return NotFound();
            }

            return att_Variante;
        }

        // PUT: api/Att_Variante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtt_Variante(int id, Att_Variante att_Variante)
        {
            if (id != att_Variante.Id)
            {
                return BadRequest();
            }

            _context.Entry(att_Variante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Att_VarianteExists(id))
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

        // POST: api/Att_Variante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Att_Variante>> PostAtt_Variante(Att_Variante att_Variante)
        {
          if (_context.att_variantes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.att_variantes'  is null.");
          }
            _context.att_variantes.Add(att_Variante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtt_Variante", new { id = att_Variante.Id }, att_Variante);
        }

        // DELETE: api/Att_Variante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtt_Variante(int id)
        {
            if (_context.att_variantes == null)
            {
                return NotFound();
            }
            var att_Variante = await _context.att_variantes.FindAsync(id);
            if (att_Variante == null)
            {
                return NotFound();
            }

            _context.att_variantes.Remove(att_Variante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Att_VarianteExists(int id)
        {
            return (_context.att_variantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

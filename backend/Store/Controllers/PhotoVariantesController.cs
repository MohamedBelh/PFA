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
    public class PhotoVariantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhotoVariantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoVariantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoVariante>>> GetphotoVariantes()
        {
          if (_context.photoVariantes == null)
          {
              return NotFound();
          }
            return await _context.photoVariantes.ToListAsync();
        }

        // GET: api/PhotoVariantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoVariante>> GetPhotoVariante(int id)
        {
          if (_context.photoVariantes == null)
          {
              return NotFound();
          }
            var photoVariante = await _context.photoVariantes.FindAsync(id);

            if (photoVariante == null)
            {
                return NotFound();
            }

            return photoVariante;
        }

        // PUT: api/PhotoVariantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoVariante(int id, PhotoVariante photoVariante)
        {
            if (id != photoVariante.IdPhoto)
            {
                return BadRequest();
            }

            _context.Entry(photoVariante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoVarianteExists(id))
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

        // POST: api/PhotoVariantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoVariante>> PostPhotoVariante(PhotoVariante photoVariante)
        {
          if (_context.photoVariantes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.photoVariantes'  is null.");
          }
            _context.photoVariantes.Add(photoVariante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoVariante", new { id = photoVariante.IdPhoto }, photoVariante);
        }

        // DELETE: api/PhotoVariantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoVariante(int id)
        {
            if (_context.photoVariantes == null)
            {
                return NotFound();
            }
            var photoVariante = await _context.photoVariantes.FindAsync(id);
            if (photoVariante == null)
            {
                return NotFound();
            }

            _context.photoVariantes.Remove(photoVariante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoVarianteExists(int id)
        {
            return (_context.photoVariantes?.Any(e => e.IdPhoto == id)).GetValueOrDefault();
        }
    }
}

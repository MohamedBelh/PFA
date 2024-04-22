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
    public class PhotoProduitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhotoProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoProduits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoProduit>>> GetphotoProduits()
        {
          if (_context.photoProduits == null)
          {
              return NotFound();
          }
            return await _context.photoProduits.ToListAsync();
        }

        // GET: api/PhotoProduits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoProduit>> GetPhotoProduit(int id)
        {
          if (_context.photoProduits == null)
          {
              return NotFound();
          }
            var photoProduit = await _context.photoProduits.FindAsync(id);

            if (photoProduit == null)
            {
                return NotFound();
            }

            return photoProduit;
        }

        // PUT: api/PhotoProduits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoProduit(int id, PhotoProduit photoProduit)
        {
            if (id != photoProduit.PhotoProduitId)
            {
                return BadRequest();
            }

            _context.Entry(photoProduit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoProduitExists(id))
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

        // POST: api/PhotoProduits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoProduit>> PostPhotoProduit(PhotoProduit photoProduit)
        {
          if (_context.photoProduits == null)
          {
              return Problem("Entity set 'ApplicationDbContext.photoProduits'  is null.");
          }
            _context.photoProduits.Add(photoProduit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoProduit", new { id = photoProduit.PhotoProduitId }, photoProduit);
        }

        // DELETE: api/PhotoProduits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoProduit(int id)
        {
            if (_context.photoProduits == null)
            {
                return NotFound();
            }
            var photoProduit = await _context.photoProduits.FindAsync(id);
            if (photoProduit == null)
            {
                return NotFound();
            }

            _context.photoProduits.Remove(photoProduit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoProduitExists(int id)
        {
            return (_context.photoProduits?.Any(e => e.PhotoProduitId == id)).GetValueOrDefault();
        }
    }
}

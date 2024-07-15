using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Data;
using API_Iresen.Models;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostinginstitutionsController : ControllerBase
    {
        private readonly DataContext _context;

        public HostinginstitutionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Hostinginstitutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hostinginstitution>>> GetHostinginstitutions()
        {
            return await _context.Hostinginstitutions.ToListAsync();
        }

        // GET: api/Hostinginstitutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hostinginstitution>> GetHostinginstitution(int id)
        {
            var hostinginstitution = await _context.Hostinginstitutions.FindAsync(id);

            if (hostinginstitution == null)
            {
                return NotFound();
            }

            return hostinginstitution;
        }

        // PUT: api/Hostinginstitutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHostinginstitution(int id, Hostinginstitution hostinginstitution)
        {
            if (id != hostinginstitution.Id)
            {
                return BadRequest();
            }

            _context.Entry(hostinginstitution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostinginstitutionExists(id))
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

        // POST: api/Hostinginstitutions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hostinginstitution>> PostHostinginstitution(Hostinginstitution hostinginstitution)
        {
            _context.Hostinginstitutions.Add(hostinginstitution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHostinginstitution", new { id = hostinginstitution.Id }, hostinginstitution);
        }

        // DELETE: api/Hostinginstitutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHostinginstitution(int id)
        {
            var hostinginstitution = await _context.Hostinginstitutions.FindAsync(id);
            if (hostinginstitution == null)
            {
                return NotFound();
            }

            _context.Hostinginstitutions.Remove(hostinginstitution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HostinginstitutionExists(int id)
        {
            return _context.Hostinginstitutions.Any(e => e.Id == id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Data;
using API_Iresen.Models;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCallsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectCallsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProjectCalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCall>>> GetProjectCalls()
        {
            return await _context.ProjectCalls.ToListAsync();
        }

        // GET: api/ProjectCalls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCall>> GetProjectCall(int id)
        {
            var projectCall = await _context.ProjectCalls.FindAsync(id);

            if (projectCall == null)
            {
                return NotFound();
            }

            return projectCall;
        }

        // POST: api/ProjectCalls
        [HttpPost]
        public async Task<ActionResult<ProjectCall>> PostProjectCall(ProjectCall projectCall)
        {
            _context.ProjectCalls.Add(projectCall);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectCall), new { id = projectCall.Id }, projectCall);
        }

        // PUT: api/ProjectCalls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectCall(int id, ProjectCall projectCall)
        {
            if (id != projectCall.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectCall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectCallExists(id))
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

        // DELETE: api/ProjectCalls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectCall(int id)
        {
            var projectCall = await _context.ProjectCalls.FindAsync(id);
            if (projectCall == null)
            {
                return NotFound();
            }

            _context.ProjectCalls.Remove(projectCall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectCallExists(int id)
        {
            return _context.ProjectCalls.Any(e => e.Id == id);
        }
    }
}

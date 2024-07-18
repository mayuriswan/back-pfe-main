using Microsoft.AspNetCore.Mvc;
using API_Iresen.Data;
using API_Iresen.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly DataContext _context;

        public SubmissionsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptSubmission(int id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }

            submission.IsAccepted = true;
            _context.Entry(submission).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectSubmission(int id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }

            submission.IsAccepted = false;
            _context.Entry(submission).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Data;
using API_Iresen.Models;
using Newtonsoft.Json;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/document")]
        public IActionResult GetProjectDocument(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null || string.IsNullOrEmpty(project.DocumentPath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(project.DocumentPath);
            var fileName = Path.GetFileName(project.DocumentPath);

            return File(fileBytes, "application/octet-stream", fileName);
        }

        [HttpGet("{id}/photo")]
        public IActionResult GetProjectPhoto(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null || string.IsNullOrEmpty(project.PhotoPath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(project.PhotoPath);
            var contentType = GetContentType(project.PhotoPath);

            return File(fileBytes, contentType);
        }

        private string GetContentType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }

            // GET: api/Projects
            [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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
       

       
        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromForm] Project project, IFormFile document, IFormFile photo)
        {
            // Create the "Attachments" folder if it doesn't exist
            string attachmentsPath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments");
            if (!Directory.Exists(attachmentsPath))
            {
                Directory.CreateDirectory(attachmentsPath);
            }

            // Update the IsPublic property based on the current date
            project.UpdateIsPublic();

            // Save the project to the database to get the project ID
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            // Create a folder named with the project ID inside the "Attachments" folder
            string projectFolderPath = Path.Combine(attachmentsPath, project.Id.ToString());
            Directory.CreateDirectory(projectFolderPath);

            // Save the document file
            if (document != null && document.Length > 0)
            {
                string documentPath = Path.Combine(projectFolderPath, "Document" + Path.GetExtension(document.FileName));
                using (var fileStream = new FileStream(documentPath, FileMode.Create))
                {
                    await document.CopyToAsync(fileStream);
                }
                project.DocumentPath = documentPath;
            }

            // Save the photo file
            if (photo != null && photo.Length > 0)
            {
                string photoPath = Path.Combine(projectFolderPath, "Image" + Path.GetExtension(photo.FileName));
                using (var fileStream = new FileStream(photoPath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
                project.PhotoPath = photoPath;
            }

            // Update the project again with the paths
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }
        // POST: api/Projects/createProjectFromEvaluation
        [HttpGet("{projectId}/submissions/{userId}")]
        public async Task<ActionResult<bool>> HasUserSubmitted(int projectId, int userId)
        {
            var hasSubmitted = await _context.Submissions
                .AnyAsync(s => s.ProjectId == projectId && s.UserId == userId);

            return Ok(hasSubmitted);
        }
        // GET: api/Projects/Responsible/5
        [HttpGet("Responsible/{responsibleId}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsForResponsible(int responsibleId)
        {
            var projects = await _context.Projects
                .Where(p => p.ResponsiblePersonId == responsibleId)
                .ToListAsync();

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }

        [HttpGet("{projectId}/submissions")]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissionsForProject(int projectId)
        {
            var submissions = await _context.Submissions
         .Where(s => s.ProjectId == projectId)
         .Include(s => s.User)
         .Include(s => s.StepValues)
             .ThenInclude(sv => sv.Fields)
         .Include(s => s.EvaluationNotes) // Include evaluation notes
         .ToListAsync();

            return Ok(submissions);
        }
    

        [HttpPost("{projectId}/addSubmission")]
        public async Task<ActionResult<Project>> AddSubmissionToProject(int projectId, [FromBody] Submission submission)
        {
            if (submission == null)
            {
                return BadRequest("Submission is required.");
            }

            var project = await _context.Projects
                .Include(p => p.Submissions)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound("Project not found");
            }

            submission.ProjectId = projectId;

            foreach (var stepValue in submission.StepValues)
            {
                stepValue.Id = 0; // Ensure new IDs are generated
                stepValue.SubmissionId = submission.Id; // Ensure correct foreign key relationship
                foreach (var field in stepValue.Fields)
                {
                    field.Id = 0; // Ensure new IDs are generated
                    field.StepValueId = stepValue.Id; // Ensure correct foreign key relationship
                }
            }

            _context.Submissions.Add(submission);
            project.NombreSubmissions = (project.NombreSubmissions ?? 0) + 1; // Increment the number of submissions

            await _context.SaveChangesAsync();

            return Ok(project);
        }
        [HttpGet("evaluator/{evaluatorId}/projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsForEvaluator(int evaluatorId)
        {
            var projects = await _context.Projects
                .Where(p => p.Evaluators.Contains(evaluatorId))
                .ToListAsync();

            return Ok(projects);
        }


        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Iresen.Data;

[Route("api/[controller]")]
[ApiController]
public class FormulairesController : ControllerBase
{
    private readonly DataContext _context;

    public FormulairesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Formulaire>>> GetFormulaires()
    {
        return await _context.Formulaires.Include(f => f.Etapes).ThenInclude(e => e.Champs).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Formulaire>> GetFormulaire(int id)
    {
        var formulaire = await _context.Formulaires.Include(f => f.Etapes).ThenInclude(e => e.Champs).FirstOrDefaultAsync(f => f.Id == id);

        if (formulaire == null)
        {
            return NotFound();
        }

        return formulaire;
    }

    [HttpPost]
    public async Task<ActionResult<Formulaire>> PostFormulaire(Formulaire formulaire)
    {
        _context.Formulaires.Add(formulaire);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFormulaire", new { id = formulaire.Id }, formulaire);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFormulaire(int id, Formulaire formulaire)
    {
        if (id != formulaire.Id)
        {
            return BadRequest();
        }

        _context.Entry(formulaire).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FormulaireExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFormulaire(int id)
    {
        var formulaire = await _context.Formulaires.FindAsync(id);
        if (formulaire == null)
        {
            return NotFound();
        }

        _context.Formulaires.Remove(formulaire);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FormulaireExists(int id)
    {
        return _context.Formulaires.Any(e => e.Id == id);
    }
}
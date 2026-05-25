using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course.CloudNativeDev.Api.Contracts.Requests;
using Course.CloudNativeDev.Api.Data;
using Course.CloudNativeDev.Api.Entities;

namespace Course.CloudNativeDev.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GendersController(AppDbContext context) : ControllerBase
{
    // GET: api/Genders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
    {
        return await context.Genders.ToListAsync();
    }

    // GET: api/Genders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Gender>> GetGender(Guid id)
    {
        var gender = await context.Genders.FindAsync(id);

        if (gender == null)
        {
            return NotFound();
        }

        return gender;
    }

    // PUT: api/Genders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGender(Guid id, Gender gender)
    {
        if (id != gender.Id)
        {
            return BadRequest();
        }

        context.Entry(gender).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GenderExists(id))
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

    // POST: api/Genders
    [HttpPost]
    public async Task<ActionResult<Gender>> PostGender(CreateGenderRequest request)
    {
        var gender = new Gender
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        context.Genders.Add(gender);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetGender", new { id = gender.Id }, gender);
    }

    // DELETE: api/Genders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGender(Guid id)
    {
        var gender = await context.Genders.FindAsync(id);
        if (gender == null)
        {
            return NotFound();
        }

        context.Genders.Remove(gender);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool GenderExists(Guid id)
    {
        return context.Genders.Any(e => e.Id == id);
    }
}

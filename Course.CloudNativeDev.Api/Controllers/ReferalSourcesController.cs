using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course.CloudNativeDev.Api.Contracts.Requests;
using Course.CloudNativeDev.Api.Data;
using Course.CloudNativeDev.Api.Entities;

namespace Course.CloudNativeDev.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReferalSourcesController(AppDbContext context) : ControllerBase
{
    // GET: api/ReferalSources
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReferalSource>>> GetReferalSources()
    {
        return await context.ReferalSources.ToListAsync();
    }

    // GET: api/ReferalSources/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReferalSource>> GetReferalSource(Guid id)
    {
        var referalSource = await context.ReferalSources.FindAsync(id);

        if (referalSource == null)
        {
            return NotFound();
        }

        return referalSource;
    }

    // PUT: api/ReferalSources/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReferalSource(Guid id, ReferalSource referalSource)
    {
        if (id != referalSource.Id)
        {
            return BadRequest();
        }

        context.Entry(referalSource).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReferalSourceExists(id))
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

    // POST: api/ReferalSources
    [HttpPost]
    public async Task<ActionResult<ReferalSource>> PostReferalSource(CreateReferalSourceRequest request)
    {
        var referalSource = new ReferalSource
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        context.ReferalSources.Add(referalSource);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetReferalSource", new { id = referalSource.Id }, referalSource);
    }

    // DELETE: api/ReferalSources/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReferalSource(Guid id)
    {
        var referalSource = await context.ReferalSources.FindAsync(id);
        if (referalSource == null)
        {
            return NotFound();
        }

        context.ReferalSources.Remove(referalSource);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReferalSourceExists(Guid id)
    {
        return context.ReferalSources.Any(e => e.Id == id);
    }
}

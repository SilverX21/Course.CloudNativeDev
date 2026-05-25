using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course.CloudNativeDev.Api.Contracts.Requests;
using Course.CloudNativeDev.Api.Data;
using Course.CloudNativeDev.Api.Entities;

namespace Course.CloudNativeDev.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobRolesController(AppDbContext context) : ControllerBase
{
    // GET: api/JobRoles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobRole>>> GetJobRoles()
    {
        return await context.JobRoles.ToListAsync();
    }

    // GET: api/JobRoles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JobRole>> GetJobRole(Guid id)
    {
        var jobRole = await context.JobRoles.FindAsync(id);

        if (jobRole == null)
        {
            return NotFound();
        }

        return jobRole;
    }

    // PUT: api/JobRoles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJobRole(Guid id, JobRole jobRole)
    {
        if (id != jobRole.Id)
        {
            return BadRequest();
        }

        context.Entry(jobRole).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobRoleExists(id))
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

    // POST: api/JobRoles
    [HttpPost]
    public async Task<ActionResult<JobRole>> PostJobRole(CreateJobRoleRequest request)
    {
        var jobRole = new JobRole
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        context.JobRoles.Add(jobRole);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetJobRole", new { id = jobRole.Id }, jobRole);
    }

    // DELETE: api/JobRoles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobRole(Guid id)
    {
        var jobRole = await context.JobRoles.FindAsync(id);
        if (jobRole == null)
        {
            return NotFound();
        }

        context.JobRoles.Remove(jobRole);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool JobRoleExists(Guid id)
    {
        return context.JobRoles.Any(e => e.Id == id);
    }
}

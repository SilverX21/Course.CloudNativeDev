using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course.CloudNativeDev.Api.Contracts.Requests;
using Course.CloudNativeDev.Api.Data;
using Course.CloudNativeDev.Api.Entities;

namespace Course.CloudNativeDev.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendeesController(AppDbContext context) : ControllerBase
{
    // GET: api/Attendees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendee()
    {
        return await context.Attendee.ToListAsync();
    }

    // GET: api/Attendees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Attendee>> GetAttendee(Guid id)
    {
        var attendee = await context.Attendee.FindAsync(id);

        if (attendee == null)
        {
            return NotFound();
        }

        return attendee;
    }

    // PUT: api/Attendees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAttendee(Guid id, Attendee attendee)
    {
        if (id != attendee.Id)
        {
            return BadRequest();
        }

        context.Entry(attendee).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AttendeeExists(id))
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

    // POST: api/Attendees
    [HttpPost]
    public async Task<ActionResult<Attendee>> PostAttendee(CreateAttendeeRequest request)
    {
        var attendee = new Attendee
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LAstNAme = request.LastName,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber,
            CompanyName = request.CompanyName,
            GenderId = request.GenderId,
            JobRoleId = request.JobRoleId,
            ReferalSourceId = request.ReferalSourceId
        };

        context.Attendee.Add(attendee);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetAttendee", new { id = attendee.Id }, attendee);
    }

    // DELETE: api/Attendees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendee(Guid id)
    {
        var attendee = await context.Attendee.FindAsync(id);
        if (attendee == null)
        {
            return NotFound();
        }

        context.Attendee.Remove(attendee);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool AttendeeExists(Guid id)
    {
        return context.Attendee.Any(e => e.Id == id);
    }
}
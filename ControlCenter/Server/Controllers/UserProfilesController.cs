using ControlCenter.Server.DbContex;
using ControlCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlCenter.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserProfilesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/UserProfiles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfile()
    {
        return await _context.UserProfile.ToListAsync();
    }

    // GET: api/UserProfiles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(Guid id)
    {
        var userProfile = await _context.UserProfile.FindAsync(id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return userProfile;
    }

    // PUT: api/UserProfiles/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUserProfile(Guid id, UserProfile userProfile)
    {
        if (id != userProfile.UserId)
        {
            return BadRequest();
        }

        _context.Entry(userProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserProfileExists(id))
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

    // POST: api/UserProfiles
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
    {
        _context.UserProfile.Add(userProfile);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (UserProfileExists(userProfile.UserId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetUserProfile", new { id = userProfile.UserId }, userProfile);
    }

    // DELETE: api/UserProfiles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(Guid id)
    {
        var userProfile = await _context.UserProfile.FindAsync(id);
        if (userProfile == null)
        {
            return NotFound();
        }

        _context.UserProfile.Remove(userProfile);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserProfileExists(Guid id)
    {
        return _context.UserProfile.Any(e => e.UserId == id);
    }
}

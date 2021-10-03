using ControlCenter.Server.DbContex;
using ControlCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlCenter.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BotsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Bots
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bot>>> GetBots()
    {
        return await _context.Bots.ToListAsync();
    }

    // GET: api/Bots/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bot>> GetBot(Guid id)
    {
        var bot = await _context.Bots.FindAsync(id);

        if (bot == null)
        {
            return NotFound();
        }

        return bot;
    }

    // PUT: api/Bots/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBot(Guid id, Bot bot)
    {
        if (id != bot.BotId)
        {
            return BadRequest();
        }

        _context.Entry(bot).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BotExists(id))
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

    // POST: api/Bots
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bot>> PostBot(Bot bot)
    {
        _context.Bots.Add(bot);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBot", new { id = bot.BotId }, bot);
    }

    // DELETE: api/Bots/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBot(Guid id)
    {
        var bot = await _context.Bots.FindAsync(id);
        if (bot == null)
        {
            return NotFound();
        }

        _context.Bots.Remove(bot);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BotExists(Guid id)
    {
        return _context.Bots.Any(e => e.BotId == id);
    }
}

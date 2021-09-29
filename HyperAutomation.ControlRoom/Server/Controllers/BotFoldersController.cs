using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HyperAutomation.ControlRoom.Server.Models;
using HyperAutomation.ControlRoom.Shared.Models;

namespace HyperAutomation.ControlRoom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotFoldersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BotFoldersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BotFolders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BotFolder>>> GetBotFolder()
        {
            return await _context.BotFolder.Include(b => b.ModifiedBy).ToListAsync();
        }

        // GET: api/BotFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BotFolder>> GetBotFolder(Guid id)
        {
            var botFolder = await _context.BotFolder.FindAsync(id);

            if (botFolder == null)
            {
                return NotFound();
            }

            return botFolder;
        }

        // PUT: api/BotFolders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBotFolder(Guid id, BotFolder botFolder)
        {
            if (id != botFolder.BotFolderId)
            {
                return BadRequest();
            }

            _context.Entry(botFolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotFolderExists(id))
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

        // POST: api/BotFolders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BotFolder>> PostBotFolder(BotFolder botFolder)
        {
            _context.BotFolder.Add(botFolder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBotFolder", new { id = botFolder.BotFolderId }, botFolder);
        }

        // DELETE: api/BotFolders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBotFolder(Guid id)
        {
            var botFolder = await _context.BotFolder.FindAsync(id);
            if (botFolder == null)
            {
                return NotFound();
            }

            _context.BotFolder.Remove(botFolder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BotFolderExists(Guid id)
        {
            return _context.BotFolder.Any(e => e.BotFolderId == id);
        }
    }
}

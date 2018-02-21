using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimeChessAlphaSeven.Models.RealTimeChessModels;

namespace RealTimeChessAlphaSeven.Controllers
{
    [Produces("application/json")]
    [Route("api/PlayerTypes")]
    public class PlayerTypesController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public PlayerTypesController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerTypes
        [HttpGet]
        public IEnumerable<PlayerType> GetPlayerTypess()
        {
            return _context.PlayerTypess;
        }

        // GET: api/PlayerTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerType = await _context.PlayerTypess.SingleOrDefaultAsync(m => m.PlayerTypeId == id);

            if (playerType == null)
            {
                return NotFound();
            }

            return Ok(playerType);
        }

        // PUT: api/PlayerTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerType([FromRoute] int id, [FromBody] PlayerType playerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerType.PlayerTypeId)
            {
                return BadRequest();
            }

            _context.Entry(playerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerTypeExists(id))
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

        // POST: api/PlayerTypes
        [HttpPost]
        public async Task<IActionResult> PostPlayerType([FromBody] PlayerType playerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlayerTypess.Add(playerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerType", new { id = playerType.PlayerTypeId }, playerType);
        }

        // DELETE: api/PlayerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerType = await _context.PlayerTypess.SingleOrDefaultAsync(m => m.PlayerTypeId == id);
            if (playerType == null)
            {
                return NotFound();
            }

            _context.PlayerTypess.Remove(playerType);
            await _context.SaveChangesAsync();

            return Ok(playerType);
        }

        private bool PlayerTypeExists(int id)
        {
            return _context.PlayerTypess.Any(e => e.PlayerTypeId == id);
        }
    }
}
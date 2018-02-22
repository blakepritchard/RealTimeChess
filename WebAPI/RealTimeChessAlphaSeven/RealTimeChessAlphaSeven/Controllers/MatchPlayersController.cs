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
    [Route("api/MatchPlayers")]
    public class MatchPlayersController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public MatchPlayersController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/MatchPlayers
        [HttpGet]
        public IEnumerable<MatchPlayer> GetMatchPlayers()
        {
            return _context.MatchPlayers;
        }

        // GET: api/MatchPlayers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MatchPlayer), 200)]
        public async Task<IActionResult> GetMatchPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchPlayer = await _context.MatchPlayers.SingleOrDefaultAsync(m => m.MatchPlayerId == id);

            if (matchPlayer == null)
            {
                return NotFound();
            }

            return Ok(matchPlayer);
        }

        // PUT: api/MatchPlayers/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 204)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> PutMatchPlayer([FromRoute] int id, [FromBody] MatchPlayer matchPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matchPlayer.MatchPlayerId)
            {
                return BadRequest();
            }

            _context.Entry(matchPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchPlayerExists(id))
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

        // POST: api/MatchPlayers
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> PostMatchPlayer([FromBody] MatchPlayer matchPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MatchPlayers.Add(matchPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchPlayer", new { id = matchPlayer.MatchPlayerId }, matchPlayer);
        }

        // DELETE: api/MatchPlayers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> DeleteMatchPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchPlayer = await _context.MatchPlayers.SingleOrDefaultAsync(m => m.MatchPlayerId == id);
            if (matchPlayer == null)
            {
                return NotFound();
            }

            _context.MatchPlayers.Remove(matchPlayer);
            await _context.SaveChangesAsync();

            return Ok(matchPlayer);
        }

        private bool MatchPlayerExists(int id)
        {
            return _context.MatchPlayers.Any(e => e.MatchPlayerId == id);
        }
    }
}
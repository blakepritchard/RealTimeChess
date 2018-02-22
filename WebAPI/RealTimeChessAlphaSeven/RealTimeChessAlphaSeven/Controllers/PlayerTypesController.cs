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
        public IEnumerable<PlayerType> GetPlayerTypes()
        {
            return _context.PlayerTypes;
        }

        // GET: api/PlayerTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerType), 200)]
        public async Task<IActionResult> GetPlayerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerType = await _context.PlayerTypes.SingleOrDefaultAsync(m => m.PlayerTypeId == id);

            if (playerType == null)
            {
                return NotFound();
            }

            return Ok(playerType);
        }

        // PUT: api/PlayerTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 204)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
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
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> PostPlayerType([FromBody] PlayerType playerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlayerTypes.Add(playerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerType", new { id = playerType.PlayerTypeId }, playerType);
        }

        // DELETE: api/PlayerTypes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> DeletePlayerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerType = await _context.PlayerTypes.SingleOrDefaultAsync(m => m.PlayerTypeId == id);
            if (playerType == null)
            {
                return NotFound();
            }

            _context.PlayerTypes.Remove(playerType);
            await _context.SaveChangesAsync();

            return Ok(playerType);
        }

        private bool PlayerTypeExists(int id)
        {
            return _context.PlayerTypes.Any(e => e.PlayerTypeId == id);
        }
    }
}
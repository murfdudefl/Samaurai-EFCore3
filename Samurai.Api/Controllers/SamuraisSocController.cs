using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Business;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisSocController : ControllerBase
    {
        private readonly BusinessDataLogic _busLogic;

        public SamuraisSocController(BusinessDataLogic busLogic)
        {
            _busLogic = busLogic;
        }

        // GET: api/Samurais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        {
            return await _busLogic.GetAllSamurais();
        }

        // GET: api/Samurais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _busLogic.GetSamurai(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        // PUT: api/Samurais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamurai(Samurai samurai)
        {
            try
            {
                await _busLogic.UpdateSamurai(samurai);
            }
            return NoContent();
        }

        // POST: api/Samurais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Samurai>> PostSamurai(Samurai samurai)
        {
            await _busLogic.CreateSamurai(samurai);
            return CreatedAtAction("GetSamurai", new { id = samurai.Id }, samurai);
        }

        // DELETE: api/Samurais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Samurai>> DeleteSamurai(int id)
        {
            await _busLogic.DeleteSamurai()
            var samurai = await _context.Samurais.FindAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }

            _context.Samurais.Remove(samurai);
            await _context.SaveChangesAsync();

            return samurai;
        }

        private bool SamuraiExists(int id)
        {
            return _context.Samurais.Any(e => e.Id == id);
        }
    }
}

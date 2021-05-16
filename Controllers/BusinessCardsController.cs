using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Cards_Web_API.Model;
using Business_Cards_Web_API.Models;

namespace Business_Cards_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCardsController : ControllerBase
    {
        private readonly Business_Cards_DataContext _context;

        public BusinessCardsController(Business_Cards_DataContext context)
        {
            _context = context;
        }

        // GET: api/BusinessCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessCard>>> GetBusinessCard()
        {
            return await (from cards in _context.BusinessCard select cards).ToListAsync();
        }

        // GET: api/BusinessCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCard>> GetBusinessCard(int id)
        {
            var businessCard = await _context.BusinessCard.FindAsync(id);

            if (businessCard == null)
            {
                return NotFound();
            }

            return businessCard;
        }

        // PUT: api/BusinessCards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessCard(int id, BusinessCard businessCard)
        {
            if (id != businessCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessCardExists(id))
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

        // POST: api/BusinessCards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BusinessCard>> PostBusinessCard(BusinessCard businessCard)
        {
            _context.BusinessCard.Add(businessCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessCard", new { id = businessCard.Id }, businessCard);
        }

        // DELETE: api/BusinessCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessCard>> DeleteBusinessCard(int id)
        {
            var businessCard = await _context.BusinessCard.FindAsync(id);
            if (businessCard == null)
            {
                return NotFound();
            }

            _context.BusinessCard.Remove(businessCard);
            await _context.SaveChangesAsync();

            return businessCard;
        }

        private bool BusinessCardExists(int id)
        {
            return _context.BusinessCard.Any(e => e.Id == id);
        }
    }
}

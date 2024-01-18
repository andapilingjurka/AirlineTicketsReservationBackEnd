using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervimiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public RezervimiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var rezervimet = await _db.Rezervimet
                .Include(r => r.Fluturimi)
                .ToListAsync();

            return Ok(rezervimet);
        }

        [HttpPost]
        [Route("AddRezervimi")]
        // [Authorize(Roles ="user")]
        public async Task<IActionResult> AddRezervimiAsync(Rezervimi rezervimi)
        {

            var existingFlight = await _db.Fluturimet.FindAsync(rezervimi.FluturimiId);

            if (existingFlight == null)
            {
                return NotFound("Fluturimi or Perdoruesi not found.");
            }

            rezervimi.Fluturimi = existingFlight;



            _db.Rezervimet.Add(rezervimi);
            await _db.SaveChangesAsync();
            return Created($"/GetRezervimiById/{rezervimi.Id}", rezervimi);

        }

        [HttpGet]
        [Route("GetRezervimiById/{id}")]
        public async Task<IActionResult> GetRezervimiByIdAsync(int id)
        {
            var rezervimi = await _db.Rezervimet
                .Include(r => r.Fluturimi)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rezervimi == null)
            {
                return NotFound();
            }

            return Ok(rezervimi);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateRezervimiAsync(int id, Rezervimi rezervimi)
        {
            if (id != rezervimi.Id)
            {
                return BadRequest();
            }

            var existingFlight = await _db.Fluturimet.FindAsync(rezervimi.FluturimiId);


            if (existingFlight == null)
            {
                return NotFound("Fluturimi  not found.");
            }

            rezervimi.Fluturimi = existingFlight;




            _db.Entry(rezervimi).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervimiExists(id))
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

        [HttpDelete]
        [Route("Delete")]
        // Delete
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var rezervimiIdDelete = await _db.Rezervimet.Include(q => q.Fluturimi).FirstOrDefaultAsync(q => q.Id == Id);

            if (rezervimiIdDelete == null)
            {
                return NotFound();
            }

            _db.Rezervimet.Remove(rezervimiIdDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }



        private bool RezervimiExists(int id)
        {
            return _db.Rezervimet.Any(r => r.Id == id);
        }
    }

}
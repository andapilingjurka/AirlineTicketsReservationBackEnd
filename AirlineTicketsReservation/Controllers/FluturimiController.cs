using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluturimiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FluturimiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var fluturimi = await _db.Fluturimet.Include(q => q.Aeroplani).Include(q => q.Qyteti).ToListAsync();
            return Ok(fluturimi);
        }

        // GetById
        [HttpGet]
        [Route("GetFluturimiById")]
        public async Task<IActionResult> GetFluturimiByIdAsync(int Id)
        {
            var fluturimi = await _db.Fluturimet
                .Include(q => q.Aeroplani)
                .Include(q => q.Qyteti)
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (fluturimi == null)
            {
                return NotFound();
            }

            return Ok(fluturimi);
        }

        // Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostAsync(Fluturimi fluturimi)
        {
            // Check if the associated AeroplaniId and QytetiId exist
            var existingFlight = await _db.Aeroplani.FindAsync(fluturimi.AeroplaniId);
            var existingCity = await _db.Qyteti.FindAsync(fluturimi.QytetiId);

            if (existingFlight == null || existingCity == null)
            {
                return NotFound($"Aeroplani me ID {fluturimi.AeroplaniId} ose Qyteti me ID {fluturimi.QytetiId} nuk ekziston.");
            }

            fluturimi.Aeroplani = existingFlight;
            fluturimi.Qyteti = existingCity;

            _db.Fluturimet.Add(fluturimi);
            await _db.SaveChangesAsync();

            return Created($"/GetFluturimiById/{fluturimi.Id}", fluturimi);
        }

        // Update
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutAsync(Fluturimi fluturimi)
        {
            // Check if the associated AeroplaniId and QytetiId exist
            var existingPlane = await _db.Aeroplani.FindAsync(fluturimi.AeroplaniId);
            var existingCity = await _db.Qyteti.FindAsync(fluturimi.QytetiId);

            if (existingPlane == null || existingCity == null)
            {
                return NotFound($"Aeroplani me ID {fluturimi.AeroplaniId} ose Qyteti me ID {fluturimi.QytetiId} nuk ekziston.");
            }

            fluturimi.Aeroplani = existingPlane;
            fluturimi.Qyteti = existingCity;

            _db.Fluturimet.Update(fluturimi);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var fluturimiIdDelete = await _db.Fluturimet.Include(q => q.Aeroplani).Include(q => q.Qyteti).FirstOrDefaultAsync(q => q.Id == Id);

            if (fluturimiIdDelete == null)
            {
                return NotFound();
            }

            _db.Fluturimet.Remove(fluturimiIdDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}

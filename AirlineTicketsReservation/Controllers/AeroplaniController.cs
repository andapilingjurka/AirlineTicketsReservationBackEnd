using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroplaniController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AeroplaniController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var aeroplani = await _db.Aeroplani.ToListAsync();
            return Ok(aeroplani);
        }

        //GetById
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetShtetiByIdAsync(int Id)
        {
            var aeroplani = await _db.Aeroplani.FindAsync(Id);
            return Ok(aeroplani);
        }

        //Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostAsync(Aeroplani aeroplani)
        {
            _db.Aeroplani.Add(aeroplani);
            await _db.SaveChangesAsync();
            return Created($"/GetUserById/{aeroplani.Id}", aeroplani);
        }
        //Update
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutAsync(Aeroplani aeroplani)
        {
            _db.Aeroplani.Update(aeroplani);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var aeroplaniIdDelete = await _db.Aeroplani.FindAsync(Id);
            if (aeroplaniIdDelete == null)
            {
                return NotFound();
            }
            _db.Aeroplani.Remove(aeroplaniIdDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}

using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShtetiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ShtetiController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var shteti = await _db.Shteti.ToListAsync();
            return Ok(shteti);
        }

        //GetById
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetShtetiByIdAsync(int Id)
        {
            var shteti = await _db.Shteti.FindAsync(Id);
            return Ok(shteti);
        }

        //Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostAsync(Shteti shteti)
        {
            _db.Shteti.Add(shteti);
            await _db.SaveChangesAsync();
            return Created($"/GetUserById/{shteti.Id}", shteti);
        }

        //Update
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutAsync(Shteti shteti)
        {
            _db.Shteti.Update(shteti);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var shtetiIdDelete = await _db.Shteti.FindAsync(Id);
            if (shtetiIdDelete == null)
            {
                return NotFound();
            }
            _db.Shteti.Remove(shtetiIdDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}

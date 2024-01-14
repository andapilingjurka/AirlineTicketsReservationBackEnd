using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsReservation.Data;
using TicketsReservation.Model;

namespace TicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontaktController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public KontaktController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var Kontakti = await _db.Kontakti.ToListAsync();
            return Ok(Kontakti);
        }

        //GetById
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetAeroplaniByIdAsync(int Id)
        {
            var kontakti = await _db.Kontakti.FindAsync(Id);
            return Ok(kontakti);
        }

        //Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostAsync(Kontakti kontakti)
        {
            _db.Kontakti.Add(kontakti);
            await _db.SaveChangesAsync();
            return Created($"/GetUserById/{kontakti.KontaktID}", kontakti);
        }



        //Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var contactDelete = await _db.Kontakti.FindAsync(Id);
            if (contactDelete == null)
            {
                return NotFound();
            }
            _db.Kontakti.Remove(contactDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
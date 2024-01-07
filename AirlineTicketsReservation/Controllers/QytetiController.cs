using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QytetiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public QytetiController(ApplicationDbContext db)
        {
            _db = db;
        }

        //ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var qyteti = await _db.Qyteti.Include(q => q.Shteti).ToListAsync();
            return Ok(qyteti);
        }

        //GetById
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetQytetiByIdAsync(int Id)
        {
            var qyteti = await _db.Qyteti.Include(q => q.Shteti).FirstOrDefaultAsync(q => q.Id == Id);
            return Ok(qyteti);
        }

        //Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostAsync(Qyteti qyteti)
        {
            // Kontrollo nëse shteti ekziston
            var existingState = await _db.Shteti.FindAsync(qyteti.ShtetiId);
            if (existingState == null)
            {
                return NotFound($"Shteti me ID {qyteti.ShtetiId} nuk ekziston.");
            }

            qyteti.Shteti = existingState;

            _db.Qyteti.Add(qyteti);
            await _db.SaveChangesAsync();
            return Created($"/GetUserById/{qyteti.Id}", qyteti);
        }

        //Update
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutAsync(Qyteti qyteti)
        {
            // Kontrollo nëse shteti ekziston
            var existingState = await _db.Shteti.FindAsync(qyteti.ShtetiId);
            if (existingState == null)
            {
                return NotFound($"Shteti me ID {qyteti.ShtetiId} nuk ekziston.");
            }

            qyteti.Shteti = existingState;

            _db.Qyteti.Update(qyteti);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var qytetiIdDelete = await _db.Qyteti.Include(q => q.Shteti).FirstOrDefaultAsync(q => q.Id == Id);

            if (qytetiIdDelete == null)
            {
                return NotFound();
            }

            _db.Qyteti.Remove(qytetiIdDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        //Metoda per filtrim

        [HttpGet]
        [Route("GetFilteredQyteti")]
        public async Task<IActionResult> GetFilteredQytetiAsync([FromQuery] string orderBy)
        {
            IQueryable<Qyteti> qytetiQuery = _db.Qyteti.Include(q => q.Shteti);

            switch (orderBy)
            {
                case "A-Z":
                    qytetiQuery = qytetiQuery.OrderBy(q => q.Emri);
                    break;
                case "Z-A":
                    qytetiQuery = qytetiQuery.OrderByDescending(q => q.Emri);
                    break;
                default:
                    return BadRequest("Invalid orderBy parameter. Use 'A-Z' or 'Z-A'.");
            }

            var qyteti = await qytetiQuery.ToListAsync();
            return Ok(qyteti);
        }

    }
}

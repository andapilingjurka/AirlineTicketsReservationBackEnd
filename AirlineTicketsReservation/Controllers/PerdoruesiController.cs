using AirlineTicketsReservation.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerdoruesiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PerdoruesiController(ApplicationDbContext userDbContext)
        {
            _db = userDbContext;
        }

        //ListAll
        [HttpGet]
        [Route("GetAllList")]
        public async Task<IActionResult> GetAsync()
        {
            var Perdoruesit = await _db.Perdoruesit.ToListAsync();
            return Ok(Perdoruesit);
        }


        //Delete
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var perdoruesiDelete = await _db.Perdoruesit.FindAsync(Id);
            if (perdoruesiDelete == null)
            {
                return NotFound();
            }
            _db.Perdoruesit.Remove(perdoruesiDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }
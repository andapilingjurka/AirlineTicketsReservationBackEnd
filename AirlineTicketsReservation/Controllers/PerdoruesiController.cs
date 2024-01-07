using AirlineTicketsReservation.Data;
using AirlineTicketsReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Perdoruesi objUser)
        {
            var dbuser = _db.Perdoruesit.Where(u => u.Email == objUser.Email).FirstOrDefault();
            if (dbuser != null)
            {
                return BadRequest("Emaili ekziston!");
            }


            // Generate salt and hash password using bcrypt algorithm
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(objUser.Password, salt);

            objUser.Password = hashedPassword; // Save hashed password in the database
            _db.Perdoruesit.Add(objUser);
            await _db.SaveChangesAsync();
            return Ok("Regjistrimi u shtua me sukses.");

        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(Login user)
        {
            var userInDb = await _db.Perdoruesit.SingleOrDefaultAsync(u => u.Email == user.Email);

            if (userInDb == null || !BCrypt.Net.BCrypt.Verify(user.Password, userInDb.Password))
            {
                return BadRequest("Emaili ose Fjalekalimi gabim.");
            }

            var role = userInDb.role;

            // Create claims for the token
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, userInDb.Email),
        new Claim(ClaimTypes.Role, role)
    };

            // Generate symmetric security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyWithAtLeast16Characters"));

            // Generate signing credentials using the security key
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1), // Set token expiration
                SigningCredentials = credentials
            };

            // Create a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate token based on the token descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);


            // Convert token to a string
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

    }
}

using loginn.Data;
using loginn.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loginn.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db)
        {
            _db = db; 
        }
        [HttpPost("Register")]
        public ActionResult<UserDTO> RegisterUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            User user = new();
            {
                int Id = 1;
                string Name = userDTO.username;
                string Password = userDTO.Password;

            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return (ActionResult)Ok("User registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] UserDTO userDTO)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.username == userDTO.username && u.Password == userDTO.Password );
            if (user == null)
            {
                return BadRequest("Invalid username or password !");
            }
            var users = _db.Users.ToList();
            Console.WriteLine(users);
            return Ok(user);
        }

        [HttpGet("Get Peofile")]
        public IActionResult GetProfile(int Id)
        {
           
            var loggedInUserId = 1; 
            if (Id != loggedInUserId)
            {
                return BadRequest();
            }

           
            var userProfile = _db.Users.FirstOrDefault(u => u.Id == Id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }
    }
}


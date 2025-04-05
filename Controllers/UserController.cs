using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.Models;

namespace Riid.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user){
            _appDbContext.User.Add(user);
            await _appDbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> getUsers(){
            var users = await _appDbContext.User.ToListAsync();
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(long id, string cpf, string email, string name, string password){
            var user = await _appDbContext.User.FindAsync(id);
            
            if(id < 0 || user == null) return NotFound();

            user.Cpf = cpf;
            user.Email = email;
            user.Name = name;
            user.Password = password;

            return Ok(user);
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult<UserModel>> DeleteUser(long Id){
            try
            {
                var userToDelete = await _appDbContext.User.FindAsync(Id);

                if(userToDelete == null) return NotFound();

                _appDbContext.User.Remove(userToDelete);
                await _appDbContext.SaveChangesAsync();
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro deleting data");
            }
        }
    }
}

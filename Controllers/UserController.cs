using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.DTO;
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
        public async Task<IActionResult> AddUser(UserDTO userDTO){
            
            var user = new UserModel
            {
                Id = userDTO.Id,
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password
            };

            _appDbContext.User.Add(user);
            await _appDbContext.SaveChangesAsync();

            return Ok("User created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> getUsers(){
            
            var users = await _appDbContext.User.Select(u => new UserDTO{
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
                Password = u.Password
            }).ToListAsync();

            return Ok(users);

        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutUser(long id, [FromBody]UserDTO userBody){
            var user = await _appDbContext.User.FindAsync(id);
            
            if(id < 0 || user == null) return NotFound();

            user.Email = userBody.Email;
            user.Name = userBody.Name;
            user.Password = userBody.Password;

            _appDbContext.SaveChanges();

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

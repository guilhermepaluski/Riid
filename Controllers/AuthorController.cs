using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.DTO;
using Riid.Models;

namespace Riid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> createAuthor([FromBody] AuthorDTO authorBody)
        {

            var author = new AuthorModel
            {
                Id = authorBody.Id,
                Name = authorBody.Name,
                Books = new List<BookModel>()
            };

            _db.Author.Add(author);
            await _db.SaveChangesAsync();

            return Ok("Author '"+authorBody.Name+"' created");
        }

        [HttpGet]
        public async Task<ActionResult<AuthorModel>> getAllAuthors()
        {
            var authors = await _db.Author.Select(a => new AuthorDTO {
                Id = a.Id,
                Name = a.Name
            }).ToListAsync();

            return Ok(authors);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult<AuthorModel>> putAuthor(long id, [FromBody] AuthorDTO authorBody)
        {
            var author = await _db.Author.FindAsync(id);

            if(author == null) return NotFound("Author not found!");

            author.Name = authorBody.Name;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult<AuthorModel>> deleteAuthor(long id)
        {
            var author = await _db.Author.FindAsync(id);

            if(author == null) return NotFound("Author not found!");

            _db.Author.Remove(author);
            await _db.SaveChangesAsync();

            return Ok("Author deleted in database!");
        }
    }
}
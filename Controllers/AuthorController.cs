using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.Models;

namespace Riid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthorController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorModel>> createAuthor([FromBody]AuthorModel authorBody)
        {
            // var author = await _db.Author.FindAsync(authorBody.Name);

            // if(author != null) return BadRequest("Author already exists!");

            await _db.Author.AddAsync(authorBody);
            await _db.SaveChangesAsync();

            return Ok("Author '"+authorBody.Name+"' created");
        }

        [HttpGet]
        public async Task<ActionResult<AuthorModel>> getAllAuthors()
        {
            var authors = await _db.Author.ToListAsync();
            return Ok(authors);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult<AuthorModel>> putAuthor(long id, [FromBody]AuthorModel authorBody)
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
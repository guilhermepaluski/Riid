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
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BookController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createBook([FromBody] BookModel book)
        {
            _db.Book.Add(book);
            await _db.SaveChangesAsync();

            return Ok("Book created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> getAllBooks()
        {
            var books = await _db.Book.ToListAsync();

            return Ok(books);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult> putBook(long id, [FromBody]BookModel BookBody)
        {
            var book = await _db.Book.FindAsync(id);

            if(book == null) return NotFound("Book not found!");
            
            book.Image = BookBody.Image;
            book.Name = BookBody.Name;
            book.Pages = BookBody.Pages;
            book.Fk_author = BookBody.Fk_author;
            book.Fk_category = BookBody.Fk_category;

            await _db.SaveChangesAsync();
            
            return Ok("Book '"+book.Name+"' edited successfully!");
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult> removeBook(long id)
        {
            var book = await _db.Book.FindAsync(id);

            if(book == null) return NotFound();

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return Ok();
        }   
    }
}
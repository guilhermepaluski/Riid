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
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BookController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createBook([FromBody] BookDTO bookDTO)
        {
            var book = new BookModel
            {
                Id = bookDTO.Id,
                Image = bookDTO.Image,
                Name = bookDTO.Name,
                Pages = bookDTO.Pages,
                Fk_category = bookDTO.Fk_category,
                Fk_author = bookDTO.Fk_author
            };

            _db.Book.Add(book);
            await _db.SaveChangesAsync();

            return Ok("Book created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<BookModel>> getAllBooks()
        {
            var books = await _db.Book.Select(b => new BookDTO{
                Id = b.Id,
                Image = b.Image,
                Name = b.Name,
                Pages = b.Pages,
                Fk_category = b.Fk_category,
                Fk_author = b.Fk_author
            }).ToListAsync();

            return Ok(books);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult> putBook(long id, [FromBody] BookDTO BookBody)
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
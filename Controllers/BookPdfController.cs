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
    public class BookPdfController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BookPdfController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createBookPdf([FromBody] BookPdfDTO bookPdfDTO)
        {
            var bookPdf = BookPdfModel.Create(bookPdfDTO.Fk_book);

            _db.BookPdf.Add(bookPdf);
            await _db.SaveChangesAsync();

            return Ok("BookPdf created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<BookPdfModel>> getAllBooksPdf()
        {
            var booksPdf = await _db.BookPdf.Select(b => new BookPdfDTO
            {
                Id = b.Id,
                Fk_book = b.Fk_book
            }).ToListAsync();

            return Ok(booksPdf);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult> putBookPdf(long id, [FromBody] BookPdfDTO BookPdfBody)
        {
            var bookPdf = await _db.BookPdf.FindAsync(id);

            if (bookPdf == null) return NotFound("BookPdf not found!");

            bookPdf.Fk_book = BookPdfBody.Fk_book;

            await _db.SaveChangesAsync();

            return Ok("BookPdf edited successfully!");
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult> removeBookPdf(long id)
        {
            var bookPdf = await _db.BookPdf.FindAsync(id);

            if (bookPdf == null) return NotFound();

            _db.BookPdf.Remove(bookPdf);
            await _db.SaveChangesAsync();

            return Ok();
        }
        
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(long id)
        {
            var bookPdf = await _db.BookPdf.FindAsync(id);
            if (bookPdf == null)
                return NotFound("PDF não encontrado.");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", bookPdf.FilePath);

            if (!System.IO.File.Exists(path))
                return NotFound("Arquivo não existe no servidor.");

            var contentType = "application/pdf";
            var fileName = Path.GetFileName(path);

            return PhysicalFile(path, contentType, fileName);
        }

    }
}
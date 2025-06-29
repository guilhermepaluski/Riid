using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riid.Data;
using Riid.DTO;
using Riid.DTO.Loan;
using Riid.Models;

namespace Riid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LoanController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> createLoan([FromBody] LoanCreateDTO loanCreateDTO)
        {
            var userIdString = User.FindFirst("id")?.Value;
      
            if (string.IsNullOrEmpty(userIdString) || !long.TryParse(userIdString, out var userId))
                return Unauthorized("Usuário não autenticado.");

            var book = await _db.Book.FindAsync(loanCreateDTO.Fk_book);
            if (book == null) return NotFound("Book not found!");

            var bookPdf = BookPdfModel.Create(book.Id);
            bookPdf.FilePath = Path.Combine("pdfs", book.Name);

            await _db.BookPdf.AddAsync(bookPdf);
            await _db.SaveChangesAsync();

            var loan = LoanModel.Create(userId, bookPdf.Id);

            _db.Loan.Add(loan);
            await _db.SaveChangesAsync();

            return Ok("Loan created successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<LoanModel>> getAllLoans()
        {
            var loans = await _db.Loan.Select(l => new LoanDTO{
                Id = l.Id,
                Loan_Date = l.Loan_Date,
                Return_Date = l.Return_Date,
                Fk_user = l.Fk_user,
                Fk_book_pdf = l.Fk_book_pdf
            }).ToListAsync();

            return Ok(loans);
        }

        [HttpPut("{Id:long}")]
        public async Task<ActionResult> putLoan(long id, [FromBody] LoanDTO LoanBody)
        {
            var loan = await _db.Loan.FindAsync(id);

            if(loan == null) return NotFound("Loan not found!");
            
                loan.Id = LoanBody.Id;
                loan.Loan_Date = LoanBody.Loan_Date;
                loan.Return_Date = LoanBody.Return_Date;
                loan.Fk_user = LoanBody.Fk_user;
                loan.Fk_book_pdf = LoanBody.Fk_book_pdf;

            await _db.SaveChangesAsync();
            
            return Ok("Loan edited successfully!");
        }

        [HttpDelete("{Id:long}")]
        public async Task<ActionResult> removeLoan(long id)
        {
            var loan = await _db.Loan.FindAsync(id);

            if(loan == null) return NotFound();

            _db.Loan.Remove(loan);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet("myBooks")]
        public async Task<ActionResult<IEnumerable<LoanModel>>> GetMyLoans()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("Usuário não autenticado.");
            }

            int userId = int.Parse(userIdClaim.Value);

            var loans = await _db.Loan
            .Where(l => l.Fk_user == userId)
            .Include(l => l.BookPdf)
            .Select(l => new UserLoanDTO
            {
                Id = l.Id,
                Loan_Date = l.Loan_Date,
                Return_Date = l.Return_Date,
                Book_Name = l.BookPdf.Book.Name,
                Book_Image = l.BookPdf.Book.Image,
            })
            .ToListAsync();

            return Ok(loans);
        }

        [Authorize]
        [HttpGet("myBooks/{Id:long}")]
        public async Task<ActionResult<LoanModel>> getLoanById(long id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) 
            {
                return Unauthorized("Usuário não identificado");
            }

            int userId = int.Parse(userIdClaim.Value);

            var loan = await _db.Loan
                .Where(l => l.Fk_user == userId)
                .Where(l => l.Id == id)
                .Include(l => l.BookPdf)
                .Select(l => new UserLoanDTO
                {
                    Id = l.Id,
                    Loan_Date = l.Loan_Date,
                    Return_Date = l.Return_Date,
                    Book_Name= l.BookPdf.Book.Name,
                    Book_Image = l.BookPdf.Book.Image
                })
                .FirstOrDefaultAsync();
            
            if (loan == null) return NotFound("Id not found!");

            return Ok(loan);
        }
    }
}
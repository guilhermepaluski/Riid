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
    public class LoanController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LoanController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> createLoan([FromBody] LoanDTO loanDTO)
        {
            var loan = LoanModel.Create(loanDTO.Fk_user, loanDTO.Fk_book_pdf);

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
    }
}
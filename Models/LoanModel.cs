using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.Models
{
    public class LoanModel
    {
        [Key]
        public long Id { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Return_Date { get; set; }

        public long Fk_user { get; set; }
        public long Fk_book_pdf { get; set; } 

        public UserModel User { get; set; }
        public BookPdfModel BookPdf { get; set; }

        private LoanModel() { }

        public static LoanModel Create(long fk_user, long fk_book_pdf)
        {
            DateTime today = DateTime.Now;
            return new LoanModel
            {
                Fk_user = fk_user,
                Fk_book_pdf = fk_book_pdf,
                Loan_Date = today,
                Return_Date = today.AddDays(30)
            };
        }
    }
}
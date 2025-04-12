using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.DTO
{
    public class LoanDTO
    {
        public long Id { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Return_Date { get; set; }

        public long Fk_user { get; set; }
        public long Fk_book_pdf { get; set; }
    }
}
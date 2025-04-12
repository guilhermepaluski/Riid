using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.DTO
{
    public class BookPdfDTO
    {
        public long Id { get; set; }

        public long Fk_book { get; set; }
    }
}
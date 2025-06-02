using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.DTO
{
    public class BookListDTO
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
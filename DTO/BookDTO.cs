using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riid.Models;

namespace Riid.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }

        public long Fk_category { get; set; }
        public long Fk_author { get; set; }
    }
}
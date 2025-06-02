using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.Models
{
    public class BookModel
    {
        [Key]
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }

        public long Fk_category { get; set; }
        public long Fk_author { get; set; }

        public CategoryModel Category { get; set; }
        public AuthorModel Author { get; set; }

        public ICollection<BookPdfModel> BookPdfs { get; set; }
    }
}
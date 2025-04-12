using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Riid.Models
{
    public class CategoryModel
    {
        [Key]
        public long Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
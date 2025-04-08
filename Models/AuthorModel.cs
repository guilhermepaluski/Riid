using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.Models
{
    public class AuthorModel
    {
        [Key]
        public long Id { get; private set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
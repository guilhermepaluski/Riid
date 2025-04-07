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
        private string _name;
        private string _description;
        
        public string Name
        { 
            get { return _name; }
            set {_name = value; }
        }
        public string Description
        { 
            get { return _description; }
            set {_description = value; } 
        }
    }
}
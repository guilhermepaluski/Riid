using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riid.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
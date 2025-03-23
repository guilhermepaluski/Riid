using System.ComponentModel.DataAnnotations;

namespace Riid.Models
{
    public class UserModel
    {
        [Key]
        public long Id { get; set;  }
        public string Cpf { get; set;  }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

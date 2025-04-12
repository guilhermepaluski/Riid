using System.ComponentModel.DataAnnotations;

namespace Riid.Models
{
    public class UserModel
    {
        [Key]
        public long Id { get; set;  }
        public string Cpf;
        public string Email;
        public string Name;
        public string Password;

        public ICollection<LoanModel> Loans { get; set; }
    }
}

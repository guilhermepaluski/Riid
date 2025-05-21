using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Riid.Data;

namespace Riid.Models
{
    public class UserModel : IdentityUser<long>
    {
        public string Name { get; set; }

        public ICollection<LoanModel> Loans { get; set; }
    }
}

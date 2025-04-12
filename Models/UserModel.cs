using System.ComponentModel.DataAnnotations;

namespace Riid.Models
{
    public class UserModel
    {
        [Key]
        public long Id { get; set;  }
        private string _cpf;
        private string _email;
        private string _name;
        private string _password;

        public string Cpf{
            get { return _cpf; }
            set { _cpf = value; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }
    }
}

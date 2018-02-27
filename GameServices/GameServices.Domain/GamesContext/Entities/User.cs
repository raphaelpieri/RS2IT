using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Domain.GamesContext.Entities
{
    public class User : Person
    {
        protected User()
        {
        }

        public User(Name name, Email email, string userName, string password, string confirmPassword) : base(name, email)
        {
            UserName = userName;
            Password = EncrypyPassword(password);
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(UserName, 3, "Usuário", "Usuário deve conter no minimo 3 caracteres")
                .HasMaxLen(UserName, 20, "Usuário", "Usuário deve ter no máximo 20 caracteres")
                .HasMinLen(password, 3, "Senha", "Senha deve conter no minimo 3 caracteres")
                .AreEquals(Password, EncrypyPassword(confirmPassword), "Senha", "A senha não confere"));
        }
        
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public bool Authenticate(string username, string password)
        {
            if (UserName == username && Password == EncrypyPassword(password))
                return true;
            
            AddNotification("Usuário", "Usuário ou senha inválidos");
            return false;
        }


        private string EncrypyPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return string.Empty;

            var password = (pass += "|2d331cca-f6c0-40c0-aa43-6f34489c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
            {
                sbString.Append(t.ToString("x2"));
            }

            return sbString.ToString();
        }
        
    }
}
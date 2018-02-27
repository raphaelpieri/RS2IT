using Flunt.Validations;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Domain.GamesContext.Entities
{
    public class Friend : Person
    {
        protected Friend()
        {
            
        }

        public Friend(User user ,Name name, Email email, string phone) : base(name, email)
        {
            User = user;
            Phone = phone;
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Phone, 9, "Telefone", "Telefone deve conter pelo menos 9 caracteres")
                .HasMaxLen(Phone, 20, "Telefone", "Telefone deve conter no máximo 20 caracteres"));
        }

        public void Alter(Name name, Email email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Phone, 9, "Telefone", "Telefone deve conter pelo menos 9 caracteres")
                .HasMaxLen(Phone, 20, "Telefone", "Telefone deve conter no máximo 20 caracteres"));
        }
        
        public User User { get; private set; }
        public string Phone { get; private set; }
    }
}
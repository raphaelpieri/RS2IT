using Flunt.Notifications;
using Flunt.Validations;

namespace GameServices.Domain.GamesContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 80, "Sobrenome", "O sobrenome deve conter no máximo 80 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
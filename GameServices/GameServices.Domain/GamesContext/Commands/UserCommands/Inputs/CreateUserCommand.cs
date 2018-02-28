using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.UserCommands.Inputs
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Username { get;  set; }
        public string Password { get;  set; }
        public string ConfirmPassword { get;  set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasMinLen(FirstName, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 80, "Sobrenome", "O sobrenome deve conter no máximo 80 caracteres")
                .IsEmail(Email, "Email","O E-mail é inválido")
                .HasMinLen(Username, 3, "Usuário", "Usuário deve conter no minimo 3 caracteres")
                .HasMaxLen(Username, 20, "Usuário", "Usuário deve ter no máximo 20 caracteres")
                .HasMinLen(Password, 3, "Senha", "Senha deve conter no minimo 3 caracteres")
                .AreEquals(Password, ConfirmPassword,"Senha", "A senha e a confirmação devem ser iguais"));

            return base.Valid;
        }
    }
}
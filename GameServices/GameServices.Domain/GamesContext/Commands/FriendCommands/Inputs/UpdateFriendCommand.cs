using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs
{
    public class UpdateFriendCommand: Notifiable, ICommand
    {
        public Guid Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(Id.ToString(), 36, "Id", "Indentificador do amigo deve ser informado")
                .HasMinLen(FirstName, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 80, "Sobrenome", "O sobrenome deve conter no máximo 80 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido")
                .HasMinLen(Phone, 9, "Telefone", "Telefone deve conter pelo menos 9 caracteres")
                .HasMaxLen(Phone, 20, "Telefone", "Telefone deve conter no máximo 20 caracteres"));

            return base.Valid;
        }
    }
}
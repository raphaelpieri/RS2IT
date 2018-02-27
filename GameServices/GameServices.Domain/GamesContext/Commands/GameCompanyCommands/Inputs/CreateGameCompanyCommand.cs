using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Inputs
{
    public class CreateGameCompanyCommand : Notifiable, ICommand 
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(UserId.ToString(), 36, "Usuário", "Indentificador do usuário deve ser informado")
                .HasMinLen(Name, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 40, "Nome", "O nome deve conter no máximo 40 caracteres"));
            return base.Valid;
        }
    }
}
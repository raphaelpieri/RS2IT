using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.GameCommands.Inputs
{
    public class CreateGameCommand : Notifiable, ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(UserId.ToString(), 36, "Usuário", "Indentificador do usuário deve ser informado")
                .HasLen(CompanyId.ToString(), 36, "Empresa", "Criadora do jogo deve ser informada")
                .HasMinLen(Name, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 40, "Nome", "O nome deve conter no máximo 40 caracteres"));

            return base.Valid;
        }
    }
}
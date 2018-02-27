using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.GameCommands.Inputs
{
    public class RemoveGameCommand : Notifiable, ICommand
    {
        public Guid Id { get; private set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(Id.ToString(), 36, "Usuário", "Indentificador do jogo deve ser informado"));

            return base.Valid;
        }
    }
}
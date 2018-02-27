using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.GameCommands.Inputs
{
    public class ReturnCommand : Notifiable, ICommand
    {
        public Guid IdGame { get; set; }
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(IdGame.ToString(), 36, "Joog", "Indentificador do jogo deve ser informado"));

            return base.Valid;
        }
    }
}
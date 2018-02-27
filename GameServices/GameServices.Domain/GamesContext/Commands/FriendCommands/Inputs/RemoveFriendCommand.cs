using System;
using Flunt.Notifications;
using Flunt.Validations;
using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs
{
    public class RemoveFriendCommand : Notifiable, ICommand
    {
        public Guid Id { get;  set; }
        
        public bool Valid()
        {
            AddNotifications(new Contract()
                .HasLen(Id.ToString(), 36, "Id", "Indentificador do usuário deve ser informado"));

            return base.Valid;
        }
    }
}
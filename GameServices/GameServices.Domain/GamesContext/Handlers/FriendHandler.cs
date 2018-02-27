using System;
using Flunt.Notifications;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Outputs;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Domain.GamesContext.Handlers
{
    public class FriendHandler : Notifiable, ICommandHandler<CreateFriendCommand>, 
        ICommandHandler<UpdateFriendCommand>, ICommandHandler<RemoveFriendCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendRepository _repository;

        public FriendHandler(IUserRepository userRepository, IFriendRepository repository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }

        public ICommandResult Handle(CreateFriendCommand command)
        {
            var user = _userRepository.Get(command.UserId);
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var friend = new Friend(user, name, email, command.Phone);
            
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(friend.Notifications);

            if (Invalid)
                return ErrorResult();
            
            _repository.Save(friend);

            return SucessResult(friend.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(UpdateFriendCommand command)
        {
            var friend = _repository.Get(command.Id);
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            
            friend.Alter(name, email, command.Phone);
            
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(friend.Notifications);

            if (Invalid)
                return ErrorResult();
            
            _repository.Update(friend);

            return SucessResult(friend.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(RemoveFriendCommand command)
        {
            _repository.Remove(command.Id);
            return new FriendCommandResult(true, "Registro apagado com sucesso", command.Id);
        }
        
        private FriendCommandResult ErrorResult()
        {
            return new FriendCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);
        }
        
        private FriendCommandResult SucessResult(Guid id, string name, string email)
        {
            return new FriendCommandResult(true, "Registro gravado com sucesso", new
            {
                Id = id,
                Name = name,
                Email = email
            });
        }
    }
}
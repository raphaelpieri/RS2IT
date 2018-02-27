using Flunt.Notifications;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.UserCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.UserCommands.Outputs;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Domain.GamesContext.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            var user = new User(name, email, command.Username, command.Password, command.ConfirmPassword);
            
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            
            if(Invalid)
                return new UserCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);
            
            _repository.Save(user);
            
            return new UserCommandResult(true, "Seja bem vindo, ao controle de jogos", new
            {
                Id = user.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }
    }
}
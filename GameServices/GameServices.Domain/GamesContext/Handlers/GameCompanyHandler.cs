using System.Xml.Schema;
using Flunt.Notifications;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Outputs;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;

namespace GameServices.Domain.GamesContext.Handlers
{
    public class GameCompanyHandler : Notifiable, ICommandHandler<CreateGameCompanyCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameCompanyRepository _repository;

        public GameCompanyHandler(IUserRepository userRepository, IGameCompanyRepository repository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }

        public ICommandResult Handle(CreateGameCompanyCommand command)
        {
            var user = _userRepository.Get(command.UserId);
            var gameCompany = new GameCompany(user, command.Name);
            AddNotifications(gameCompany.Notifications);
            
            if(Invalid)
                return new GameCompanyCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);
            
            _repository.Save(gameCompany);
            
            return new GameCompanyCommandResult(true, "Cadastro realizado com sucesso", gameCompany.Id);
        }
    }
}
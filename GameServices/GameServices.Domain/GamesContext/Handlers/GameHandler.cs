using Flunt.Notifications;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.GameCommands.Outputs;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;

namespace GameServices.Domain.GamesContext.Handlers
{
    public class GameHandler: Notifiable, ICommandHandler<CreateGameCommand>, ICommandHandler<UpdateGameCommand>,
        ICommandHandler<RemoveGameCommand>, ICommandHandler<LendCommand>, ICommandHandler<ReturnCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameCompanyRepository _gameCompanyRepository;
        private readonly IGameRepository _repository;
        private readonly IFriendRepository _friendRepository;

        public GameHandler(IUserRepository userRepository, IGameCompanyRepository gameCompanyRepository, IGameRepository repository, IFriendRepository friendRepository)
        {
            _userRepository = userRepository;
            _gameCompanyRepository = gameCompanyRepository;
            _repository = repository;
            _friendRepository = friendRepository;
        }

        public ICommandResult Handle(CreateGameCommand command)
        {
            var user = _userRepository.Get(command.UserId);
            var gameCompany = _gameCompanyRepository.Get(command.GuidCompany);

            var game = new Game(user, command.Name, gameCompany);
            AddNotifications(game.Notifications);

            if (Invalid)
                return ErrorResult();
            
            _repository.Save(game);

            return new GameCommandResult(true, "Jogo criado com sucesso", game.Id);
        }

        public ICommandResult Handle(UpdateGameCommand command)
        {
            var gameCompany = _gameCompanyRepository.Get(command.GuidCompany);
            var game = _repository.Get(command.Id);
            game.Alter(command.Name, gameCompany);
            
            AddNotifications(game.Notifications);
            
            if (Invalid)
                return ErrorResult();
            
            _repository.Update(game);

            return new GameCommandResult(true, "Jogo alterado com sucesso", game.Id);
        }

        public ICommandResult Handle(RemoveGameCommand command)
        {
            _repository.Remove(command.Id);
            return new GameCommandResult(true, "Jogo apagado com sucesso", command.Id);
        }

        public ICommandResult Handle(LendCommand command)
        {
            var game = _repository.Get(command.IdGame);
            var friend = _friendRepository.Get(command.IdFriend);
            
            var loan = new Loan(friend);
            game.Lend(loan);
            AddNotifications(game.Notifications);

            if (Invalid)
                return ErrorResult();
            
            _repository.Update(game);
            return new GameCommandResult(true, "Jogo emprestado com sucesso", game.Id);
            
        }

        public ICommandResult Handle(ReturnCommand command)
        {
            var game = _repository.Get(command.IdGame);
            
            game.Return();
            AddNotifications(game.Notifications);
            
            if (Invalid)
                return ErrorResult();
            
            _repository.Update(game);
            return new GameCommandResult(true, "Jogo retornado com sucesso", game.Id);
        }
        
        
        private GameCommandResult ErrorResult()
        {
            return new GameCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);
        }
        
        
    }
}
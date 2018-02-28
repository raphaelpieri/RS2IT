using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameRepository _repository;
        private readonly GameHandler _handler;
        public GameController(IUnitOfWork unitOfWork, IGameRepository repository, GameHandler handler) : base(unitOfWork)
        {
            _repository = repository;
            _handler = handler;
        }
        [HttpPost]
        [Route("v1/games")]
        public async Task<ICommandResult> Post([FromBody] CreateGameCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpPost]
        [Route("v1/games")]
        public async Task<ICommandResult> Post([FromBody] LendCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpPost]
        [Route("v1/games")]
        public async Task<ICommandResult> Post([FromBody] ReturnCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpPut]
        [Route("v1/games")]
        public async Task<ICommandResult> Put([FromBody] UpdateGameCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpDelete]
        [Route("v1/games/{id}")]
        public async Task<ICommandResult> Delete(Guid id)
        {
            var command = new RemoveGameCommand()
            {
                Id = id
            };
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1/games/{id}")]
        public async Task<GameQueryResult> Get(Guid id)
        {
            return await _repository.GetGameQueryResult(id);
        }
        
        [HttpGet]
        [Route("v1/games/")]
        public async Task<List<GameListQueryResult>> Get()
        {
            var userId = Guid.NewGuid();  //Ia pegar do token
            return await _repository.GetListQueryResults(userId);
        }
    }
}
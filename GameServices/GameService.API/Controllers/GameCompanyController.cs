using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    public class GameCategory : BaseController
    {
        private readonly GameCompanyHandler _handler;
        private readonly IGameCompanyRepository _repository;
        public GameCategory(IUnitOfWork unitOfWork, GameCompanyHandler handler, IGameCompanyRepository repository) : base(unitOfWork)
        {
            _handler = handler;
            _repository = repository;
        }
        
        [HttpPost]
        [Route("v1/game-companies")]
        public async Task<ICommandResult> Post([FromBody] CreateGameCompanyCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpGet]
        [Route("v1/game-companies")]
        public async Task<List<GameCompanyListQueryResult>> Get()
        {
            var userId = Guid.NewGuid();  //Ia pegar do token
            return await _repository.GetListQueryResults(userId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    public class FriendController : BaseController
    {
        private FriendHandler _handler;
        private IFriendRepository _repository;
        public FriendController(IUnitOfWork unitOfWork, FriendHandler handler, IFriendRepository repository) : base(unitOfWork)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("v1/friends")]
        public async Task<ICommandResult> Post([FromBody] CreateFriendCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpPut]
        [Route("v1/friends")]
        public async Task<ICommandResult> Put([FromBody] UpdateFriendCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
        
        [HttpDelete]
        [Route("v1/friends/{id}")]
        public async Task<ICommandResult> Delete(Guid id)
        {
            var command = new RemoveFriendCommand()
            {
                Id = id
            };
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1/friends/{id}")]
        public async Task<FriendQueryResult> Get(Guid id)
        {
            return await _repository.GetFriendQueryResult(id);
        }
        
        [HttpGet]
        [Route("v1/friends/")]
        public async Task<List<FriendListQueryResult>> Get()
        {
            var userId = Guid.NewGuid();  //Ia pegar do token
            return await _repository.GetListQueryResults(userId);
        }
    }
}
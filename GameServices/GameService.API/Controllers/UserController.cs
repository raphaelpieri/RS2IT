using System.Threading.Tasks;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.UserCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserHandler _handler;
        public UserController(IUnitOfWork unitOfWork, UserHandler handler) : base(unitOfWork)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/users")]
        public async Task<ICommandResult> Post([FromBody] CreateUserCommand command)
        {
            var result = _handler.Handle(command);
            return await this.Response(result);
        }
    }
}
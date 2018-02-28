
using System;
using GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Tests.Fakes;
using Xunit;

namespace GameServices.Tests.Handlers
{
    public class GameCompanyHandlerTests
    {
        private readonly GameCompanyHandler _handler;

        public GameCompanyHandlerTests()
        {
            _handler = new GameCompanyHandler(new FakeUserRepository(), new FakeGameCompanyRepository());
        }
        
        [Fact]
        public void ShouldRegisterGameCompanyWhenCommandIsValid()
        {
            var command = new CreateGameCompanyCommand()
            {
                UserId = Guid.NewGuid(),
                Name = "EA SPORT"
            };

            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
    }
}
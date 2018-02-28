using System;
using GameService.Shared.Commands;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Tests.Fakes;
using Xunit;

namespace GameServices.Tests.Handlers
{
    public class GameHandlerTests
    {
        private readonly GameHandler _handler;

        public GameHandlerTests()
        {
            _handler = new GameHandler(new FakeUserRepository(), new FakeGameCompanyRepository(), new FakeGameRepository(), new FakeFriendRepository());
        }

        [Fact]
        public void ShouldRegisterGameWhenCommandIsValid()
        {
            var command = new CreateGameCommand()
            {
                UserId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                Name = "FIFA 19"
            };
            
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
        
        [Fact]
        public void ShouldUpdateGameWhenCommandIsValid()
        {
            var command = new UpdateGameCommand()
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                Name = "FIFA 19"
            };
            
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
        
        [Fact]
        public void ShouldRemoveGameWhenCommandIsValid()
        {
            var command = new RemoveGameCommand()
            {
                Id = Guid.NewGuid()
            };
            
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
        
        [Fact]
        public void ShouldLendGameWhenCommandIsValid()
        {
            var command = new LendCommand()
            {
                IdFriend = Guid.NewGuid(),
                IdGame = Guid.NewGuid()
            };
            
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
        
        [Fact]
        public void ShouldReturnGameWhenCommandIsValid()
        {
            var command = new ReturnCommand()
            {
                IdGame = Guid.NewGuid()
            };
            
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Invalid);
        }
    }
}
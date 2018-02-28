using System;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Tests.Fakes;
using Xunit;

namespace GameServices.Tests.Handlers
{
    public class FriendHandlerTests
    {
        private readonly FriendHandler _handler;

        public FriendHandlerTests()
        {
            _handler = new FriendHandler(new FakeUserRepository(), new FakeFriendRepository());
        }

        [Fact]
        public void ShouldRegisterFriendWhenCommandIsValid()
        {
            var command = new CreateFriendCommand()
            {
                FirstName = "Armando",
                LastName = "Fagundes",
                Email = "ar_fagundes@gmail.com",
                Phone = "11888774545",
                UserId = Guid.NewGuid()
            };

            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
        
        [Fact]
        public void ShouldUpdateFriendWhenCommandIsValid()
        {
            var command = new UpdateFriendCommand()
            {
                FirstName = "Armando",
                LastName = "Fagundes",
                Email = "ar_fagundes@gmail.com",
                Phone = "11888774545",
                Id = Guid.NewGuid()
            };

            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }

        [Fact]
        public void ShouldRemoveFriendWhenCommandIsValid()
        {
            var command = new RemoveFriendCommand()
            {
                Id = Guid.NewGuid()
            };
            var result = _handler.Handle(command);
            
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
    }
}
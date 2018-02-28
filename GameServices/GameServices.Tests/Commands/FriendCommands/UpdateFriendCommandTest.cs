using System;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.FriendCommands
{
    public class UpdateFriendCommandTest
    {
        [Fact]
        public void ShouldValidateWhenUpdateCommandIsValid()
        {
            var command = new UpdateFriendCommand()
            {
                Id = Guid.NewGuid(),
                Email = "raphael@teste.com.br",
                FirstName = "Raphael",
                LastName = "Teste 001",
                Phone = "4499845466"
            };
            
            Assert.True(command.Valid());
        }
    }
}
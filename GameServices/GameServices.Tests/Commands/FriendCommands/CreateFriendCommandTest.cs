using System;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.FriendCommands
{
    public class CreateFriendCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCreateCommandIsValid()
        {
            var command = new CreateFriendCommand()
            {
                Email = "raphael@teste.com.br",
                FirstName = "Raphael",
                LastName = "Teste 001",
                Phone = "4499845466",
                UserId = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
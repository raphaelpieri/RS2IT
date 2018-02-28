using System;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCommands
{
    public class CreateGameCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateGameCommand()
            {
                Name = "FIFA 19",
                CompanyId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
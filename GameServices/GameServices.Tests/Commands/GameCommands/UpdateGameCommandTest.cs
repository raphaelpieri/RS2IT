using System;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCommands
{
    public class UpdateGameCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new UpdateGameCommand()
            {
                Id = Guid.NewGuid(),
                Name = "FIFA 19",
                CompanyId = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
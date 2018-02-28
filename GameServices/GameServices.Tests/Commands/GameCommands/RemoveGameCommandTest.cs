using System;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCommands
{
    public class RemoveGameCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new RemoveGameCommand()
            {
                Id = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
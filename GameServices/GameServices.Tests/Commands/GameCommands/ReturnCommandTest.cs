using System;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCommands
{
    public class ReturnCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new ReturnCommand()
            {
                IdGame = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
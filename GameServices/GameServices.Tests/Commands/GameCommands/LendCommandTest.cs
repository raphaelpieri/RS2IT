using System;
using GameServices.Domain.GamesContext.Commands.GameCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCommands
{
    public class LendCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new LendCommand()
            {
                IdGame = Guid.NewGuid(),
                IdFriend = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
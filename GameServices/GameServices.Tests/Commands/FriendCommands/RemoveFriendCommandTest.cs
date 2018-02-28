using System;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.FriendCommands
{
    public class RemoveFriendCommandTest
    {
        [Fact]
        public void ShouldValidateWhenRemoveCommandIsValid()
        {
            var command = new RemoveFriendCommand()
            {
                Id = Guid.NewGuid()
            };
            
            Assert.True(command.Valid());
        }
    }
}
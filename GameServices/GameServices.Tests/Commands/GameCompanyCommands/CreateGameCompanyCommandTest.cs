using System;
using GameServices.Domain.GamesContext.Commands.FriendCommands.Inputs;
using GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.GameCompanyCommands
{
    public class CreateGameCompanyCommandTest
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateGameCompanyCommand()
            {
                UserId = Guid.NewGuid(),
                Name = "Teste 0001"
            };
            
            Assert.True(command.Valid());
        }
    }
}
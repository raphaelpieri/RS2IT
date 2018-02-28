using GameServices.Domain.GamesContext.Commands.UserCommands.Inputs;
using Xunit;

namespace GameServices.Tests.Commands.UserCommands
{
    public class CreateUserCommandTest
    {
        [Fact]
        public void ShouldValidadeWhenCommandIsValid()
        {
            var command = new CreateUserCommand()
            {
                FirstName = "Teste0001",
                LastName = "TesteTeste0001",
                Email = "teste@teste.com",
                Username = "teste.teste",
                Password = "mudarteste",
                ConfirmPassword = "mudarteste"
            };
            
            Assert.True(command.Valid());

        }
    }
}
using GameServices.Domain.GamesContext.Commands.UserCommands.Inputs;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Tests.Fakes;
using Xunit;

namespace GameServices.Tests.Handlers
{
    public class UserHandlerTests
    {
        private readonly UserHandler _handler;

        public UserHandlerTests()
        {
            _handler = new UserHandler(new FakeUserRepository());
        }

        [Fact]
        public void ShouldRegisterUserWhenCommandIsValid()
        {
            var command = new CreateUserCommand()
            {
                FirstName = "Raphael",
                LastName = "Trevisan",
                Email = "raphael_trei@hotmail.com",
                Username = "raphael",
                Password = "rtrevisan",
                ConfirmPassword = "rtrevisan"
            };

            var result = _handler.Handle(command);
            Assert.NotEqual(null, result);
            Assert.True(_handler.Valid);
        }
    }
}
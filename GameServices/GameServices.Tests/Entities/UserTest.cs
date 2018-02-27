using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.ValueObjects;
using Xunit;

namespace GameServices.Tests.Entities
{
    public class UserTest
    {
        [Fact]
        public void ShouldReturnNotificationWhenUsernameIsInvalid()
        {
            var user = CreateUser("", "14522", "14522");
            Assert.True(user.Invalid);
            Assert.Equal(1, user.Notifications.Count);
        }
        
        [Fact]
        public void ShouldReturnNotificationWhenPasswordIsInvalid()
        {
            var user = CreateUser("raphaeldsds", "14", "14");
            Assert.True(user.Invalid);
            Assert.Equal(1, user.Notifications.Count);
        }
        
        [Fact]
        public void ShouldReturnNotificationWhenPasswordIsNotEqulConfirm()
        {
            var user = CreateUser("raphaeldsds", "148778", "1441112");
            Assert.True(user.Invalid);
            Assert.Equal(1, user.Notifications.Count);
        }
        
        [Fact]
        public void ShouldReturnUserIsValid()
        {
            var user = CreateUser("dsdsdsdls", "148778", "148778");
            Assert.True(user.Valid);
        }
        
        [Fact]
        public void ShouldReturnNotificationWhenITryAuthenticateWithLoginInvalid()
        {
            var user = CreateUser("teste", "teste1", "teste1");
            user.Authenticate("testes", "teste1");
            Assert.True(user.Invalid);
            Assert.Equal(1, user.Notifications.Count);
        }

        [Fact]
        public void ShouldReturnNotificationWhenITryAuthenticateWithPasswordInvalid()
        {
            var user = CreateUser("teste", "teste1", "teste1");
            user.Authenticate("teste", "teste2");
            Assert.True(user.Invalid);
            Assert.Equal(1, user.Notifications.Count);
        }
        
        [Fact]
        public void WhenITryAuthenticateWithCorrectValueReturnOk()
        {
            var user = CreateUser("teste", "teste1", "teste1");
            user.Authenticate("teste", "teste1");
            Assert.True(user.Valid);
        }
        
        private User CreateUser(string userName, string password, string confirmPassword)
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            return new User(name, email, userName, password, confirmPassword);
        }
    }
}
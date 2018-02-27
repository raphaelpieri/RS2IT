using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.ValueObjects;
using Xunit;

namespace GameServices.Tests.Entities
{
    public class FriendTest
    {
        [Fact]
        public void ShouldReturnNotificationWhenPhoneInvalid()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "");
            Assert.True(friend.Invalid);
            Assert.Equal(1, friend.Notifications.Count);
        }
        
        [Fact]
        public void ShouldReturnPhoneIsValid()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "998844556");
            Assert.True(friend.Valid);
        }
    }
}
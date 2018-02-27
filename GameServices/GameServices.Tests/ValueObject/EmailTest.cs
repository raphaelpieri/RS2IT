using GameServices.Domain.GamesContext.ValueObjects;
using Xunit;

namespace GameServices.Tests.ValueObject
{
    public class EmailTest
    {
        [Fact]
        public void ShouldReturnNotificationWhenEmailIsNotValid()
        {
            var email = new Email("rapha.dke.com");
            Assert.True(email.Invalid);
            Assert.Equal(1, email.Notifications.Count);
        }
    }
}
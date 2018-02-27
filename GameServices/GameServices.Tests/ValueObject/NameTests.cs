using System.Linq;
using GameServices.Domain.GamesContext.ValueObjects;
using Xunit;
using Xunit.Sdk;

namespace GameServices.Tests.ValueObject
{
    public class NameTests
    {
        [Fact]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "De Pieri Poi");
            Assert.Equal(false, name.Valid);
            Assert.Equal(1, name.Notifications.Count());
        }
    }
}
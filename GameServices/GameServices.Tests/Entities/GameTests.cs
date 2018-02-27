using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.ValueObjects;
using Xunit;

namespace GameServices.Tests.Entities
{
    public class GameTests
    {
        [Fact]
        public void ShouldReturnNotificationWhenITryLoadTheSameGame()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "");
            var gameCompany = new GameCompany(user, "EA SPORTS");
            
            var game = new Game(user, "FIFA 19", gameCompany);
            var loan = new Loan(friend);
            var loan2 = new Loan(friend);
            
            game.Lend(loan);
            game.Lend(loan2);
            
            Assert.True(game.Invalid);
            Assert.Equal(1, game.Notifications.Count);
        }

        [Fact]
        public void ShouldReturnValidWhenITryAGame()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "");
            var gameCompany = new GameCompany(user, "EA SPORTS");
            
            var game = new Game(user, "FIFA 19", gameCompany);
            var loan = new Loan(friend);
            
            game.Lend(loan);
            
            Assert.True(game.Valid);
        }
        
        [Fact]
        public void ShouldReturnNotificationWhenIReturnIGameButItIsNotLoad()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "");
            var gameCompany = new GameCompany(user, "EA SPORTS");
            
            var game = new Game(user, "FIFA 19", gameCompany);
            game.Return();
            
            Assert.True(game.Invalid);
            Assert.Equal(1, game.Notifications.Count);
        }
        
        [Fact]
        public void ShouldReturnValidWhenIReturnIGame()
        {
            var name = new Name("Raphael", "De Pieri");
            var email = new Email("raphaeldppf@hotmail.com");
            var user = new User(name, email, "teste", "teste1", "teste1");
            var friend = new Friend(user, name, email, "");
            var gameCompany = new GameCompany(user, "EA SPORTS");
            
            var game = new Game(user, "FIFA 19", gameCompany);
            var loan = new Loan(friend);
            
            game.Lend(loan);
            game.Return();

            Assert.True(game.Valid);
        }
    }
}
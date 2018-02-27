using GameService.Shared.Entities;

namespace GameServices.Domain.GamesContext.Entities
{
    public class GameCompany : Entity
    {
        protected GameCompany()
        {
        }

        public GameCompany(User user, string name)
        {
            User = user;
            Name = name;
        }
        public User User { get; private set; }
        public string Name { get; private set; }
    }
}
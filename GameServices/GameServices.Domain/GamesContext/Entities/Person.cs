using GameService.Shared.Entities;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Domain.GamesContext.Entities
{
    public abstract class Person : Entity
    {
        protected Person()
        {
            
        }
        protected Person(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; protected set; }
        public Email Email { get; protected set; }
    }
}
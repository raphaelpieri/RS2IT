using System;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Tests.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public User Get(Guid id)
        {
            return NewUser();
        }

        public User GetByUsername(string username)
        {
            return NewUser();
        }

        public void Save(User user)
        {
        }

        private User NewUser()
        {
            var name = new Name("Name", "Last Name");
            var email = new Email("email@email.com");
            return new User(name, email,"username", "password","password");
        }
    }
}
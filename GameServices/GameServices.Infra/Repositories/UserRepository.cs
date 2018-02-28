using System;
using System.Linq;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Contexts;

namespace GameServices.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameServiceContext _context;

        public UserRepository(GameServiceContext context)
        {
            _context = context;
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }
    }
}
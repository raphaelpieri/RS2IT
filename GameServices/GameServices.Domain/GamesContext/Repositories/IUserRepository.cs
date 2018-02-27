using System;
using GameServices.Domain.GamesContext.Entities;

namespace GameServices.Domain.GamesContext.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);
        User GetByUsername(string username);
        void Save(User user);
    }
}
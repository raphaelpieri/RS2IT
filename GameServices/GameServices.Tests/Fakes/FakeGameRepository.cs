using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Tests.Fakes
{
    public class FakeGameRepository : IGameRepository
    {
        public Game Get(Guid id)
        {
            var name = new Name("Name", "Last Name");
            var email = new Email("email@email.com");
            var user = new User(name, email, "username", "password", "password");
            
            var company = new GameCompany(user, "Company");
            
            return new Game(user, "FIFA 19", company);
        }

        public void Save(Game game)
        {
        }

        public void Update(Game game)
        {
        }

        public void Remove(Guid id)
        {
        }

        public Task<GameQueryResult> GetGameQueryResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameListQueryResult>> GetListQueryResults(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Tests.Fakes
{
    public class FakeGameCompanyRepository : IGameCompanyRepository
    {
        public GameCompany Get(Guid id)
        {
            var name = new Name("Name", "Last Name");
            var email = new Email("email@email.com");
            var user = new User(name, email, "username", "password", "password");
            
            return new GameCompany(user, "Company");
        }

        public void Save(GameCompany gameCompany)
        {
        }

        public Task<List<GameCompanyListQueryResult>> GetListQueryResults(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;

namespace GameServices.Domain.GamesContext.Repositories
{
    public interface IGameCompanyRepository
    {
        GameCompany Get(Guid id);
        void Save(GameCompany gameCompany);

        Task<List<GameCompanyListQueryResult>> GetListQueryResults(Guid userId);

    }
}
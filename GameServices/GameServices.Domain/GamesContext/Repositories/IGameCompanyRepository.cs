using System;
using System.Collections.Generic;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;

namespace GameServices.Domain.GamesContext.Repositories
{
    public interface IGameCompanyRepository
    {
        GameCompany Get(Guid id);
        void Save(GameCompany gameCompany);

        IEnumerable<GameCompanyListQueryResult> Get();

    }
}
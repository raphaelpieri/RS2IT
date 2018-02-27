﻿using System;
using System.Collections.Generic;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;

namespace GameServices.Domain.GamesContext.Repositories
{
    public interface IGameRepository
    {
        Game Get(Guid id);
        void Save(Game game);
        void Update(Game game);
        void Remove(Guid id);

        GameQueryResult GetGameQueryResult(Guid id);
        IEnumerable<GameListQueryResult> Get();
    }
}
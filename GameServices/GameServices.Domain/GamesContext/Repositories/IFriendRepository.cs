using System;
using System.Collections.Generic;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;

namespace GameServices.Domain.GamesContext.Repositories
{
    public interface IFriendRepository
    {
        Friend Get(Guid id);
        void Save(Friend friend);
        void Update(Friend friend);
        void Remove(Guid id);
        
        FriendQueryResult GetFriendQueryResult(Guid id);
        IEnumerable<FriendListQueryResult> Get();
    }
}
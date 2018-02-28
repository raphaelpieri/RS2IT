using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        Task<FriendQueryResult> GetFriendQueryResult(Guid id);
        Task<List<FriendListQueryResult>> GetListQueryResults(Guid userId);
    }
}
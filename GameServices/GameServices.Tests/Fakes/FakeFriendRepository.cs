using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Domain.GamesContext.ValueObjects;

namespace GameServices.Tests.Fakes
{
    public class FakeFriendRepository : IFriendRepository
    {
        public Friend Get(Guid id)
        {
            return NewFriend();
        }

        public void Save(Friend friend)
        {
        }

        public void Update(Friend friend)
        {
        }

        public void Remove(Guid id)
        {
        }

        public Task<FriendQueryResult> GetFriendQueryResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FriendListQueryResult>> GetListQueryResults(Guid userId)
        {
            throw new NotImplementedException();
        }

        private Friend NewFriend()
        {
            var name = new Name("Name", "Last Name");
            var email = new Email("email@email.com");
            var user = new User(name, email, "username", "password", "password");
            return new Friend(user, name, email, "445556699");
        }
    }
}
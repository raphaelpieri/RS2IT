using System;

namespace GameServices.Domain.GamesContext.Queries
{
    public class FriendListQueryResult
    {
        public FriendListQueryResult(Guid id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
        
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
    }
}
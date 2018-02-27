using System;

namespace GameServices.Domain.GamesContext.Queries
{
    public class GameCompanyListQueryResult
    {
        public GameCompanyListQueryResult(Guid id, string name)
        {
            this.id = id;
            Name = name;
        }

        public Guid id { get; private set; }
        public string Name { get; private set; }
    }
}
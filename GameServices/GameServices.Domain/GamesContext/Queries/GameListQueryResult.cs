using System;

namespace GameServices.Domain.GamesContext.Queries
{
    public class GameListQueryResult
    {
        public GameListQueryResult(string name, string company, DateTime buyDate, bool available)
        {
            Name = name;
            Company = company;
            BuyDate = buyDate;
            Available = available;
        }

        public string Name { get; private set; }
        public string Company { get; private set; }
        public DateTime BuyDate { get; private set; }
        public bool Available { get; private set; }
    }
}
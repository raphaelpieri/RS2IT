using System;
using System.Collections.Generic;

namespace GameServices.Domain.GamesContext.Queries
{
    public class GameQueryResult
    {
        public GameQueryResult(Guid id, string name, Guid idCompany, DateTime buyDate, bool available, IEnumerable<LoanQueryResult> loans)
        {
            Id = id;
            Name = name;
            IdCompany = idCompany;
            BuyDate = buyDate;
            Available = available;
            Loans = loans;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdCompany { get; private set; }
        public DateTime BuyDate { get; private set; }
        public bool Available { get; private set; }
        public IEnumerable<LoanQueryResult> Loans { get; private set; }
    }
}
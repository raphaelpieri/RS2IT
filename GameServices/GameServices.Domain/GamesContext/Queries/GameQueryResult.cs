using System;
using System.Collections.Generic;
using System.Linq;
using GameServices.Domain.GamesContext.Entities;

namespace GameServices.Domain.GamesContext.Queries
{
    public class GameQueryResult
    {
        private readonly IList<LoanQueryResult> _loans;
        public GameQueryResult(Guid id, string name, Guid idCompany, DateTime buyDate, bool available, IEnumerable<Loan> loans)
        {
            Id = id;
            Name = name;
            IdCompany = idCompany;
            BuyDate = buyDate;
            Available = available;
            _loans = new List<LoanQueryResult>();
            
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdCompany { get; private set; }
        public DateTime BuyDate { get; private set; }
        public bool Available { get; private set; }
        public IEnumerable<LoanQueryResult> Loans => _loans;

        private void LoadLoans(IEnumerable<Loan> loans)
        {
            loans.ToList().ForEach(x =>
            {
                _loans.Add(new LoanQueryResult(x.Id, x.Friend.Name.ToString(),x.LoanDate, x.ReturnDate));
            });
        }
    }
}
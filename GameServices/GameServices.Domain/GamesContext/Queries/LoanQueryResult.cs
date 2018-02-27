using System;

namespace GameServices.Domain.GamesContext.Queries
{
    public class LoanQueryResult
    {
        public LoanQueryResult(Guid id, string friend, DateTime loanDate, DateTime? returnDate)
        {
            Id = id;
            Friend = friend;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public Guid Id { get; private set; }
        public string Friend { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
    }
}
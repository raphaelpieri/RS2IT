using System;
using GameService.Shared.Entities;

namespace GameServices.Domain.GamesContext.Entities
{
    public class Loan : Entity
    {
        protected Loan()
        {
        }

        public Loan(Friend friend)
        {
            Friend = friend;
            LoanDate = DateTime.Now;
        }

        public Friend Friend { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public void Return()
        {
            ReturnDate = DateTime.Now;
        }
    }
}
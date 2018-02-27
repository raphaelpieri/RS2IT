using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using GameService.Shared.Entities;

namespace GameServices.Domain.GamesContext.Entities
{
    public class Game : Entity
    {
        private readonly IList<Loan> _loans;
        
        protected Game()
        {
        }

        public Game(User user, string name, GameCompany company)
        {
            User = user;
            Name = name;
            Company = company;
            BuyDate = DateTime.Now;
            Available = true;
            
            _loans = new List<Loan>();
        }

        public void Alter(string name, GameCompany company)
        {
            Name = name;
            Company = company;
        }

        public User User { get; private set; }
        public string Name { get; private set; }
        public GameCompany Company { get; private set; }
        public DateTime BuyDate { get; private set; }
        public bool Available { get; private set; }

        public ICollection<Loan> Loans => _loans.ToArray();

        public void Lend(Loan loan)
        {
            if (Available)
            {
                _loans.Add(loan);
                Available = false;
            }
            else
                AddNotification(new Notification("Jogo", $"O jogo {Name} já está emprestado"));
            
        }

        public void Return()
        {
            if (!Available)
            {
                var loan = _loans.FirstOrDefault(x => !x.ReturnDate.HasValue);
                loan.Return();
                Available = true;
            }
            else
                AddNotification(new Notification("Jogo", $"O jogo {Name} não possui emprestimos"));
        }
    }
}
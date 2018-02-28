using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.Queries;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameServices.Infra.Repositories
{
    public class GameCompanyRepository: IGameCompanyRepository
    {
        private readonly GameServiceContext _context;

        public GameCompanyRepository(GameServiceContext context)
        {
            _context = context;
        }

        public GameCompany Get(Guid id)
        {
            return _context.GameCompanies.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Save(GameCompany gameCompany)
        {
            _context.GameCompanies.Add(gameCompany);
        }

        public Task<List<GameCompanyListQueryResult>> GetListQueryResults(Guid userId)
        {
            return _context.GameCompanies.Include(x => x.User).Where(x => x.User.Id == userId)
                .OrderBy(x => x.Name).Select(x => new GameCompanyListQueryResult(x.Id, x.Name)).
                ToListAsync();
        }
    }
}
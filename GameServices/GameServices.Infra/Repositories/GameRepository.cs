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
    public class GameRepository : IGameRepository
    {
        private readonly GameServiceContext _context;

        public GameRepository(GameServiceContext context)
        {
            _context = context;
        }

        public Game Get(Guid id)
        {
            return _context.Games.Include(x => x.User).Include(x => x.Loans).FirstOrDefault(x => x.Id == id);
        }

        public void Save(Game game)
        {
            _context.Games.Add(game);
        }

        public void Update(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
        }

        public void Remove(Guid id)
        {
            var game = Get(id);
            _context.Remove(game);
        }

        public Task<GameQueryResult> GetGameQueryResult(Guid id)
        {
            return _context.Games.Include(x => x.Loans).Include(x => x.Company)
                .Where(x => x.Id == id).OrderBy(x => x.Name)
                .Select(x => new GameQueryResult(x.Id, x.Name, x.Company.Id, x.BuyDate, x.Available, x.Loans))
                .FirstOrDefaultAsync();
        }

        public Task<List<GameListQueryResult>> GetListQueryResults(Guid userId)
        {
            return _context.Games.Include(x => x.User).Include(x => x.Company).Where(x => x.User.Id == userId)
                .OrderBy(x => x.Name)
                .Select(x => new GameListQueryResult(x.Name, x.Company.Name, x.BuyDate, x.Available)).ToListAsync();
        }
    }
}
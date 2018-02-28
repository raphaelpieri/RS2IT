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
    public class FriendRepository : IFriendRepository
    {
        private readonly GameServiceContext _context;

        public FriendRepository(GameServiceContext context)
        {
            _context = context;
        }

        public Friend Get(Guid id)
        {
            return _context.Friends.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Save(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        public void Update(Friend friend)
        {
            _context.Entry(friend).State = EntityState.Modified;
        }

        public void Remove(Guid id)
        {
            var friend = Get(id);
            _context.Friends.Remove(friend);
        }

        public Task<FriendQueryResult> GetFriendQueryResult(Guid id)
        {
            return _context.Friends.Select(x =>
                new FriendQueryResult(x.Id, x.Name.FirstName, x.Name.LastName, x.Phone)).
                FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<FriendListQueryResult>> GetListQueryResults(Guid userId)
        {
            return _context.Friends.Include(x => x.User).Where(x => x.User.Id == userId).OrderBy(x => x.Name.ToString())
                .Select(x => new FriendListQueryResult(x.Id, x.Name.ToString(), x.Phone))
                .ToListAsync();
        }
    }
}
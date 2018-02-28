using GameService.Shared;
using GameServices.Domain.GamesContext.Entities;
using GameServices.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GameServices.Infra.Contexts
{
    public class GameServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<GameCompany> GameCompanies { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new FriendMapping());
            modelBuilder.ApplyConfiguration(new GameCompanyMapping());
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new LoanMapping());
        }
    }
}
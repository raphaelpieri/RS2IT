using GameServices.Domain.GamesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameServices.Infra.Mappings
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.BuyDate).IsRequired();
            builder.Property(x => x.Available).IsRequired();
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Company);
            builder.HasMany(x => x.Loans);
            builder.Ignore(x => x.Notifications);
        }
    }
}
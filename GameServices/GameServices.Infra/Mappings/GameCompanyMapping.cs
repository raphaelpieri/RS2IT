using GameServices.Domain.GamesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameServices.Infra.Mappings
{
    public class GameCompanyMapping : IEntityTypeConfiguration<GameCompany>
    {
        public void Configure(EntityTypeBuilder<GameCompany> builder)
        {
            builder.ToTable("GameCompany");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.User);
            builder.Ignore(x => x.Notifications);
        }
    }
}
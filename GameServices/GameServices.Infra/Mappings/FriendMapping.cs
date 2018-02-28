using GameServices.Domain.GamesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameServices.Infra.Mappings
{
    public class FriendMapping : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friend");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Name, cb =>
            {
                cb.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(40).IsRequired();
                cb.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(80).IsRequired();
            });
            builder.OwnsOne(x => x.Email, cb =>
            {
                cb.Property(x => x.Address).HasColumnName("Email").HasMaxLength(150).IsRequired();
            });
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.User);
        }
    }
}
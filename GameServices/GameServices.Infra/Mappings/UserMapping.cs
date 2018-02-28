using GameServices.Domain.GamesContext.Entities;
using GameServices.Domain.GamesContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameServices.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
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
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(32);
            builder.Ignore(x => x.Notifications);
        }
    }
}
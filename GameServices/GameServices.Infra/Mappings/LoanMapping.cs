using GameServices.Domain.GamesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameServices.Infra.Mappings
{
    public class LoanMapping : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("GameCompany");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LoanDate).IsRequired();
            builder.Property(x => x.ReturnDate);
            builder.HasOne(x => x.Friend);
            builder.Ignore(x => x.Notifications);
        }
    }
}
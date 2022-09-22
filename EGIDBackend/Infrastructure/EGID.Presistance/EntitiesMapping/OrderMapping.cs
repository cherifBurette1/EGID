using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EGID.Data.Entities;
namespace EGID.Presistance.EntitiesMapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(i => i.Id).IsClustered(false);

            builder
                .HasOne(s => s.Person)
                .WithMany(c => c.Orders)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(s => s.Person)
                .WithMany(c => c.Orders)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(s => s.Broker)
                .WithMany(c => c.Orders)
                .HasForeignKey(a => a.BrokerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

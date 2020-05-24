using Cw11_Lab10_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11_Lab10_.Configurations
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(p => p.IdMedicament);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(100).IsRequired();
        }
    }
}

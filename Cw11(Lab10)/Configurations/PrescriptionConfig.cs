

using Cw11_Lab10_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11_Lab10_.Configurations
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.IdPrescription);
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.DueDate).IsRequired();
        }
    }
}

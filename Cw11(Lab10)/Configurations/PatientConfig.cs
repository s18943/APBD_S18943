

using Cw11_Lab10_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11_Lab10_.Configurations
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.IdPatient);
            builder.Property(p => p.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.BirdthDate).IsRequired();
        }
    }
}

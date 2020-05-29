using Cw12_Lab11_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw12_Lab11_.Configurations
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(p => p.IdDoctor);
            builder.Property(p => p.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(150).IsRequired().HasAnnotation("EmailAddress", "");
        }
    }
}

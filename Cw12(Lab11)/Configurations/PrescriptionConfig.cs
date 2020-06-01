﻿

using Cw12_Lab11_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw12_Lab11_.Configurations
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
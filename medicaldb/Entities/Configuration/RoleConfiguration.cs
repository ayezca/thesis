using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string HostId = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string DoctorId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = HostId,
                    Name = "Host",
                    NormalizedName = "HOST"
                },
                new IdentityRole
                {
                    Id = DoctorId,
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                });
        }
    }
}

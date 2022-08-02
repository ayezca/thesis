using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData
            (
                new Doctor
                {
                    Id = 1,
                    Username = "mamysheva_a",
                    Password = "Samira1606",
                    FirstName = "Айнура",
                    LastName = "Мамышева",
                    Patronymic = "Шаршенбековна",
                    PhoneNumber = "+(996)550217812",
                    Email = "mamysheva30@gmail.com",
                    Address = "Джал-23, 12",
                    SpecialtyId = 1
                }
            );
        }
    }
}

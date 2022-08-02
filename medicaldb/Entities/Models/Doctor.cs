using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public IEnumerable<DoctorsOrganization> DoctorsOrganizations { get; set; }
        public IEnumerable<PatientsExamination> PatientsExaminations { get; set; }

    }
}

using System;
namespace Entities.Models
{
    public class DoctorsOrganization
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}

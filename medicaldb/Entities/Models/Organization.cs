using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IEnumerable<DoctorsOrganization> DoctorsOrganizations { get; set; }
    }
}

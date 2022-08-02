using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public IEnumerable<ComplainDto> Complains { get; set; }
        public IEnumerable<DiseaseAnamnesisDto> DiseaseAnamneses { get; set; }
        public LifeAnamnesisDto LifeAnamnesis { get; set; }
    }
}

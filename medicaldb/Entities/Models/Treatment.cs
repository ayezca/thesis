using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<PatientsTreatment> PatientsTreatments { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PatientsDisease> PatientsDiseases { get; set; }
    }
}

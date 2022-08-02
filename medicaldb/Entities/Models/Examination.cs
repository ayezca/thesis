using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public IEnumerable<PatientsExamination> PatientsExaminations { get; set; }
    }
}

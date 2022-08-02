using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}

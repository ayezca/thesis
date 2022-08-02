using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Vaccination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PatientsVaccination> PatientsVaccinations { get; set; }
    }
}

using System;
namespace Entities.Models
{
    public class PatientsVaccination
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int VaccinationId { get; set; }
        public double Age { get; set; }
    }
}

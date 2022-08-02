using System;
namespace Entities.Models
{
    public class PatientsDisease
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        public double Age { get; set; }
        public bool Complications { get; set; }
        public string Comments { get; set; }

    }
}

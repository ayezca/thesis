using System;
namespace Entities.Models
{
    public class PatientsTreatment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Dose { get; set; }
        public string Comments { get; set; }
    }
}

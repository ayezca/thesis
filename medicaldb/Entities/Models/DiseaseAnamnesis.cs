using System;
namespace Entities.Models
{
    public class DiseaseAnamnesis
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string DiseaseStart { get; set; }
        public string Cause { get; set; }
        public string Development { get; set; }
        public string Comments { get; set; }
    }
}

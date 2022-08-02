using System;
namespace Entities.Models
{
    public class Complain
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }
    }
}

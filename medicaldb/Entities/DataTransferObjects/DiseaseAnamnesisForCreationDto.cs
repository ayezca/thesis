using System;
namespace Entities.DataTransferObjects
{
    public class DiseaseAnamnesisForCreationDto
    {
        public int PatientId { get; set; }
        public string DiseaseStart { get; set; }
        public string Cause { get; set; }
        public string Development { get; set; }
        public string Comments { get; set; }
    }
}

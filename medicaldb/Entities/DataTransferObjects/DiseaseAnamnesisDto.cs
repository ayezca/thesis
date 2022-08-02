using System;
namespace Entities.DataTransferObjects
{
    public class DiseaseAnamnesisDto
    {
        public int Id { get; set; }
        public string DiseaseStart { get; set; }
        public string Cause { get; set; }
        public string Development { get; set; }
        public string Comments { get; set; }
    }
}

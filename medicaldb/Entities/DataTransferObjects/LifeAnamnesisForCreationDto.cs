using System;
namespace Entities.DataTransferObjects
{
    public class LifeAnamnesisForCreationDto
    {
        public int PatientId { get; set; }
        public int WeekOfBirth { get; set; }
        public int BirthOrder { get; set; }
        public string MothersPregnancy { get; set; }
        public bool PregnancyPathologies { get; set; }
        public string Labor { get; set; }
        public bool LaborPathologies { get; set; }
        public string Comments { get; set; }
    }
}

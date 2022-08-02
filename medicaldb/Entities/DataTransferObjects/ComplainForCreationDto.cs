using System;
namespace Entities.DataTransferObjects
{
    public class ComplainForCreationDto
    {
        public int PatientId { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }
    }
}

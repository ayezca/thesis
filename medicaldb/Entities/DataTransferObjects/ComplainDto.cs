using System;
namespace Entities.DataTransferObjects
{
    public class ComplainDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }
    }
}

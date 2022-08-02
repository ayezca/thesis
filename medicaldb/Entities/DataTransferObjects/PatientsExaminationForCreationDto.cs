using System;
namespace Entities.DataTransferObjects
{
    public class PatientsExaminationForCreationDto
    {
        public int Id { get; set; }
        //public int PatientId { get; set; }
        //public Patient Patient { get; set; }
        public int ExaminationId { get; set; }
        //public Examination Examination { get; set; }
        public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public string Conclusion { get; set; }
        public string PreliminaryDiagnosis { get; set; }
        public string FinalDiagnosis { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public IEnumerable<Complain> Complains { get; set; }
        public LifeAnamnesis LifeAnamnesis { get; set; }
        public IEnumerable<PatientsDisease> PatientsDiseases { get; set; }
        public IEnumerable<PatientsVaccination> PatientsVaccinations { get; set; }
        public IEnumerable<PatientsTreatment> PatientsTreatments { get; set; }
        public IEnumerable<PatientsExamination> PatientsExaminations { get; set; }
        public IEnumerable<DiseaseAnamnesis> DiseaseAnamneses { get; set; }
    }
}

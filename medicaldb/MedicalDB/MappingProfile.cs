using System;
using System.Linq;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace MedicalDB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(pd => pd.Complains, p => p.MapFrom(pc => pc.Complains))
                .ForMember(pd => pd.DiseaseAnamneses, p => p.MapFrom(pc => pc.DiseaseAnamneses))
                .ForMember(pd => pd.LifeAnamnesis, p => p.MapFrom(pc => pc.LifeAnamnesis))
                /*.ForMember(td => td.Diseases,
                    t =>
                        t.MapFrom(tc => tc.PatientsDiseases.Select(x => new DiseaseDto
                        {
                            Name = x.Disease.Name,
                        })))
                .ForMember(td => td.Examinations,
                    t =>
                        t.MapFrom(tc => tc.PatientsExaminations.Select(x => new ExaminationDto
                        {
                            Name = x.Examination.Name,
                        })))
                .ForMember(td => td.Treatments,
                    t =>
                        t.MapFrom(tc => tc.PatientsTreatments.Select(x => new TreatmentDto
                        {
                            Name = x.Treatment.Name,
                        })))*/
                .ForMember(pd => pd.FullName,
                    p => p.MapFrom(pc => string.Join(' ', pc.FirstName, pc.LastName, pc.Patronymic)));

            CreateMap<Doctor, DoctorDto>();

            CreateMap<DoctorForCreationDto, Doctor>();

            CreateMap<Examination, ExaminationDto>();

            CreateMap<ExaminationForCreationDto, Examination>();

            CreateMap<PatientForCreationDto, Patient>();

            CreateMap<PatientForUpdateDto, Patient>();

            CreateMap<Complain, ComplainDto>();

            CreateMap<ComplainForCreationDto, Complain>();

            CreateMap<PatientsExamination, PatientsExaminationDto>();

            CreateMap<PatientsExaminationForCreationDto, PatientsExamination>();

            CreateMap<DiseaseAnamnesis, DiseaseAnamnesisDto>();

            CreateMap<DiseaseAnamnesisForCreationDto, DiseaseAnamnesis>();

            CreateMap<Disease, DiseaseDto>();

            CreateMap<DiseaseForCreationDto, Disease>();

            CreateMap<Treatment, TreatmentDto>();

            CreateMap<TreatmentForCreationDto, Treatment>();

            CreateMap<LifeAnamnesis, LifeAnamnesisDto>();

            CreateMap<LifeAnamnesisForCreationDto, LifeAnamnesis>();

            CreateMap<UserForRegistrationDto, User>();

            /*CreateMap<Doctor, DoctorDto>()
                .ForMember(td => td.FirstName, t => t.MapFrom(tc => tc.User.FirstName))
                .ForMember(td => td.LastName, t => t.MapFrom(tc => tc.User.LastName))
                .ForMember(td => td.Email, t => t.MapFrom(tc => tc.User.Email))
                .ForMember(td => td.PhoneNumber, t => t.MapFrom(tc => tc.User.PhoneNumber));
                TODO.ForMember(td => td.Courses,
                    t =>
                        t.MapFrom(tc => tc.TeachersCourses.Select(x => new CourseDto
                        {
                            Name = x.Course.Name,
                            MaxSeats = x.Course.MaxSeats,
                            Price = x.Course.Price,
                            StartDate = x.Course.StartDate,
                            EndDate = x.Course.EndDate,
                        })));*/

        }
    }
}

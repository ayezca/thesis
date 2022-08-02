using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDB.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DoctorController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET all doctors
        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = _repository.Doctor.GetAllDoctors(false);

            var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(doctorsDto);
        }

        [HttpGet("{id}", Name = "DoctorById")]
        public IActionResult GetDoctor(int id)
        {
            var doctor = _repository.Doctor.GetDoctor(id, trackChanges: false);
            if (doctor == null)
            {
                _logger.LogInfo($"Doctor with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var doctorDto = _mapper.Map<DoctorDto>(doctor);
                return Ok(doctorDto);
            }
        }

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorForCreationDto doctor)
        {
            if (doctor == null)
            {
                _logger.LogError("DoctorForCreation object sent from client is null.");
                return BadRequest("DoctorForCreation object is null");
            }

            var doctorEntity = _mapper.Map<Doctor>(doctor);
            _repository.Doctor.CreateDoctor(doctorEntity);
            _repository.Save();

            var doctorToReturn = _mapper.Map<DoctorDto>(doctorEntity);
            return CreatedAtRoute("DoctorById", new { id = doctorToReturn.Id }, doctorToReturn);

        }

        /*[HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id)
        {
            var doctorEntity = _repository.Doctor.GetDoctor(id, true);
            doctorEntity.TeachersCourses = courses.Select(courseId => new TeachersCourse
            {
                CourseId = courseId,
                TeacherId = teacherEntity.Id
            }).ToList();

            _repository.Save();
            return NoContent();
        }*/

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _repository.Doctor.GetDoctor(id, trackChanges: false);
            if (doctor == null)
            {
                _logger.LogInfo($"Doctor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Doctor.DeleteDoctor(doctor);
            _repository.Save();

            return NoContent();
        }
    }
}

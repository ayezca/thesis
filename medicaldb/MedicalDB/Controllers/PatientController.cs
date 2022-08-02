using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalDB.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PatientController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET all patients
        [HttpGet]
        public IActionResult GetPatients([FromQuery] PatientParameters patientParameters)
        {
            var patients = _repository.Patient.GetAllPatients(patientParameters, false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(patients.MetaData));

            var patientsDto = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return Ok(patientsDto);
        }

        [HttpGet("{id}", Name = "PatientById")]
        public IActionResult GetPatient(int id)
        {
            var patient = _repository.Patient.GetPatient(id, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var patientDto = _mapper.Map<PatientDto>(patient);
                return Ok(patientDto);
            }
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] PatientForCreationDto patient)
        {
            if (patient == null)
            {
                _logger.LogError("PatientForCreationDto object sent from client is null.");
                return BadRequest("PatientForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the PatientForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var patientEntity = _mapper.Map<Patient>(patient);
            _repository.Patient.CreatePatient(patientEntity);
            _repository.Save();

            var patientToReturn = _mapper.Map<PatientDto>(patientEntity);
            return CreatedAtRoute("PatientById", new { id = patientToReturn.Id }, patientToReturn);

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] PatientForUpdateDto patient)
        {
            if (patient == null)
            {
                _logger.LogError("PatientForUpdateDto object sent from client is null.");
                return BadRequest("PatientForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the PatientForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var patientEntity = _repository.Patient.GetPatient(id, trackChanges: true);
            if (patientEntity == null)
            {
                _logger.LogInfo($"Patient with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(patient, patientEntity);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _repository.Patient.GetPatient(id, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Patient.DeletePatient(patient);
            _repository.Save();

            return NoContent();
        }

    }
}

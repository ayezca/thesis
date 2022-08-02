using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDB.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/examinations")]
    public class PatientsExaminationController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PatientsExaminationController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetExaminationsForPatient(int patientId)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var examinationsFromDb = _repository.PatientsExamination.GetAllExaminations(patientId, trackChanges: false);

            var examinationsDto = _mapper.Map<IEnumerable<PatientsExaminationDto>>(examinationsFromDb);

            return Ok(examinationsDto);
        }

        [HttpPost]
        public IActionResult CreateExaminationForPatient(int patientId, int examinationId, int doctorId, [FromBody] PatientsExaminationForCreationDto patientsExamination)
        {
            if (patientsExamination == null)
            {
                _logger.LogError("PatientsExaminationForCreationDto object sent from client is null.");
                return BadRequest("PatientsExaminationForCreationDto object is null");
            }

            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patient} doesn't exist in the database.");
                return NotFound();
            }

            /*var examination = _repository.Examination.GetExamination(examinationId, trackChanges: false);
            if (examination == null)
            {
                _logger.LogInfo($"Examination with id: {patient} doesn't exist in the database.");
                return NotFound();
            }

            var doctor = _repository.Doctor.GetDoctor(doctorId, trackChanges: false);
            if (doctor == null)
            {
                _logger.LogInfo($"Doctor with id: {patient} doesn't exist in the database.");
                return NotFound();
            }*/

            var patientsExaminationEntity = _mapper.Map<PatientsExamination>(patientsExamination);
            _repository.PatientsExamination.CreateExaminationForPatient(patientId, examinationId, doctorId, patientsExaminationEntity);
            _repository.Save();

            var examToReturn = _mapper.Map<PatientsExaminationDto>(patientsExaminationEntity);
            return CreatedAtRoute("GetExaminationForPatient", new { patientId, examinationId, doctorId, id = examToReturn.Id }, examToReturn);

        }
    }
}

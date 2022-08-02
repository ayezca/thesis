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
    [Route("api/patients/{patientId}/disease_anamneses")]
    public class DiseaseAnamnesisController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DiseaseAnamnesisController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDiseaseAnamnesesForPatient(int patientId)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var diseaseAnamnesesFromDb = _repository.DiseaseAnamnesis.GetAllDiseaseAnamneses(patientId, trackChanges: false);

            var diseaseAnamnesesDto = _mapper.Map<IEnumerable<DiseaseAnamnesisDto>>(diseaseAnamnesesFromDb);

            return Ok(diseaseAnamnesesDto);
        }

        [HttpGet("{id}", Name = "GetDiseaseAnamnesisForPatient")]
        public IActionResult GetDiseaseAnamnesisForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var diseaseAnamnesisDb = _repository.DiseaseAnamnesis.GetDiseaseAnamnesis(patientId, id, trackChanges: false);
            if (diseaseAnamnesisDb == null)
            {
                _logger.LogInfo($"Disease anamnesis with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var diseaseAnamnesis = _mapper.Map<DiseaseAnamnesisDto>(diseaseAnamnesisDb);

            return Ok(diseaseAnamnesis);
        }

        [HttpPost]
        public IActionResult CreateDiseaseAnamnesisForPatient(int patientId, [FromBody] DiseaseAnamnesisForCreationDto diseaseAnamnesis)
        {
            if (diseaseAnamnesis == null)
            {
                _logger.LogError("DiseaseAnamnesisForCreationDto object sent from client is null.");
                return BadRequest("DiseaseAnamnesisForCreationDto object is null");
            }

            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patient} doesn't exist in the database.");
                return NotFound();
            }

            var diseaseAnamnesisEntity = _mapper.Map<DiseaseAnamnesis>(diseaseAnamnesis);
            _repository.DiseaseAnamnesis.CreateDiseaseAnamnesisForPatient(patientId, diseaseAnamnesisEntity);
            _repository.Save();

            var diseaseAnamnesisToReturn = _mapper.Map<DiseaseAnamnesisDto>(diseaseAnamnesisEntity);
            return CreatedAtRoute("GetDiseaseAnamnesisForPatient", new { patientId, id = diseaseAnamnesisToReturn.Id }, diseaseAnamnesisToReturn);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiseaseAnamnesisForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var diseaseAnamnesisForPatient = _repository.DiseaseAnamnesis.GetDiseaseAnamnesis(patientId, id, trackChanges: false);
            if (diseaseAnamnesisForPatient == null)
            {
                _logger.LogInfo($"Disease anamnesis with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.DiseaseAnamnesis.DeleteDiseaseAnamnesis(diseaseAnamnesisForPatient);
            _repository.Save();

            return NoContent();
        }
    }
}

//TODO: update,

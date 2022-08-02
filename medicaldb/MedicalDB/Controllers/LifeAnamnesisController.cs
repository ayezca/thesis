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
    [Route("api/patients/{patientId}/life_anamnesis")]
    public class LifeAnamnesisController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public LifeAnamnesisController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetLifeAnamnesisForPatient")]
        public IActionResult GetLifeAnamnesisForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var lifeAnamnesisDb = _repository.LifeAnamnesis.GetLifeAnamnesis(patientId, id, trackChanges: false);
            if (lifeAnamnesisDb == null)
            {
                _logger.LogInfo($"Life anamnesis with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var lifeAnamnesis = _mapper.Map<LifeAnamnesisDto>(lifeAnamnesisDb);

            return Ok(lifeAnamnesis);
        }

        [HttpPost]
        public IActionResult CreateLifeAnamnesisForPatient(int patientId, [FromBody] LifeAnamnesisForCreationDto lifeAnamnesis)
        {
            if (lifeAnamnesis == null)
            {
                _logger.LogError("LifeAnamnesisForCreationDto object sent from client is null.");
                return BadRequest("LifeAnamnesisForCreationDto object is null");
            }

            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patient} doesn't exist in the database.");
                return NotFound();
            }

            var lifeAnamnesisEntity = _mapper.Map<LifeAnamnesis>(lifeAnamnesis);
            _repository.LifeAnamnesis.CreateLifeAnamnesisForPatient(patientId, lifeAnamnesisEntity);
            _repository.Save();

            var lifeAnamnesisToReturn = _mapper.Map<LifeAnamnesisDto>(lifeAnamnesisEntity);
            return CreatedAtRoute("GetLifeAnamnesisForPatient", new { patientId, id = lifeAnamnesisToReturn.Id }, lifeAnamnesisToReturn);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLifeAnamnesisForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var lifeAnamnesisForPatient = _repository.LifeAnamnesis.GetLifeAnamnesis(patientId, id, trackChanges: false);
            if (lifeAnamnesisForPatient == null)
            {
                _logger.LogInfo($"Life anamnesis with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.LifeAnamnesis.DeleteLifeAnamnesis(lifeAnamnesisForPatient);
            _repository.Save();

            return NoContent();
        }
    }
}

//TODO: update,

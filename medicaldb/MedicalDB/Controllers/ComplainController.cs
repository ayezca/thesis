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
    [Route("api/patients/{patientId}/complains")]
    public class ComplainController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ComplainController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComplainsForPatient(int patientId)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var complainsFromDb = _repository.Complain.GetAllComplains(patientId, trackChanges: false);

            var complainsDto = _mapper.Map<IEnumerable<ComplainDto>>(complainsFromDb);

            return Ok(complainsDto);
        }

        [HttpGet("{id}", Name = "GetComplainForPatient")]
        public IActionResult GetComplainForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var complainDb = _repository.Complain.GetComplain(patientId, id, trackChanges: false);
            if (complainDb == null)
            {
                _logger.LogInfo($"Complain with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var complain = _mapper.Map<ComplainDto>(complainDb);

            return Ok(complain);
        }

        [HttpPost]
        public IActionResult CreateComplainForPatient(int patientId, [FromBody] ComplainForCreationDto complain)
        {
            if (complain == null)
            {
                _logger.LogError("ComplainForCreationDto object sent from client is null.");
                return BadRequest("ComplainForCreationDto object is null");
            }

            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patient} doesn't exist in the database.");
                return NotFound();
            }

            var complainEntity = _mapper.Map<Complain>(complain);
            _repository.Complain.CreateComplainForPatient(patientId, complainEntity);
            _repository.Save();

            var complainToReturn = _mapper.Map<ComplainDto>(complainEntity);
            return CreatedAtRoute("GetComplainForPatient", new { patientId, id = complainToReturn.Id }, complainToReturn);
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComplainForPatient(int patientId, int id)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: false);
            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn't exist in the database.");
                return NotFound();
            }

            var complainForPatient = _repository.Complain.GetComplain(patientId, id, trackChanges: false);
            if (complainForPatient == null)
            {
                _logger.LogInfo($"Complain with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Complain.DeleteComplain(complainForPatient);
            _repository.Save();

            return NoContent();
        }
    }
}

//TODO: update,

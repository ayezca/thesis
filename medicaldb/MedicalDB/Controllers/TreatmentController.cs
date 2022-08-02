using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDB.Controllers
{
    [ApiController]
    [Route("api/treatments")]
    public class TreatmentController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TreatmentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET all treatments
        [HttpGet]
        public IActionResult GetTreatments()
        {
            var treatments = _repository.Treatment.GetAllTreatments(false);

            var treatmentsDto = _mapper.Map<IEnumerable<TreatmentDto>>(treatments);

            return Ok(treatmentsDto);
        }

        [HttpGet("{id}", Name = "TreatmentById")]
        public IActionResult GetTreatment(int id)
        {
            var treatment = _repository.Treatment.GetTreatment(id, trackChanges: false);
            if (treatment == null)
            {
                _logger.LogInfo($"Treatment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var treatmentDto = _mapper.Map<TreatmentDto>(treatment);
                return Ok(treatmentDto);
            }
        }

        [HttpPost]
        public IActionResult CreateTreatment([FromBody] TreatmentForCreationDto treatment)
        {
            if (treatment == null)
            {
                _logger.LogError("TreatmentForCreationDto object sent from client is null.");
                return BadRequest("TreatmentForCreationDto object is null");
            }

            var treatmentEntity = _mapper.Map<Treatment>(treatment);
            _repository.Treatment.CreateTreatment(treatmentEntity);
            _repository.Save();

            var treatmentToReturn = _mapper.Map<TreatmentDto>(treatmentEntity);
            return CreatedAtRoute("TreatmentById", new { id = treatmentToReturn.Id }, treatmentToReturn);

        }

        /*[HttpDelete("{id}")]
        public IActionResult DeleteExamination(int id)
        {
            var examination = _repository.Examination.GetExamination(id, trackChanges: false);
            if (examination == null)
            {
                _logger.LogInfo($"Examination with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Examination.DeleteExamination(examination);
            _repository.Save();

            return NoContent();
        }*/

        //TODO put
    }
}

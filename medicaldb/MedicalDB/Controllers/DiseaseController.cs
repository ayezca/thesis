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
    [Route("api/diseases")]
    public class DiseaseController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DiseaseController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET all diseases
        [HttpGet]
        public IActionResult GetDiseases()
        {
            var diseases = _repository.Disease.GetAllDiseases(false);

            var diseaseDto = _mapper.Map<IEnumerable<DiseaseDto>>(diseases);

            return Ok(diseaseDto);
        }

        [HttpGet("{id}", Name = "DiseaseById")]
        public IActionResult GetDisease(int id)
        {
            var disease = _repository.Disease.GetDisease(id, trackChanges: false);
            if (disease == null)
            {
                _logger.LogInfo($"Disease with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var diseaseDto = _mapper.Map<DiseaseDto>(disease);
                return Ok(diseaseDto);
            }
        }

        [HttpPost]
        public IActionResult CreateDisease([FromBody] DiseaseForCreationDto disease)
        {
            if (disease == null)
            {
                _logger.LogError("DiseaseForCreationDto object sent from client is null.");
                return BadRequest("DiseaseForCreationDto object is null");
            }

            var diseaseEntity = _mapper.Map<Disease>(disease);
            _repository.Disease.CreateDisease(diseaseEntity);
            _repository.Save();

            var diseaseToReturn = _mapper.Map<DiseaseDto>(diseaseEntity);
            return CreatedAtRoute("DiseaseById", new { id = diseaseToReturn.Id }, diseaseToReturn);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDisease(int id)
        {
            var disease = _repository.Disease.GetDisease(id, trackChanges: false);
            if (disease == null)
            {
                _logger.LogInfo($"Disease with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Disease.DeleteDisease(disease);
            _repository.Save();

            return NoContent();
        }

        //TODO put
    }
}

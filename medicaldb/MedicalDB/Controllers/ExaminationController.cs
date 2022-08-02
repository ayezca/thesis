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
    [Route("api/examinations")]
    public class ExaminationController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ExaminationController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET all examinations
        [HttpGet]
        public IActionResult GetExaminations()
        {
            var examinations = _repository.Examination.GetAllExaminations(false);

            var examinationsDto = _mapper.Map<IEnumerable<ExaminationDto>>(examinations);

            return Ok(examinationsDto);
        }

        [HttpGet("{id}", Name = "ExaminationById")]
        public IActionResult GetExamination(int id)
        {
            var examination = _repository.Examination.GetExamination(id, trackChanges: false);
            if (examination == null)
            {
                _logger.LogInfo($"Examination with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var examinationDto = _mapper.Map<ExaminationDto>(examination);
                return Ok(examinationDto);
            }
        }

        [HttpPost]
        public IActionResult CreateExamination([FromBody] ExaminationForCreationDto examination)
        {
            if (examination == null)
            {
                _logger.LogError("ExaminationForCreationDto object sent from client is null.");
                return BadRequest("ExaminationForCreationDto object is null");
            }

            var examinationEntity = _mapper.Map<Examination>(examination);
            _repository.Examination.CreateExamination(examinationEntity);
            _repository.Save();

            var examinationToReturn = _mapper.Map<ExaminationDto>(examinationEntity);
            return CreatedAtRoute("ExaminationById", new { id = examinationToReturn.Id }, examinationToReturn);

        }

        [HttpDelete("{id}")]
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
        }

        //TODO put
    }
}

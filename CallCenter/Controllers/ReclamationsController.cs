using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallCenter.Core.Models;
using CallCenter.Core.Dtos;
using CallCenter.Core;

namespace CallCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamationsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ReclamationsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReclamationDto>> GetReclamations()
        {
            var reclamationsQuery = await _unitOfWork.Reclamations.GetReclamationsAsync();
            

            return mapper.Map<IEnumerable<Reclamations>, IEnumerable<ReclamationDto>>(reclamationsQuery);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReclamation(int id)
        {
            var reclamation = await _unitOfWork.Reclamations.GetReclamationAsync(id);

            if (reclamation == null)
                return NotFound();

            return Ok(mapper.Map<Reclamations, ReclamationDto>(reclamation));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewReclamations(ReclamationDto newReclamationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var soldDevice = await _unitOfWork.SoldDevices.GetSoldDeviceAsync(newReclamationDto.SoldDeviceId);

            if (soldDevice.ExpiredWarranty() == true)
                return BadRequest("Warranty for this device has expired.");

            var reclamation = mapper.Map<ReclamationDto, Reclamations>(newReclamationDto);

            if (User.IsInRole(RoleName.AgentRoleName))
            {
                reclamation.Agent = _unitOfWork.Employees.GetAgent(reclamation.AgentId);
                reclamation.Create();
            }

            _unitOfWork.Reclamations.Add(reclamation);
            _unitOfWork.Complete();

            newReclamationDto.Id = reclamation.Id;
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReclamation(int id, ReclamationDto reclamationDbo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reclamationInDb = await _unitOfWork.Reclamations.GetReclamationAsync(id);

            if (reclamationInDb == null)
                return NotFound();

            mapper.Map(reclamationDbo, reclamationInDb);

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReclamation(int id)
        {
            var reclamationInDb = await _unitOfWork.Reclamations.GetReclamationAsync(id);

            if (reclamationInDb == null)
                return NotFound();

            _unitOfWork.Reclamations.Remove(reclamationInDb);
            _unitOfWork.Complete();

            return Ok();
        }

    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using CallCenterManagementSystem.Dtos;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CallCenter.Core.Models;
using CallCenter.Core.Dtos;
using CallCenter.Core;


namespace CallCenterManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = _mapper;
        }

        [HttpGet("su")]
        public async Task<IActionResult> GetEmployees()
        {
            var employeesQuery = await _unitOfWork.Employees.GetEmployeesAsync();



            return Ok(employeesQuery);
        }

        [Route("/api/desi")]
        [HttpGet]
        public async Task<IActionResult> GetDesignations()
        {
            var employeesQuery = await _unitOfWork.Designations.GetDesignationsAsync();



            return Ok(employeesQuery);
        }

        [HttpPost]
        [Route("/api/employees")]
        public ActionResult CreateEmployee(EmployeeDto employeeDto)
        {

            var employee = _Mapper.Map<EmployeeDto, Employees>(employeeDto);
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();

            return Ok();
        }


        [Route("/api/rec")]
        [HttpGet]
        public async Task<IActionResult> GetReclamations()
        {
            var employeesQuery = await _unitOfWork.Reclamations.GetReclamationsAsync();



            return Ok(employeesQuery);
        }

    }
}

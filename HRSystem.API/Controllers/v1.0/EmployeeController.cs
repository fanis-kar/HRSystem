using AutoMapper;
using HRSystem.API.DTOs;
using HRSystem.BLL.Interfaces;
using HRSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _repositoryEmployee;

        public EmployeeController(IMapper mapper, IRepository<Employee> repositoryEmployee)
        {
            _mapper = mapper;
            _repositoryEmployee = repositoryEmployee;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = _mapper.Map<IEnumerable<EmployeeDTO>>(_repositoryEmployee.GetAll());
            return Ok(employees);
        }
    }
}

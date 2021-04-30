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
    [Route("api/{v:apiVersion}/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Department> _repositoryDepartment;

        public DepartmentController(IMapper mapper, IRepository<Department> repositoryDepartment)
        {
            _mapper = mapper;
            _repositoryDepartment = repositoryDepartment;
        }

        [HttpGet]
        public IEnumerable<DepartmentDTO> GetAsync()
        {
            return _mapper.Map<IEnumerable<DepartmentDTO>>(_repositoryDepartment.GetAll());
        }
    }
}

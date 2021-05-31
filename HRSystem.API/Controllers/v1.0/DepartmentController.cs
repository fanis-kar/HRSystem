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
    [Route("api/{v:apiVersion}/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Department> _repositoryDepartment;

        public DepartmentController(IMapper mapper, IRepository<Department> repositoryDepartment)
        {
            _mapper = mapper;
            _repositoryDepartment = repositoryDepartment;
        }

        // GET api/{v:apiVersion}/departments
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> Get()
        {
            var departments = _mapper.Map<IEnumerable<DepartmentDTO>>(_repositoryDepartment.GetAll());
            return Ok(departments);
        }

        // GET api/{v:apiVersion}/departments/{id}
        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> Get(int id)
        {
            var department = _mapper.Map<DepartmentDTO>(_repositoryDepartment.Get(id));

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        // POST api/{v:apiVersion}/departments
        [HttpPost]
        public ActionResult Post([FromBody] DepartmentDTO  departmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newDepartment = _repositoryDepartment.Insert(_mapper.Map<Department>(departmentDTO));
            
            return CreatedAtAction("Get", new { id = newDepartment.Id }, newDepartment);
        }

        // POST api/{v:apiVersion}/departments/update
        [HttpPost]
        [Route("Update")]
        public ActionResult Update([FromBody] DepartmentDTO departmentDTO)
        {
            var existingDepartment = _repositoryDepartment.Get(departmentDTO.Id);

            if (existingDepartment == null)
                return NotFound();

            var updatedDepartment = _repositoryDepartment.Update(_mapper.Map<Department>(departmentDTO));
            return Ok(updatedDepartment);
        }

        // DELETE api/{v:apiVersion}/departments/{id}
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingDepartment = _repositoryDepartment.Get(id);

            if (existingDepartment == null)
                return NotFound();

            _repositoryDepartment.Delete(existingDepartment);
            return Ok();
        }
    }
}

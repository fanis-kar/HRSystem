using AutoMapper;
using HRSystem.API.Controllers;
using HRSystem.API.DTOs;
using HRSystem.BLL.Interfaces;
using HRSystem.BLL.Services;
using HRSystem.DAL;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace HRSystem.API.UnitTests.v1._0
{
    public class DepartmentControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Department> _repository;
        private readonly DepartmentController _departmentController;

        public DepartmentControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new HRSystem.API.DTOs.AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _repository = new FakeRepository();
            _departmentController = new DepartmentController(_mapper, _repository);
        }

        #region GET
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var controllerResult = _departmentController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(controllerResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllDepartments()
        {
            // Act
            var okResult = _departmentController.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<DepartmentDTO>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            Random rnd = new();
            int rndId = rnd.Next(1, 1000);

            // Act
            var notFoundResult = _departmentController.Get(rndId);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int id = 2;

            // Act
            var okResult = _departmentController.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int id = 2;

            // Act
            var okResult = _departmentController.Get(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<DepartmentDTO>(okResult.Value);
            Assert.Equal(id, (okResult.Value as DepartmentDTO).Id);
        }
        #endregion

        #region ADD
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new DepartmentDTO()
            {
                Created = DateTime.Now
            };

            _departmentController.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _departmentController.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            DepartmentDTO testItem = new()
            {
                Name = "Test Department Name",
                Created = DateTime.Now
            };

            // Act
            var createdResponse = _departmentController.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            DepartmentDTO testItem = new()
            {
                Name = "Test Department Name",
                Created = DateTime.Now
            };

            // Act
            var createdResponse = _departmentController.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Department;

            // Assert
            Assert.IsType<Department>(item);
            Assert.Equal("Test Department Name", item.Name);
        }
        #endregion

        #region  UPDATE
        [Fact]
        public void Update_InvalidObjectIdPassed_ReturnsBadRequest()
        {
            // Arrange
            Random rnd = new();
            int rndId = rnd.Next(1, 1000);

            DepartmentDTO testItem = new()
            {
                Id = rndId,
                Name = "Test Name",
                Created = DateTime.Now
            };

            // Act
            var notFoundResult = _departmentController.Update(testItem);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            
            DepartmentDTO testItem = new()
            {
                Id = 2,
                Name = "Test Name2", // HasMaxLength(10)
                Created = DateTime.Now
            };

            // Act
            var okObjectResult = _departmentController.Update(testItem) as OkObjectResult;

            // Assert
            Assert.IsType<Department>(okObjectResult.Value);
            Assert.Equal("Test Name2", (okObjectResult.Value as Department).Name);
        }
        #endregion

        #region REMOVE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            Random rnd = new();
            int rndId = rnd.Next(1, 1000);

            // Act
            var notFoundResult = _departmentController.Remove(rndId);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int id = 2;

            // Act
            var okResponse = _departmentController.Remove(id);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            int id = 2;

            // Act
            _departmentController.Remove(id);

            // Assert
            Assert.Equal(expected: 1, _repository.GetAll().Count());
        }
        #endregion
    }
}

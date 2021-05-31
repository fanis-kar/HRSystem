using HRSystem.BLL.Interfaces;
using HRSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.API.UnitTests
{
    public class FakeRepository : IRepository<Department>
    {
        private readonly List<Department> _departments;
        public FakeRepository()
        {
            _departments = new List<Department>()
            {
                new Department() 
                { 
                    Id = 1,
                    Name = "ice",
                    Created = DateTime.Now
                },
                new Department()
                {
                    Id = 2,
                    Name = "geo",
                    Created = DateTime.Now
                }
            };
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public Department Get(int id)
        {
            return _departments
                .Where(d => d.Id == id)
                .FirstOrDefault();
        }

        public Department Insert(Department entity)
        {
            _departments.Add(entity);
            return entity;
        }

        public Department Update(Department entity)
        {
            var existing = _departments
                .Where(d => d.Id == entity.Id)
                .FirstOrDefault();

            existing.Name = entity.Name;
            existing.Created = entity.Created;

            return existing;
        }

        public void Delete(Department entity)
        {
            var existing = _departments.First(d => d.Id == entity.Id);
            _departments.Remove(existing);
        }
    }
}

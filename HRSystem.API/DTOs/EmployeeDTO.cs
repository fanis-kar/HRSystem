using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.API.DTOs
{
    public class EmployeeDTO : BaseEntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public virtual DepartmentDTO Department { get; set; }
    }
}

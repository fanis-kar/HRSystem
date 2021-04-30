using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.API.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}

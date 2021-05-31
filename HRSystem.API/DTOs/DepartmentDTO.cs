using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.API.DTOs
{
    public class DepartmentDTO : BaseEntityDTO
    {
        [Column(TypeName = "nvarchar(10)")]
        public string Name { get; set; }
    }
}

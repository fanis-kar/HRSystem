using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HRSystem.DAL
{
    public class Department : BaseEntity
    {
        [Column(TypeName = "nvarchar(10)")]
        public string Name { get; set; }
    }
}

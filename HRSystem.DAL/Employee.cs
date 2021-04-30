using System;
using System.Collections.Generic;
using System.Text;

namespace HRSystem.DAL
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

    }
}

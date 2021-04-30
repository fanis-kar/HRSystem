using System;
using System.Collections.Generic;
using System.Text;

namespace HRSystem.DAL
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
    }
}

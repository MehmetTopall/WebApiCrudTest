﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int SuperVisorId { get; set; }
        public bool IsSuperVisor { get; set; }
    }
}

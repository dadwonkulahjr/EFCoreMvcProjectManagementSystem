using EFCoreMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.CustomComponent
{
    public class DepartmentHeadCount
    {
        public Department.Dept Department { get; set; }
        public int Count { get; set; }
    }
}

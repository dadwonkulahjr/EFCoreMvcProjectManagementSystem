using EFCoreMvcProject.Models;
using EFCoreMvcProject.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly ItuseTheProgrammerRepo _ituse;

        public HeadCountViewComponent(ItuseTheProgrammerRepo ituse)
        {
            _ituse = ituse;
        }
        public IViewComponentResult Invoke(Department.Dept? departmentName = null)
        {
            var result = _ituse.DepartmentHeadCounts(departmentName);
            return View(result);
        }
    }
}

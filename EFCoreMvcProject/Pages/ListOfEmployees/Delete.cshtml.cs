using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMvcProject.Models;
using EFCoreMvcProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMvcProject.Pages.ListOfEmployees
{
    public class DeleteModel : PageModel
    {
        private readonly ItuseTheProgrammerRepo _tuseRepo;
        [BindProperty]
        public Employee Employee { get; set; }
        public DeleteModel(ItuseTheProgrammerRepo ituseRepo)
        {
            _tuseRepo = ituseRepo;
        }
  
        public IActionResult OnGet(int id)
        {
            Employee = _tuseRepo.FindEmployeeById(id);
            if (Employee != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/ErrorHandler/Error");
            }
        }

        public IActionResult OnPost()
        {
            Employee = _tuseRepo.DeleteExistingEmployee(Employee.Id);
            if(Employee != null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("/ErrorHandler/Error");
            }
        }
    }
}

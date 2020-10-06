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
    public class IndexModel : PageModel
    {
        private readonly ItuseTheProgrammerRepo _tuseRepo;
        public IEnumerable<Employee> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchForEmployee { get; set; }
        public IndexModel(ItuseTheProgrammerRepo ituseRepo)
        {
            _tuseRepo = ituseRepo;
        }
        public IActionResult OnGet()
        {

            Employees = _tuseRepo.Search(searchTerm: SearchForEmployee);
            if (Employees != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/ErrorHandler/Error");
            }
        }
    }
}

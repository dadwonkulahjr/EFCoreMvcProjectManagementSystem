using EFCoreMvcProject.Models;
using EFCoreMvcProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMvcProject.Pages.ListOfEmployees
{
    public class DetailsModel : PageModel
    {
        private readonly ItuseTheProgrammerRepo _tuseRepo;
        public Employee Employee { get; set; }
       
        [TempData]
        public string Message { get; set; }
        public DetailsModel(ItuseTheProgrammerRepo ituseRepo)
        {
            _tuseRepo = ituseRepo;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _tuseRepo.FindEmployeeById(id);
            if(Employee != null)
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMvcProject.Models;
using EFCoreMvcProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMvcProject.Pages.ListOfEmployees
{
    public class EditModel : PageModel
    {
        private readonly ItuseTheProgrammerRepo _tuseRepo;
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        [BindProperty]
        public string Message { get; set; }

        //[Display(Name ="Photo")]
        //public IFormFile FormFileImage { get; set; }
        public EditModel(ItuseTheProgrammerRepo ituseRepo)
        {
            _tuseRepo = ituseRepo;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = _tuseRepo.FindEmployeeById(id.Value);
            }
            else
            {
                Employee = new Employee();
            }

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
            if (ModelState.IsValid)
            {
                if (Employee.Id > 0)
                {
                    Employee = _tuseRepo.UpdateEmployee(Employee);
                }
                else
                {
                    Employee = _tuseRepo.CreateNewEmployee(Employee);
                }
                if (Employee != null)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return RedirectToPage("/ErrorHandler/Error");
                }
            }
            return Page();
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications!";
            }
            else
            {
                Message = "You have turned off email notifications!";
            }
            TempData["message"] = Message;

            return RedirectToPage("Details", new { id = id });

        }


    }
}

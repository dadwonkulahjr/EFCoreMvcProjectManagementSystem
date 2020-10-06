using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMvcProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMvcProject.Pages.Account
{
    public class AdminLogInPortalModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminLogInPortalModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public AdminLogInModel AdminLogInModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(AdminLogInModel.Email,
                     AdminLogInModel.Password, isPersistent: AdminLogInModel.RememberMe,
                     lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/ListOfEmployees/Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            return Page();
        }
    }
}

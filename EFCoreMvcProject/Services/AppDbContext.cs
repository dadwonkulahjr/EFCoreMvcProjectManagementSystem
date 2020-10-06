using EFCoreMvcProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Services
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   modelBuilder.Entity<IdentityUser>(buildAction:options =>
        //   {
        //       options.HasData(new IdentityUser()
        //       {
        //           Email = "tuseTheProgrammer@comaxict.com",
        //           UserName = "tuseTheProgrammer@comaxict.com",
                  
        //       })
        //   })
        //}

    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The minimun characters should be 3")]
        [Column(name: "FullName", TypeName = "nvarchar(50)")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email."),Display(Name = "Office Email")]
        [Column(name: "Office Email", TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        //[Required]
       
        public string Photo { get; set; }
        [Required]
        [Display(Name = "Department")]
        [Column(name: "Department", TypeName = "nvarchar(20)")]
        public Department.Dept? Dept { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salary { get; set; }
    }
}

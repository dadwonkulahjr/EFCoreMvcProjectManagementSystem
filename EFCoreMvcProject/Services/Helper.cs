using EFCoreMvcProject.CustomComponent;
using EFCoreMvcProject.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Service
{
    public class Helper : ItuseTheProgrammerRepo
    {
        private List<Employee> _employees;

        public Helper()
        {
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 101,
                    Name = "John Brown",
                    Email = "john@gmail.com",
                    Dept = Department.Dept.IT,
                    Photo = "img_avatar1.png",
                    Salary = 6500
                },
                new Employee()
                {
                    Id = 102,
                    Name = "Sam Toe",
                    Email = "sam@gmail.com",
                    Dept = Department.Dept.Engineering,
                    Photo = "img_avatar2.png",
                    Salary = 10000
                },
                new Employee()
                {
                    Id = 103,
                    Name = "Peter Smith",
                    Email = "peter@yahoo.com",
                    Dept = Department.Dept.HR,
                    Photo = "img_avatar3.png",
                    Salary = 12000
                },
                new Employee()
                {
                    Id = 104,
                    Name = "Mary Collins",
                    Email = "mary@outlook.com",
                    Dept = Department.Dept.Engineering,
                    Photo = "img_avatar4.png",
                    Salary = 14000
                },
                new Employee()
                {
                    Id = 105,
                    Name = "Princess Morris",
                    Email = "princess@hotmail.com",
                    Dept = Department.Dept.Payroll,
                    Photo = "img_avatar5.png",
                    Salary = 6000
                }
            };
        }

        public Employee CreateNewEmployee(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee DeleteExistingEmployee(int id)
        {
            Employee employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<DepartmentHeadCount> DepartmentHeadCounts(Department.Dept? department)
        {
            IEnumerable<Employee> query = _employees;
            if (department.HasValue)
            {
                query = query.Where(x => x.Dept == department.Value);
            }
            return query.GroupBy(x => x.Dept)
                         .Select(g => new DepartmentHeadCount()
                         {
                             Department = g.Key.Value,
                             Count = g.Count()
                         }).ToList();
        }

        public Employee FindEmployeeById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _employees;
            }
            return _employees.Where(e => e.Name.Contains(searchTerm)
            || e.Email.Contains(searchTerm));
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            Func<Employee, bool> checkEmp = x => x.Id == employeeChanges.Id;
            Employee employee = _employees.FirstOrDefault(x => checkEmp(x));
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Salary = employeeChanges.Salary;
                employee.Dept = employeeChanges.Dept;
            }

            return employee;
        }

       
    }
}

using EFCoreMvcProject.CustomComponent;
using EFCoreMvcProject.Service;
using EFCoreMvcProject.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Models
{
    public class SQLDataAccess : ItuseTheProgrammerRepo
    {
        private readonly AppDbContext _appDbContext;

        public SQLDataAccess(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Employee CreateNewEmployee(Employee employee)
        {
            _appDbContext.Database.ExecuteSqlRaw("sp_InsertData {0}, {1}, {2}, {3}, {4}",
                employee.Name, employee.Email, employee.Photo, employee.Dept, employee.Salary);
            return employee;
        }

        public Employee DeleteExistingEmployee(int id)
        {
            Employee deletedEmployee = _appDbContext.Employees.Find(id);
            if (deletedEmployee != null)
            {
                _appDbContext.Employees.Remove(deletedEmployee);
                _appDbContext.SaveChanges();
            }
            return deletedEmployee;
        }

        public IEnumerable<DepartmentHeadCount> DepartmentHeadCounts(Department.Dept? department)
        {
            IEnumerable<Employee> query = _appDbContext.Employees;
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
            SqlParameter sqlParameter = new SqlParameter("@Id", id);
            return _appDbContext.Employees.FromSqlRaw
                ("sp_GetEmployeeById @Id", sqlParameter).ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _appDbContext.Employees;
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _appDbContext.Employees;
            }
            return _appDbContext.Employees.Where(e => e.Name.Contains(searchTerm)
            || e.Email.Contains(searchTerm));
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            var result = _appDbContext.Employees.Attach(employeeChanges);
            result.State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return employeeChanges;

        }
    }
}

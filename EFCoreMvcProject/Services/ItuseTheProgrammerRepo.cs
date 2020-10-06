using EFCoreMvcProject.CustomComponent;
using EFCoreMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMvcProject.Service
{
    public interface ItuseTheProgrammerRepo
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetEmployees();
        Employee DeleteExistingEmployee(int id);
        Employee FindEmployeeById(int id);
        Employee CreateNewEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeeChanges);
        IEnumerable<DepartmentHeadCount> DepartmentHeadCounts(Department.Dept? department);

    }
}

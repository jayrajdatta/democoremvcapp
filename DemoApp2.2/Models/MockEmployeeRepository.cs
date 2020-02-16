using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp2._2.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1, Name="Amar", Department="HR", Email="amar@test.com"},
                new Employee(){Id=2, Name="Samar", Department="IT", Email="samar@test.com"},
                new Employee(){Id=3, Name="Alok", Department="IT", Email="alok@test.com"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault<Employee>(e => e.Id == id);
        }
    }
}

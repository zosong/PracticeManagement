using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }

                return instance;
            }
        }
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }
        private EmployeeService()
        {
            employees = new List<Employee> {
                new Employee{Id = 1, Name = "Oteo", Rate=725M}
            };
        }

        public Employee? Get(int id)
            => Employees.FirstOrDefault(e => e.Id == id);
    }
}
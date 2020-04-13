using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class MockEmplyeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employyeList;

        public MockEmplyeeRepository()
        {
            _employyeList = new List<Employee>()
            {
                new Employee(){ID = 1 ,Name = "Michael",Department =Dept.HR},
                new Employee(){ID = 2 ,Name ="Monica",Department = Dept.IT},
                new Employee(){ID = 3 ,Name ="Anthony",Department = Dept.PayRoll},
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.ID = _employyeList.Max(x => x.ID) + 1;
            _employyeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetALlEmployees()
        {
            return _employyeList;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = _employyeList.FirstOrDefault(x => x.ID == id);
            return employee;
        }
    }
}

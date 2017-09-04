using System.Collections.Generic;

namespace RP.Data
{
    public interface IEmployeeRepository 
    {
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(long id);
        void DeleteEmployee(long id);
        void UpdateEmployee(Employee employee);
    }
}

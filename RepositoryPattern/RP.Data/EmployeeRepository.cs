using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RP.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationContext context;
        private DbSet<Employee> employeeEntity;
        public EmployeeRepository(ApplicationContext context)
        {
            this.context = context;
            employeeEntity = context.Set<Employee>();
        }


        public void SaveEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeEntity.AsEnumerable();
        }

        public Employee GetEmployee(long id)
        {
            return employeeEntity.Find(id);
        }
        public void DeleteEmployee(long id)
        {
            Employee employee = GetEmployee(id);
            employeeEntity.Remove(employee);
            context.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {            
            context.SaveChanges();
        }   
    }
}

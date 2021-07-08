using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorcrud.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazorcrud.Data
{
    public class EmployeeService
    {
        #region Property
        private readonly AppDbContext _appDBContext;
        #endregion

        #region Constructor
        public EmployeeService(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _appDBContext.Employees.ToListAsync();
        }
        #endregion

        #region Insert Employee
        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            await _appDBContext.Employees.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Employee by Id
        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            Employee employee = await _appDBContext.Employees.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return employee;
        }
        #endregion

        #region Update Employee
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _appDBContext.Employees.Update(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteEmployee
        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            _appDBContext.Remove(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
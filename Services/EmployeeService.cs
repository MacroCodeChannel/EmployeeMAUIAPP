using EmployeeApp.DbContext;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {

        public SQLiteAsyncConnection _dbConnection;

        private async Task SetupDatabase()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MainDatabase.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Employee>();
            }
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            await SetupDatabase();
            return  await _dbConnection.InsertAsync(employee);

        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            await SetupDatabase();
            return await _dbConnection.DeleteAsync(employee);
        }

        public async Task<List<Employee>> GetEmployeesList()
        {
            await SetupDatabase();
            var employeeslist = await _dbConnection.Table<Employee>().ToListAsync();
                return employeeslist;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            await SetupDatabase();
            return await _dbConnection.UpdateAsync(employee);
        }

    }
}

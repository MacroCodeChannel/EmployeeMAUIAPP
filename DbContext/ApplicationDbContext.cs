using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DbContext
{
    public class ApplicationDbContext
    {
        public SQLiteAsyncConnection _dbConnection;

        // Application Database
        public readonly static string nameSpace = "EmployeeApp.DbContext.";

        public const string DatabaseFilename = "EmployeeApp.DbContext.db3";

        public static string dtabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLite.SQLiteOpenFlags Flags =
           // open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite |
           // create the database if it doesn't exist
           SQLite.SQLiteOpenFlags.Create |
           // enable multi-threaded database access
           SQLite.SQLiteOpenFlags.SharedCache;

        public ApplicationDbContext()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteAsyncConnection(dtabasePath, Flags);
                _dbConnection.CreateTableAsync<Employee>(); //table 1
                _dbConnection.CreateTableAsync<Country>();//table 2
                _dbConnection.CreateTableAsync<Constituency>(); //table 3
                _dbConnection.CreateTableAsync<Locations>(); //table 4
                _dbConnection.CreateTableAsync<SubLocation>(); //table 4
                _dbConnection.CreateTableAsync<Village>(); //table 5
            }
        }

        public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsysnc<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.DeleteAsync(entity);
        }


        public async Task<int> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertOrReplaceAsync(entity);
        }

       public List<T> GetTableRows<T>(string tableName)
       {

            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query  = "SELECT * FROM ["+ tableName+"]";

            return _dbConnection.QueryAsync(map, query,obj).Result.Cast<T>().ToList();

      }

        public object GetTableRow(string tableName,string column,string value)
        {

            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM " + tableName + " WHERE " + column + "='"+ value+"'";

            return _dbConnection.QueryAsync(map, query, obj).Result.FirstOrDefault();

        }
    }
}

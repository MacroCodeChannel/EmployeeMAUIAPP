
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DbContext
{
    public  class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public int VillageId { get; set; }

        public string EmployeePhoto { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}

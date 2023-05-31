using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DbContext
{
    public class Village
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SubLocationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

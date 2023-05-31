using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DbContext
{
    public class Locations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ConstituencyId { get; set; }
        public string Code { get; set; }

        public string LocationName { get; set; }
    }
}

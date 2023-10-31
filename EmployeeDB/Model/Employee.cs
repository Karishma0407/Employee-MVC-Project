using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class Employee
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string FullName { get; set; }

        public Nullable<int> departmentid { get; set; }
        public Nullable<decimal> salary { get; set; }
        public Nullable<System.DateTime> hiredate { get; set; }

        public virtual department department { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class ModelMapping
    {
        public Employee LoadEmployee(EmployeeDB.employee empl)
        {
            return new Employee
            {
                id = empl.id,
                firstname = empl.firstname,
                lastname = empl.lastname,

                FullName = empl.firstname.Trim() + " " + empl.lastname.Trim()
            };
        }
    }
}

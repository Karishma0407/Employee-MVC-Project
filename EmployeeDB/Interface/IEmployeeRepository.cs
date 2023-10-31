using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Interface
{
    public interface IEmployeeRepository: IDisposable
    {
        IQueryable<employee> GetEmployee();
        bool IsEmployeeExist(string fName, string lName);
        bool AddEmployee(string fName, string lName);
    }
}

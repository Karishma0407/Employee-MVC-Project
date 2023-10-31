using EmployeeDB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeRepository: IEmployeeRepository
    {
        EmployeeContext _Ctx;

        public EmployeeRepository(EmployeeContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        //Method Development
        public IQueryable<employee> GetEmployee()
        {
            return _Ctx.Context.employees;
        }
        public bool AddEmployee(string fName, string lName)
        {
            return true;
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public bool IsEmployeeExist(string fName, string lName)
        {
            throw new NotImplementedException();
        }
    }
}

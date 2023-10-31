using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeContext
    {
        employeedbEntities _Ctx;

        public EmployeeContext()
        {
            _Ctx = new employeedbEntities();
        }

        public employeedbEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}

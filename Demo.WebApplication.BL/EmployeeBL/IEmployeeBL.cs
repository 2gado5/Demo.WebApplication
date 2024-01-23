using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WebApplication.BL.BaseBL;

namespace Demo.WebApplication.BL.EmployeeBL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        public string GetNewCode();
    }
}

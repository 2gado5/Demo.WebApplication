using B1.Demo.WebApplication.Common.Entities;
using B1.Demo.WebApplication.Common.Entities.DTO;
using Demo.WebApplication.DL.EmployeeDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.BL.EmployeeBL
{
    public class EmployeeBL : IEmployeeBL
    {
        #region Field
        private IEmployeeDL _employeeDL;
        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }
        #endregion

        public List<Employee> GetEmployees()
        {
            return _employeeDL.GetEmployees();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _employeeDL.GetEmployeeById(employeeId);
        }

        public PagingResult GetPaging(string? keyword, Guid? departmantId, Guid? positionId, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}

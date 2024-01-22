using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.BL.EmployeeBL
{
    public interface IEmployeeBL
    {
        public List<Employee> GetEmployees();

        public Employee GetEmployeeById(Guid employeeId);

        public PagingResult GetPaging(
           string? keyword,
           Guid? departmantId,
           Guid? positionId,
           int pageSize = 10,
           int pageNumber = 1);
    }
}

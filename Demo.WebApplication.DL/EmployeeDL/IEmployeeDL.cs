using B1.Demo.WebApplication.Common.Entities;
using B1.Demo.WebApplication.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.DL.EmployeeDL
{
    public interface IEmployeeDL
    {
        public IDbConnection GetOpenConnection();

        public Employee QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        public List<Employee> Query(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        public List<Employee> GetEmployees();

        public Employee GetEmployeeById(Guid employeeId);

        public int InsertEmployee(Employee employee);

        public int UpdateEmployee(Guid ID, Employee employee);

        public int DeleteEmployee(Guid employeeId);

        public PagingResult GetPaging(
           string? keyword,
           Guid? departmantId,
           Guid? positionId,
           int pageSize = 10,
           int pageNumber = 1);
    }
}

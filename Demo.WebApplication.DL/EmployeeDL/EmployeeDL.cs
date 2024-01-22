using B1.Demo.WebApplication.Common.Entities;
using B1.Demo.WebApplication.Common.Entities.DTO;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.DL.EmployeeDL
{
    public class EmployeeDL : IEmployeeDL
    {
        #region Field
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=quanlynv;Uid=root;Pwd=952003;";
        #endregion

        #region Method
        public IDbConnection GetOpenConnection()
        {
            var mySqlConnection = new MySqlConnection(_connectionString);
            mySqlConnection.Open();
            return mySqlConnection;
        }

        public Employee QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.QueryFirstOrDefault<Employee>(sql, param, transaction, commandTimeout, commandType);
        }

        public List<Employee> Query(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Query<Employee>(sql, param, transaction, true, commandTimeout, commandType).ToList();
        }


        public List<Employee> GetEmployees()
        {
            // cbi tên Stored
            string storedProcedureName = "Proc_employee_GetAll";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();

            //  khởi tạo kết nối vs DB
            var dbConnection = GetOpenConnection();

            // Thực hiện câu lệnh SQL
            var employees = Query(dbConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return employees;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            // cbi tên Stored
            string storedProcedureName = "Proc_employee_GetByID";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("v_EmployeeID", employeeId);

            //  khởi tạo kết nối vs DB
            var dbConnection = GetOpenConnection();

            // Thực hiện câu lệnh SQL
            var employee = QueryFirstOrDefault(dbConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return employee;
        }

        public int InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Guid ID, Employee employee)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public PagingResult GetPaging(string? keyword, Guid? departmantId, Guid? positionId, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}

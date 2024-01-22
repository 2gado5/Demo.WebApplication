using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Enums;
using Dapper;
using Demo.WebApplication.BL.EmployeeBL;
using Demo.WebApplication.Comon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;

namespace B1.Demo.WebApplication.API.Controllers
{
    [Route("api/[controller]")] // Attribute 
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        #region Field
        private IEmployeeBL _employeeBL;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        #endregion

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeBL.GetEmployees();

                // Thành công
                if (employees != null)
                {
                    return StatusCode(200, employees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Nếu dùng HttpGet có tham số đầu vào truyền vào FromRoute thì trg HttpGet phải thêm tên biến truyền vào 
        /// API lấy thông tin chi tiết 1 nhân viên
        /// Lấy ttin 1 bảng dùng FromRoute
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] Guid employeeId)
        {
            try
            {
                var employee = _employeeBL.GetEmployeeById(employeeId);

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        ///// <summary>
        ///// Insert dùng FromBody
        ///// StatusCode dành riêng cho tạo mới sẽ là 201
        ///// </summary>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult InsertEmployee([FromBody] Employee employee)
        //{
        //    try
        //    {
        //        // cbi tên Stored
        //        string storedProcedureName = "Proc_employee_Insert";

        //        // chuẩn bị tham số đầu vào 
        //        var parameters = new DynamicParameters();
        //        parameters.Add("v_EmployeeID", employee.EmployeeID);
        //        parameters.Add("v_EmployeeCode", employee.EmployeeCode);
        //        parameters.Add("v_FullName", employee.FullName);
        //        parameters.Add("v_Gender", employee.Gender);
        //        parameters.Add("v_DateOfBirth", employee.DateOfBirth);
        //        parameters.Add("v_CMTND", employee.CMTND);
        //        parameters.Add("v_IssuedBy", employee.IssuedBy);
        //        parameters.Add("v_JobTitle", employee.JobTitle);
        //        parameters.Add("v_Address", employee.Address);
        //        parameters.Add("v_PhoneNumber", employee.PhoneNumber);
        //        parameters.Add("v_PhoneFix", employee.PhoneFix);
        //        parameters.Add("v_Email", employee.Email);
        //        parameters.Add("v_CreatedDate", employee.CreatedDate);
        //        parameters.Add("v_CreateBy", employee.CreateBy);
        //        parameters.Add("v_ModifiedDate", employee.ModifiedDate);
        //        parameters.Add("v_ModifiedBy", employee.ModifiedBy);
        //        parameters.Add("v_DepartmentId", employee.DepartmentId);

        //        //  khởi tạo kết nối vs DB
        //        string connectionString = "Server=localhost;Port=3306;Database=quanlynv;Uid=root;Pwd=952003;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        // Thực hiện câu lệnh SQL
        //        var insert = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //        // Xử lý kết quả trả về

        //        // Thành công
        //        if (insert > 0)
        //        {
        //            return StatusCode(200, "Insert Success");
        //        }
        //        else
        //        {
        //            return StatusCode(400, "Insert Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, new ErrorResult
        //        {
        //            ErrorCode = Enums.ErrorCode.DuplicateCode,
        //            DevMsg = Resource.DevMsg_Exception,
        //            UserMsg = Resource.UserMsg_Exception,
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public IActionResult UpdateEmployee(Guid ID, [FromBody] Employee employee)
        //{
        //    try
        //    {
        //        // cbi tên Stored
        //        string storedProcedureName = "Proc_employee_Update";

        //        // chuẩn bị tham số đầu vào 
        //        var parameters = new DynamicParameters();
        //        parameters.Add("v_EmployeeID", ID);
        //        parameters.Add("v_EmployeeCode", employee.EmployeeCode);
        //        parameters.Add("v_FullName", employee.FullName);
        //        parameters.Add("v_Gender", employee.Gender);
        //        parameters.Add("v_DateOfBirth", employee.DateOfBirth);
        //        parameters.Add("v_CMTND", employee.CMTND);
        //        parameters.Add("v_IssuedBy", employee.IssuedBy);
        //        parameters.Add("v_JobTitle", employee.JobTitle);
        //        parameters.Add("v_Address", employee.Address);
        //        parameters.Add("v_PhoneNumber", employee.PhoneNumber);
        //        parameters.Add("v_PhoneFix", employee.PhoneFix);
        //        parameters.Add("v_Email", employee.Email);
        //        parameters.Add("v_CreatedDate", employee.CreatedDate);
        //        parameters.Add("v_CreateBy", employee.CreateBy);
        //        parameters.Add("v_ModifiedDate", employee.ModifiedDate);
        //        parameters.Add("v_ModifiedBy", employee.ModifiedBy);
        //        parameters.Add("v_DepartmentId", employee.DepartmentId);

        //        //  khởi tạo kết nối vs DB
        //        string connectionString = "Server=localhost;Port=3306;Database=quanlynv;Uid=root;Pwd=952003;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        // Thực hiện câu lệnh SQL
        //        var update = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //        // Xử lý kết quả trả về

        //        // Thành công
        //        if (update > 0)
        //        {
        //            return StatusCode(200, "Update Success");
        //        }
        //        else
        //        {
        //            return StatusCode(400, "Update Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, new ErrorResult
        //        {
        //            ErrorCode = Enums.ErrorCode.DuplicateCode,
        //            DevMsg = Resource.DevMsg_Exception,
        //            UserMsg = Resource.UserMsg_Exception,
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="employeeId"></param>
        ///// <returns></returns>
        //[HttpDelete("{employeeId}")]
        //public IActionResult DeleteEmployee([FromRoute] Guid employeeId)
        //{
        //    try
        //    {
        //        // cbi tên Stored
        //        string storedProcedureName = "Proc_employee_Delete";

        //        // chuẩn bị tham số đầu vào 
        //        var parameters = new DynamicParameters();
        //        parameters.Add("v_EmployeeID", employeeId);

        //        //  khởi tạo kết nối vs DB
        //        string connectionString = "Server=localhost;Port=3306;Database=quanlynv;Uid=root;Pwd=952003;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        // Thực hiện câu lệnh SQL
        //        var delete = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //        Console.WriteLine($"Gia tri cua bien delete: {delete}");

        //        // Xử lý kết quả trả về

        //        // Thành công
        //        if (delete > 0)
        //        {
        //            return StatusCode(200, "Delete Success");
        //        }
        //        else
        //        {
        //            return StatusCode(400, "Delete Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, new ErrorResult
        //        {
        //            ErrorCode = Enums.ErrorCode.DuplicateCode,
        //            DevMsg = Resource.DevMsg_Exception,
        //            UserMsg = Resource.UserMsg_Exception,
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        ///// <summary>
        ///// Hàm filter lấy dữ liệu load 
        ///// thêm dấu ? để cho biết là không bắt buộc phải truyền dlieu vào và nó có thể null
        ///// </summary>
        ///// <param name="pageSize"></param>
        ///// <param name="pageNumber"></param>
        ///// <param name="keyword"></param>
        ///// <param name="departmantId"></param>
        ///// <param name="positionId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("employeeFilter")]
        //public IActionResult GetPaging(
        //    [FromQuery] string? keyword,
        //    [FromQuery] Guid? departmantId,
        //    [FromQuery] Guid? positionId,
        //    [FromQuery] int pageSize = 10,
        //    [FromQuery] int pageNumber = 1
        //    )
        //{
        //    return StatusCode(200, new PagingResult
        //    {
        //        //Data = new List<Employee>()
        //        //{
        //        //    new Employee{
        //        //    EmployeeID = Guid.NewGuid(),
        //        //    EmployeeCode = "NV01",
        //        //    EmployeeName = "Nguyen Ngoc Tan",
        //        //    Gender = Enums.Gender.Male,
        //        //    DateOfBirth = DateTime.Now,
        //        //    CreatedDate = DateTime.Now,
        //        //    CreatedBy = "admin",
        //        //    },
        //        //    new Employee{
        //        //    EmployeeID = Guid.NewGuid(),
        //        //    EmployeeCode = "NV02",
        //        //    EmployeeName = "Nguyen Thi B",
        //        //    Gender = Enums.Gender.Male,
        //        //    DateOfBirth = DateTime.Now,
        //        //    CreatedDate = DateTime.Now,
        //        //    CreatedBy = "admin",
        //        //    }
        //        //},
        //        //TotalReccord = 2
        //    });
        //}


    }
}

using B1.Demo.WebApplication.Common.Entities;
using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Enums;
using Dapper;
using Demo.WebApplication.BL.BaseBL;
using Demo.WebApplication.BL.EmployeeBL;
using Demo.WebApplication.Comon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;

namespace B1.Demo.WebApplication.API.Controllers
{
    public class EmployeesController : BasesController<Employee>
    {
        private IEmployeeBL _employeeBL;
        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

        [HttpGet("NewCode")]
        public IActionResult GetNewCode()
        {
            return StatusCode(200, _employeeBL.GetNewCode());
        }
    }
}

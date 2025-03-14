using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        [HttpGet("jsonresponse")]
        public IActionResult GetJsonResponse()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 101, Name = "John Doe", Email = "john@example.com", Department = Dept.IT },
                new Employee { Id = 102, Name = "Alice Smith", Email = "alice@example.com", Department = Dept.HR }
            };

            return Ok(employees); 
        }
    }
}

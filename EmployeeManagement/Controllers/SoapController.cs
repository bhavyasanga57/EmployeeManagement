using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoapController : ControllerBase
    {
        [HttpGet("soapresponse")]
        [Produces("application/xml")]
        public IActionResult GetSoapResponse()
        {
            var employee = new Employee
            {
                Id = 101,
                Name = "John Doe",
                Email = "john@example.com",
                Department = Dept.IT
            };

            var soapResponse = SerializeToSoap(employee);
            return Content(soapResponse, "application/xml");
        }

        private string SerializeToSoap<T>(T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}

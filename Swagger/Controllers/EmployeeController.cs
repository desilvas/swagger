using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ErrorMessage), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(500)]
        public IActionResult Add([FromBody] Employee employee)
        {

            if (ModelState.IsValid)
            {
                var message = new ErrorMessage
                {
                    Code = "200",
                    Message = "Successfully Created"
                };
                return Ok(message);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public ActionResult<List<Employee>> Get()
        {
            return GetEmployees();
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee { Age = 10 , Id =1 , Name = "Shalin" , Salary = 1000 },
                new Employee { Age = 20, Id = 2, Name = "Tom", Salary = 1000 },
                new Employee { Age = 30 , Id =3 , Name = "Peter" , Salary = 1000 },
                new Employee { Age = 40, Id = 4, Name = "Edgar", Salary = 1000 },
            };   
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public ActionResult<Employee> Get(int id)
        {
            var all = GetEmployees();
            var emp = all.Where(i => i.Id == id).SingleOrDefault();
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return NotFound();
            }              
        }   
    }
}

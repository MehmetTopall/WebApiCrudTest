using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Get All employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees); //200 + data
        }
        /// <summary>
        /// Get employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getemployeeById/{id}")] => api/user/getemployeeById/2
        public IActionResult Get(int id)
        {
            var employees = _employeeService.GetById(id);
            return Ok(employees); //200 + data
        }
        /// <summary>
        /// Create a employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _employeeService.Add(employee);
            return Ok("Ekleme işlemi başarılı...Eklenen çalışan: " + employee.Name); //201 + data

        }
        /// <summary>
        /// Update the employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (_employeeService.GetById(employee.EmployeeId) != null)
            {
                _employeeService.Update(employee);
                return Ok(employee.Name + " adlı çalışanın bilgileri başarılı bir şekilde güncellendi.");
            }
            return NotFound("Başarısız!!!!");

        }
        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeeService.GetById(id) != null)
            {
                _employeeService.Delete(id);
                return Ok("Kişi silme işlemi başarılı..");
            }
            return NotFound("Böyle bir çalışan bulunamadı!!!");

        }
    }
}

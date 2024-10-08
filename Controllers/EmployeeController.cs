﻿using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository emp;

        public EmployeeController(EmployeeRepository employeeRepository) //DI 
        {
            this.emp = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var allemployees = await emp.GetAllEmployee();
            return Ok(allemployees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee vm)
        {
            await emp.SaveEmployee(vm);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateEmployee(int id, Employee vm)
        {
            await emp.updateEmployee(id, vm);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEmployee(int id)
        {
            await emp.DeleteEmployee(id);
            return Ok();
        }
    }
}

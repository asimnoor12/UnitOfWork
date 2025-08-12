using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Data;
using UnitOfWork.DTOs.Department;
using UnitOfWork.DTOs.Employee;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Add Employeee..
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.CompleteAsync();

            return Ok("Employee created successfully.");
        }

        // GET All Employees..
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.GetEmployeesWithDepartmentAsync();
            var result = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department?.Name
            }).ToList();

            return Ok(result);
        }

        // GET by Id..
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employees = await _unitOfWork.Employees.GetEmployeesWithDepartmentAsync();
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null) return NotFound();

            var result = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department?.Name
            };

            return Ok(result);
        }

        // Update Employee..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound();

            employee.Name = dto.Name;
            employee.DepartmentId = dto.DepartmentId;

            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.CompleteAsync();

            return Ok("Employee updated successfully.");
        }

        // DELETE Employee..
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return NotFound();

            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.CompleteAsync();

            return Ok("Employee deleted successfully.");
        }

    }
}

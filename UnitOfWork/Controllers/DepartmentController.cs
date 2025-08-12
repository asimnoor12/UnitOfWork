using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Data.UoW;
using UnitOfWork.DTOs.Department;
using UnitOfWork.DTOs.Employee;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Add Department..
        [HttpPost]
        public async Task<IActionResult> AddDepartment(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
            };

            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.CompleteAsync();

            return Ok("Department created successfully.");
        }

        // GET all Departments..
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var employees = await _unitOfWork.Departments.GetAllAsync();
            return Ok(employees);
        }

        // Update Department..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto dto)
        {
            var employee = await _unitOfWork.Departments.GetByIdAsync(id);
            if (employee == null) return NotFound();

            employee.Name = dto.Name;

            _unitOfWork.Departments.Update(employee);
            await _unitOfWork.CompleteAsync();

            return Ok("Department updated successfully.");
        }

        // DELETE Department..
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var employee = await _unitOfWork.Departments.GetByIdAsync(id);
            if (employee == null) return NotFound();

            _unitOfWork.Departments.Delete(employee);
            await _unitOfWork.CompleteAsync();

            return Ok("Department deleted successfully.");
        }
    }
}

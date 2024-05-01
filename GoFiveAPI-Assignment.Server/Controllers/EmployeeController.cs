using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI_Dotnet8.Data;
using EmployeeAPI_Dotnet8.Entities;

namespace EmployeeAPI_Dotnet8.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        
        

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var employees = await _context.Employee.ToListAsync();
            var employeePermissions = await _context.Permissions.ToListAsync();
            var employeeRoles = await _context.Roles.ToListAsync();


            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employeeInfo = await _context.Employee.FindAsync(id);
            var employeePermissions = await _context.Permissions.FindAsync(id);
            var employeeRoles = await _context.Roles.FindAsync(id);

            if (employeeInfo == null)
            {
                return NotFound();
            }

            return Ok(new {
                data = employeeInfo
                //role1 = employeePermissions,
                //permissions1 = employeeRoles
            });
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbEmployee = await _context.Employee.FindAsync(employee.Id);
            if (dbEmployee != null)
            {
                return Conflict("There is already a user");
            }

            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }


        [HttpDelete]
        public async Task<ActionResult<Object>> DeleteEmployee(int id)
        {
            var employeeInfo = await _context.Employee.FindAsync(id);

            if (employeeInfo == null)
            {
                return await Task.FromResult(NotFound());
            }

            var employeePermissions = await _context.Permissions.FindAsync(id);
            var employeeRoles = await _context.Roles.FindAsync(id);


            _context.Permissions.Remove(employeePermissions);
            _context.Roles.Remove(employeeRoles);
            _context.Employee.Remove(employeeInfo);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                data = new { result = true,message = "Deleted" }
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Object>> UpdateHero(int id,[FromBody] Employee updateEmployee)
        {
            var dbEmployee = await _context.Employee.FindAsync(id);
            var dbRole = await _context.Roles.FindAsync(id);
            var dbPermission = await _context.Permissions.FindAsync(id);

            if (dbEmployee is null)
            {
                return BadRequest("User not found.");
            }

            dbEmployee.UserName = updateEmployee.UserName;
            dbEmployee.FirstName = updateEmployee.FirstName;
            dbEmployee.LastName = updateEmployee.LastName;
            dbEmployee.Email = updateEmployee.Email;
            dbEmployee.Phone = updateEmployee.Phone;

            dbRole.Name = updateEmployee.Role.Name;
            dbPermission.IsRead = updateEmployee.Permission.IsRead;
            dbPermission.IsWrite = updateEmployee.Permission.IsWrite;
            dbPermission.IsDeleted = updateEmployee.Permission.IsDeleted;




            await _context.SaveChangesAsync();

            return Ok(await _context.Employee.FindAsync(id));
        }
    }
}

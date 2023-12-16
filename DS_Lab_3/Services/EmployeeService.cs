using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class EmployeeService:IEmployeeService
{
    private readonly GymDsCopyContext _context;

    public EmployeeService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Employee CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee;
    }

    public Employee GetEmployeeById(int employeeId)
    {
        return _context.Employees.Find(employeeId);
    }

    public Employee UpdateEmployee(int employeeId, Employee updatedEmployee)
    {
        var existingEmployee = _context.Employees.Find(employeeId);

        if (existingEmployee != null)
        {
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Surname = updatedEmployee.Surname;
            existingEmployee.EmployeeEmail = updatedEmployee.EmployeeEmail;
            existingEmployee.HireDate = updatedEmployee.HireDate;
            existingEmployee.RoleId = updatedEmployee.RoleId;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingEmployee;
    }

    public void DeleteEmployee(int employeeId)
    {
        var employeeToDelete = _context.Employees.Find(employeeId);

        if (employeeToDelete != null)
        {
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employees;
    }
}
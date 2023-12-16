using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IEmployeeService
{
    Employee CreateEmployee(Employee employee);

    // Get an employee by their ID
    Employee GetEmployeeById(int employeeId);

    // Update an existing employee
    Employee UpdateEmployee(int employeeId, Employee updatedEmployee);

    // Delete an employee by their ID
    void DeleteEmployee(int employeeId);

    // Get a list of all employees
    IEnumerable<Employee> GetAllEmployees();
}
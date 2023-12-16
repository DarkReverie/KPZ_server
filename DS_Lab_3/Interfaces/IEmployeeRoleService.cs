using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IEmployeeRoleService
{
    EmployeeRole CreateEmployeeRole(EmployeeRole role);

    // Get an employee role by its ID
    EmployeeRole GetEmployeeRoleById(int roleId);

    // Update an existing employee role
    EmployeeRole UpdateEmployeeRole(int roleId, EmployeeRole updatedRole);

    // Delete an employee role by its ID
    void DeleteEmployeeRole(int roleId);

    // Get a list of all employee roles
    IEnumerable<EmployeeRole> GetAllEmployeeRoles();
}
using System.Data;
using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using MySqlConnector;

namespace DS_Lab_3.Services;

public class EmployeeRoleService:IEmployeeRoleService
{
    private readonly GymDsCopyContext _context;

    public EmployeeRoleService(GymDsCopyContext context)
    {
        _context = context;
    }

    public EmployeeRole CreateEmployeeRole(EmployeeRole role)
    {
        using (var connection = new MySqlConnection("Server=" +
                                                    "localhost;Port=3306;Database=" +
                                                    "gym_ds_copy;User=root;Password=1111;"))
        {
            connection.Open();
            using (var command = new MySqlCommand("AddEmployeeRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@roleNameParam", role.RoleName);
                command.ExecuteNonQuery();

                return role;
            }
        }
    }
    
    // // Use the stored procedure to add a new role
    // AddEmployeeRoleStoredProcedure(role.RoleName);
    //
    // // Assuming the EmployeeRoles table is still used for other operations, you can also add the role to the table
    // _context.EmployeeRoles.Add(role);
    // _context.SaveChanges();
    //

    public EmployeeRole GetEmployeeRoleById(int roleId)
    {
        return _context.EmployeeRoles.Find(roleId);
    }

    public EmployeeRole UpdateEmployeeRole(int roleId, EmployeeRole updatedRole)
    {
        var existingRole = _context.EmployeeRoles.Find(roleId);

        if (existingRole != null)
        {
            existingRole.RoleName = updatedRole.RoleName;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingRole;
    }

    public void DeleteEmployeeRole(int roleId)
    {
        var roleToDelete = _context.EmployeeRoles.Find(roleId);

        if (roleToDelete != null)
        {
            _context.EmployeeRoles.Remove(roleToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<EmployeeRole> GetAllEmployeeRoles()
    {
        return _context.EmployeeRoles;
    }
}

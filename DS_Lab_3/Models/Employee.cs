using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? EmployeeEmail { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? RoleId { get; set; }
}

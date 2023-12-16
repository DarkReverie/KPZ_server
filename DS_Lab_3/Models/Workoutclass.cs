using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Workoutclass
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Schedule { get; set; }

    public int? InstructorId { get; set; }
}

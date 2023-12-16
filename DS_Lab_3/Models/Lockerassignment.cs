using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Lockerassignment
{
    public int Id { get; set; }

    public int? LockerId { get; set; }

    public int? MemberId { get; set; }

    public DateOnly? AssignmentDate { get; set; }

    public DateOnly? DueDate { get; set; }
}

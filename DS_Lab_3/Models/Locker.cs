using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Locker
{
    public int Id { get; set; }

    public string? LockerNumber { get; set; }

    public bool? IsAvailable { get; set; }
}

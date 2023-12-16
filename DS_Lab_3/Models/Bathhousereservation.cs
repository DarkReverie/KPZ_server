using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Bathhousereservation
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? ReservationTime { get; set; }

    public int? MemberId { get; set; }

    public int? ReservedHours { get; set; }
    
}

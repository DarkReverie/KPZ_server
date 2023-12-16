using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Trainersession
{
    public int Id { get; set; }

    public int? TrainerId { get; set; }

    public int? MemberId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Duration { get; set; }
}

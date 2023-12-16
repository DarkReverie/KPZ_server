
namespace DS_Lab_3.Models;

public partial class Membership
{
    public int Id { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? MemberEmail { get; set; }

    public string? MemberPhone { get; set; }
}

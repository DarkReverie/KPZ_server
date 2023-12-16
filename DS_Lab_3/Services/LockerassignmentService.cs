using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class LockerassignmentService:ILockerassignmentService
{
    private readonly GymDsCopyContext _context;

    public LockerassignmentService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Lockerassignment CreateLockerAssignment(Lockerassignment assignment)
    {
        _context.Lockerassignments.Add(assignment);
        _context.SaveChanges();
        return assignment;
    }

    public Lockerassignment GetLockerAssignmentById(int assignmentId)
    {
        return _context.Lockerassignments.Find(assignmentId);
    }

    public Lockerassignment UpdateLockerAssignment(int assignmentId, Lockerassignment updatedAssignment)
    {
        var existingAssignment = _context.Lockerassignments.Find(assignmentId);

        if (existingAssignment != null)
        {
            existingAssignment.AssignmentDate = updatedAssignment.AssignmentDate;
            existingAssignment.DueDate = updatedAssignment.DueDate;
            existingAssignment.LockerId = updatedAssignment.LockerId;
            existingAssignment.MemberId = updatedAssignment.MemberId;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingAssignment;
    }

    public void DeleteLockerAssignment(int assignmentId)
    {
        var assignmentToDelete = _context.Lockerassignments.Find(assignmentId);

        if (assignmentToDelete != null)
        {
            _context.Lockerassignments.Remove(assignmentToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Lockerassignment> GetAllLockerAssignments()
    {
        return _context.Lockerassignments;
    }
}
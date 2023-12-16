using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface ILockerassignmentService
{
    Lockerassignment CreateLockerAssignment(Lockerassignment assignment);

    // Get a locker assignment by its ID
    Lockerassignment GetLockerAssignmentById(int assignmentId);

    // Update an existing locker assignment
    Lockerassignment UpdateLockerAssignment(int assignmentId, Lockerassignment updatedAssignment);

    // Delete a locker assignment by its ID
    void DeleteLockerAssignment(int assignmentId);

    // Get a list of all locker assignments
    IEnumerable<Lockerassignment> GetAllLockerAssignments();
}
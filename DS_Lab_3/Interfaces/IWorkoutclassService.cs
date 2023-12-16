using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IWorkoutclassService
{
    Workoutclass CreateWorkoutClass(Workoutclass workoutClass);

    // Get a workout class by its ID
    Workoutclass GetWorkoutClassById(int workoutClassId);

    // Update an existing workout class
    Workoutclass UpdateWorkoutClass(int workoutClassId, Workoutclass updatedWorkoutClass);

    // Delete a workout class by its ID
    void DeleteWorkoutClass(int workoutClassId);

    // Get a list of all workout classes
    IEnumerable<Workoutclass> GetAllWorkoutClasses();
}
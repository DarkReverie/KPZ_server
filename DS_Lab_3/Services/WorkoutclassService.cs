using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;


public class WorkoutclassService : IWorkoutclassService
{
    private readonly GymDsCopyContext _context;

    public WorkoutclassService(GymDsCopyContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Workoutclass CreateWorkoutClass(Workoutclass workoutClass)
    {
        _context.Workoutclasses.Add(workoutClass);
        _context.SaveChanges();
        return workoutClass;
    }

    public Workoutclass GetWorkoutClassById(int Id)
    {
        return _context.Workoutclasses.Find(Id);
    }

    public Workoutclass UpdateWorkoutClass(int Id, Workoutclass updatedWorkoutclass)
    {
        var existingWorkoutClass = _context.Workoutclasses.Find(Id);

        if (existingWorkoutClass != null)
        {
            existingWorkoutClass.Name = updatedWorkoutclass.Name;
            existingWorkoutClass.Description = updatedWorkoutclass.Description;
            existingWorkoutClass.InstructorId = updatedWorkoutclass.InstructorId;
            existingWorkoutClass.Schedule = updatedWorkoutclass.Schedule;

            _context.SaveChanges();
        }

        return existingWorkoutClass;
    }

    public void DeleteWorkoutClass(int workoutClassId)
    {
        var workoutClassToDelete = _context.Workoutclasses.Find(workoutClassId);

        if (workoutClassToDelete != null)
        {
            _context.Workoutclasses.Remove(workoutClassToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Workoutclass> GetAllWorkoutClasses()
    {
        return _context.Workoutclasses.ToList();
    }
}
using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class LockerService:ILockerService
{
    private readonly GymDsCopyContext _context;

    public LockerService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Locker CreateLocker(Locker locker)
    {
        _context.Lockers.Add(locker);
        _context.SaveChanges();
        return locker;
    }

    public Locker GetLockerById(int lockerId)
    {
        return _context.Lockers.Find(lockerId);
    }

    public Locker UpdateLocker(int lockerId, Locker updatedLocker)
    {
        var existingLocker = _context.Lockers.Find(lockerId);

        if (existingLocker != null)
        {
            existingLocker.LockerNumber = updatedLocker.LockerNumber;
            existingLocker.IsAvailable = updatedLocker.IsAvailable;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingLocker;
    }

    public void DeleteLocker(int lockerId)
    {
        var lockerToDelete = _context.Lockers.Find(lockerId);

        if (lockerToDelete != null)
        {
            _context.Lockers.Remove(lockerToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Locker> GetAllLockers()
    {
        return _context.Lockers;
    }
}
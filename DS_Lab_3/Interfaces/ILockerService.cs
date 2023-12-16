using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface ILockerService
{
    Locker CreateLocker(Locker locker);

    // Get a locker by its ID
    Locker GetLockerById(int lockerId);

    // Update an existing locker
    Locker UpdateLocker(int lockerId, Locker updatedLocker);

    // Delete a locker by its ID
    void DeleteLocker(int lockerId);

    // Get a list of all lockers
    IEnumerable<Locker> GetAllLockers();
}
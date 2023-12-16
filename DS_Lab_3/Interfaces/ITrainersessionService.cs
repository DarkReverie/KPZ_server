using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface ITrainersessionService
{
    Trainersession CreateTrainerSession(Trainersession session);

    // Get a trainer session by its ID
    Trainersession GetTrainerSessionById(int sessionId);

    // Update an existing trainer session
    Trainersession UpdateTrainerSession(int sessionId, Trainersession updatedSession);

    // Delete a trainer session by its ID
    void DeleteTrainerSession(int sessionId);

    // Get a list of all trainer sessions
    IEnumerable<Trainersession> GetAllTrainerSessions();
}
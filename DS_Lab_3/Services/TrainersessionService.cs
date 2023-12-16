using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class TrainersessionService:ITrainersessionService
{
    private readonly GymDsCopyContext _context;

    public TrainersessionService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Trainersession CreateTrainerSession(Trainersession session)
    {
        _context.Trainersessions.Add(session);
        _context.SaveChanges();
        return session;
    }

    public Trainersession GetTrainerSessionById(int sessionId)
    {
        return _context.Trainersessions.Find(sessionId);
    }

    public Trainersession UpdateTrainerSession(int sessionId, Trainersession updatedSession)
    {
        var existingSession = _context.Trainersessions.Find(sessionId);

        if (existingSession != null)
        {
            existingSession.Date = updatedSession.Date;
            existingSession.Duration = updatedSession.Duration;
            existingSession.MemberId = updatedSession.MemberId;
            existingSession.TrainerId = updatedSession.TrainerId;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingSession;
    }

    public void DeleteTrainerSession(int sessionId)
    {
        var sessionToDelete = _context.Trainersessions.Find(sessionId);

        if (sessionToDelete != null)
        {
            _context.Trainersessions.Remove(sessionToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Trainersession> GetAllTrainerSessions()
    {
        return _context.Trainersessions;
    }
}
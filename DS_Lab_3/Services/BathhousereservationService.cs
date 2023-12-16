using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class BathhousereservationService:IBathhousereservationService
{
    private readonly GymDsCopyContext _context;

    public BathhousereservationService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Bathhousereservation CreateReservation(Bathhousereservation reservation)
    {
        _context.Bathhousereservations.Add(reservation);
        _context.SaveChanges();
        return reservation;
    }

    public Bathhousereservation GetReservationById(int reservationId)
    {
        return _context.Bathhousereservations.Find(reservationId);
    }

    public Bathhousereservation UpdateReservation(int reservationId, Bathhousereservation updatedReservation)
    {
        var existingReservation = _context.Bathhousereservations.Find(reservationId);

        if (existingReservation != null)
        {
            existingReservation.Date = updatedReservation.Date;
            existingReservation.ReservationTime = updatedReservation.ReservationTime;
            existingReservation.MemberId = updatedReservation.MemberId;
            existingReservation.ReservedHours = updatedReservation.ReservedHours;
  
            _context.SaveChanges();
        }

        return existingReservation;
    }

    public void DeleteReservation(int reservationId)
    {
        var reservationToDelete = _context.Bathhousereservations.Find(reservationId);

        if (reservationToDelete != null)
        {
            _context.Bathhousereservations.Remove(reservationToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Bathhousereservation> GetAllReservations()
    {
        return _context.Bathhousereservations;
    }
}

using Azure;
using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IBathhousereservationService
{
    // Create a new bathhouse reservation
    Bathhousereservation CreateReservation(Bathhousereservation reservation);

    // Get a bathhouse reservation by its ID
    Bathhousereservation GetReservationById(int reservationId);

    // Update an existing bathhouse reservation
    Bathhousereservation UpdateReservation(int reservationId, Bathhousereservation updatedReservation);

    // Delete a bathhouse reservation by its ID
    void DeleteReservation(int reservationId);

    // Get a list of all bathhouse reservations
    IEnumerable<Bathhousereservation> GetAllReservations();
}
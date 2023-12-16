using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IPaymentService
{
    Payment CreatePayment(Payment payment);

    // Get a membership by its ID
    Payment GetPaymentById(int paymentId);

    // Update an existing membership
    Payment UpdatePayment(int paymentId,  Payment updatePayment);

    // Delete a membership by its ID
    void DeletePayment(int paymentId);

    // Get a list of all memberships
    IEnumerable<Payment> GetAllPayments();
}
using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class PaymentService:IPaymentService
{
    private readonly GymDsCopyContext _context;

    public PaymentService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Payment CreatePayment(Payment payment)
    {
        _context.Payments.Add(payment);
        _context.SaveChanges();
        return payment;
    }

    public Payment GetPaymentById(int paymentId)
    {
        return _context.Payments.Find(paymentId);
    }

    public Payment UpdatePayment(int paymentId, Payment updatedPayment)
    {
        var existingPayment = _context.Payments.Find(paymentId);

        if (existingPayment != null)
        {
            existingPayment.InvoiceId = updatedPayment.InvoiceId;
            existingPayment.MemberId = updatedPayment.MemberId;
            existingPayment.PaymentAmount = updatedPayment.PaymentAmount;
            existingPayment.PaymentDate = updatedPayment.PaymentDate;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingPayment;
    }

    public void DeletePayment(int paymentId)
    {
        var paymentToDelete = _context.Payments.Find(paymentId);

        if (paymentToDelete != null)
        {
            _context.Payments.Remove(paymentToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Payment> GetAllPayments()
    {
        return _context.Payments;
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        void AddPayment(Payment payment);
        void DeletePayment(int PaymentId);
        Task<Payment> FindPayment(int id);
    }
}
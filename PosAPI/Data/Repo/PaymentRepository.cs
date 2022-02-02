using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext dc;
        public PaymentRepository(DataContext dc)
        { 
            this.dc = dc;
        }

        public void AddPayment(Payment payment)
        {
            dc.Payments.Add(payment);
        }

        public void DeletePayment(int PaymentId)
        {
            var payment = dc.Payments.Find(PaymentId);
            dc.Payments.Remove(payment);
        }

        public async Task<Payment> FindPayment(int id)
        {
            return await dc.Payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await dc.Payments.ToListAsync();
        }
    }
}
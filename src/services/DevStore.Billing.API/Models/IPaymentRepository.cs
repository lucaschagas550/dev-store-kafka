using DevStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevStore.Billing.API.Models
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void AddPayment(Payment payment);
        void AddTransaction(Transaction transaction);
        Task<Payment> GetPaymentByOrderId(Guid orderId);
        Task<IEnumerable<Transaction>> GetTransactionsByOrderId(Guid orderId);
    }
}
using DevStore.Billing.API.Models;
using DevStore.Core.Messages.Integration;
using System;
using System.Threading.Tasks;

namespace DevStore.Billing.API.Services
{
    public interface IBillingService
    {
        Task<ResponseMessage> AuthorizeTransaction(Payment payment);
        Task<ResponseMessage> GetTransaction(Guid orderId);
        Task<ResponseMessage> CancelTransaction(Guid orderId);
    }
}
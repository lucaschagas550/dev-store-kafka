using DevStore.Core.Http;
using DevStore.Core.Mediator;
using DevStore.Core.Messages.Integration;
using DevStore.Orders.API.Application.Queries;
using DevStore.Orders.Domain.Orders;
using DevStore.Orders.Domain.Vouchers;
using DevStore.Orders.Infra.Context;
using DevStore.Orders.Infra.Repository;
using DevStore.WebAPI.Core.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevStore.Orders.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Kafka request
            services.AddSingleton<IRestClient, RestClient>();

            //Url para dar inicio a um novo pedido de compra, requisicao para payment
            services.AddHttpClient(nameof(OrderInitiatedIntegrationEvent), options =>
            {
                options.BaseAddress = new System.Uri("https://localhost:5461/payment/order-initiated");
            });
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IOrderQueries, OrderQueries>();

            // Date
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<OrdersContext>();
        }
    }
}
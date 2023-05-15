using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaxPayers.Domain.Common;
using TaxPayers.Domain.Common.Interfaces;

namespace TaxPayers.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}

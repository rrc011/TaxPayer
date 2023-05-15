using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxPayer.Commands
{
    public class TaxPayerCreatedEvent : BaseEvent
    {
        public Domain.Entities.TaxPayer TaxPayer { get; }

        public TaxPayerCreatedEvent(Domain.Entities.TaxPayer taxPayer)
        {
            TaxPayer = taxPayer;
        }
    }
}

using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxPayer
{
    public class TaxPayerUpdatedEvent : BaseEvent
    {
        public Domain.Entities.TaxPayer TaxPayer { get; }

        public TaxPayerUpdatedEvent(Domain.Entities.TaxPayer taxPayer)
        {
            TaxPayer = taxPayer;
        }
    }
}

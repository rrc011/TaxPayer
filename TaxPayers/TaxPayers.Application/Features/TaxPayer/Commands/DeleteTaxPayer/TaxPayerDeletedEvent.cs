using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxPayer
{
    public class TaxPayerDeletedEvent : BaseEvent
    {
        public Domain.Entities.TaxPayer TaxPayer { get; }

        public TaxPayerDeletedEvent(Domain.Entities.TaxPayer taxPayer)
        {
            TaxPayer = taxPayer;
        }
    }
}

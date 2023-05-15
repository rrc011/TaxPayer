using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxReceipt.Commands
{
    public class CreateTaxReceiptEvent : BaseEvent
    {
        public Domain.Entities.TaxReceipt TaxReceipt { get; }

        public CreateTaxReceiptEvent(Domain.Entities.TaxReceipt tax)
        {
            TaxReceipt = tax;
        }
    }
}

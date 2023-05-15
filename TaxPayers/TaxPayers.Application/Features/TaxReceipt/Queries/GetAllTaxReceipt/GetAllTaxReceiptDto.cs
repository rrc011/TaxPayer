using TaxPayers.Application.Features.TaxPayer;
using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxReceipt.Queries
{
    public class GetAllTaxReceiptDto : BaseEntity, IMapFrom<Domain.Entities.TaxReceipt>
    {
        public int TaxPayerId { get; set; }
        public string NCF { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public GetTaxPayersWithPaginationDto TaxPayer { get; set; }
    }
}

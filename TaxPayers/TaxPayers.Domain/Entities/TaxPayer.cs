using TaxPayers.Domain.Common;
using TaxPayers.Domain.Common.Enums;

namespace TaxPayers.Domain.Entities
{
    public class TaxPayer : BaseAuditableEntity
    {
        public string RNC { get; set; }
        public string Name { get; set; }
        public TaxPayerType Type { get; set; }
        public TaxPayerStatus Status { get; set; }
        public virtual IEnumerable<TaxReceipt> TaxReceipts { get; set; }
    }
}

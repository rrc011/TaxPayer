using System.ComponentModel.DataAnnotations.Schema;
using TaxPayers.Domain.Common;

namespace TaxPayers.Domain.Entities
{
    public class TaxReceipt : BaseAuditableEntity
    {
        [ForeignKey("TaxPayer")]
        public int TaxPayerId { get; set; }
        public string NCF { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public virtual TaxPayer TaxPayer { get; set; }
    }
}

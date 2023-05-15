using TaxPayers.Domain.Common;

namespace TaxPayers.Application.Features.TaxPayer.Queries
{
    public class GetTaxPayersWithPaginationDto 
    {
        public string RNC { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string TypeDescription { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
    }
}

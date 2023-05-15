using System.ComponentModel;

namespace TaxPayers.Domain.Common.Enums
{
    public enum TaxPayerStatus
    {
        [Description("Activo")]
        Active = 1,

        [Description("Inactivo")]
        Inactive
    }
}

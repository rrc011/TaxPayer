using System.ComponentModel;

namespace TaxPayers.Domain.Common.Enums
{
    public enum TaxPayerType
    {
        [Description("Persona Fisica")]
        PhysicalPerson = 1,

        [Description("Persona Jurídica")]
        LegalPersons
    }
}

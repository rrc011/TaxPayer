using FluentValidation;

namespace TaxPayers.Application.Features.TaxReceipt.Queries
{
    public class GetAllTaxReceiptValidator : AbstractValidator<GetAllTaxReceiptQuery>
    {
        public GetAllTaxReceiptValidator()
        {
            RuleFor(x => x.TaxPayerId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("TaxPayerId at least greater than or equal to 1.");
        }
    }
}

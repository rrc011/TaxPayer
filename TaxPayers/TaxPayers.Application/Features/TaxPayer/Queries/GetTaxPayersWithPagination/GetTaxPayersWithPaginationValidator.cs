﻿using FluentValidation;

namespace TaxPayers.Application.Features.TaxPayer
{
    public class GetTaxPayersWithPaginationValidator : AbstractValidator<GetTaxPayersWithPaginationQuery>
    {
        public GetTaxPayersWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}

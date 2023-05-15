using AutoMapper.QueryableExtensions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxReceipt.Queries
{
    public class GetAllTaxReceiptQuery : IRequest<Result<List<GetAllTaxReceiptDto>>>
    {
        public int TaxPayerId { get; set; }
    }

    internal class GetTaxReceiptWithPaginationQueryHandler : IRequestHandler<GetAllTaxReceiptQuery, Result<List<GetAllTaxReceiptDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaxReceiptWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllTaxReceiptDto>>> Handle(GetAllTaxReceiptQuery query, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Domain.Entities.TaxReceipt>().Entities
                   .Where(x => x.TaxPayerId == query.TaxPayerId)
                   .Include(x => x.TaxPayer)
                   .OrderByDescending(x => x.CreatedDate)
                   .ProjectTo<GetAllTaxReceiptDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllTaxReceiptDto>>.SuccessAsync(result);
        }
    }
}

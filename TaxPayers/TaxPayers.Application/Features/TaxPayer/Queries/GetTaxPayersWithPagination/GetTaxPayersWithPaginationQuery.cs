using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TaxPayers.Application.Extensions;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxPayer.Queries
{
    public record GetTaxPayersWithPaginationQuery : IRequest<PaginatedResult<GetTaxPayersWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetTaxPayersWithPaginationQuery() { }

        public GetTaxPayersWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    internal class GetTaxPayersWithPaginationQueryHandler : IRequestHandler<GetTaxPayersWithPaginationQuery, PaginatedResult<GetTaxPayersWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaxPayersWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetTaxPayersWithPaginationDto>> Handle(GetTaxPayersWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Domain.Entities.TaxPayer>().Entities
                   .OrderByDescending(x => x.CreatedDate)
                   .ProjectTo<GetTaxPayersWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}

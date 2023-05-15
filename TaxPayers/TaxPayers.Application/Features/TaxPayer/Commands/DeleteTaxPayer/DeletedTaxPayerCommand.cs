using AutoMapper;
using MediatR;
using TaxPayers.Domain.Common;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxPayer.Commands.DeleteTaxPayer
{
    public class DeletedTaxPayerCommand : BaseEntity, IRequest<Result<int>>, IMapFrom<Domain.Entities.TaxPayer>
    {

    }

    internal class DeletedTaxPayerCommandHandler : IRequestHandler<DeletedTaxPayerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletedTaxPayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeletedTaxPayerCommand request, CancellationToken cancellationToken)
        {
            var payer = await _unitOfWork.Repository<Domain.Entities.TaxPayer>().GetByIdAsync(request.Id);

            if (payer != null)
            {
                await _unitOfWork.Repository<Domain.Entities.TaxPayer>().DeleteAsync(payer);
                payer.AddDomainEvent(new TaxPayerUpdatedEvent(payer));

                await _unitOfWork.SaveAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payer.Id, "Tax Payer Deleted.");
            }

            return await Result<int>.FailureAsync("Tax Payer Not Found.");
        }
    }
}

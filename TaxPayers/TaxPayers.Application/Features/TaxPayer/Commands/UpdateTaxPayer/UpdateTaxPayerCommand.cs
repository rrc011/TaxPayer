using AutoMapper;
using MediatR;
using TaxPayers.Domain.Common;
using TaxPayers.Domain.Common.Enums;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxPayer.Commands.UpdateTaxPayer
{
    public class UpdateTaxPayerCommand : BaseEntity, IRequest<Result<int>>, IMapFrom<Domain.Entities.TaxPayer>
    {
        public string Name { get; set; }
        public TaxPayerType Type { get; set; }
        public TaxPayerStatus Status { get; set; }
    }

    internal class UpdateTaxPayerCommandHandler : IRequestHandler<UpdateTaxPayerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public UpdateTaxPayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateTaxPayerCommand request, CancellationToken cancellationToken)
        {
            var payer = await _unitOfWork.Repository<Domain.Entities.TaxPayer>().GetByIdAsync(request.Id);

            if (payer != null)
            {
                payer.Name = request.Name;
                payer.Type = request.Type;
                payer.Status = request.Status;

                await _unitOfWork.Repository<Domain.Entities.TaxPayer>().UpdateAsync(payer);
                payer.AddDomainEvent(new TaxPayerUpdatedEvent(payer));

                await _unitOfWork.SaveAsync(cancellationToken);

                return await Result<int>.SuccessAsync(payer.Id, "Tax Payer Updated.");
            }

            return await Result<int>.FailureAsync("Tax Payer Not Found.");
        }
    }
}

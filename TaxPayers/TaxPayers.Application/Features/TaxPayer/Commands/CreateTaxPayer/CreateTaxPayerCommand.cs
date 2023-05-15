using AutoMapper;
using MediatR;
using TaxPayers.Domain.Common.Enums;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxPayer
{
    public record CreateTaxPayerCommand : IRequest<Result<int>>, IMapFrom<Domain.Entities.TaxPayer>
    {
        public string RNC { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }

    internal class CreatePlayerCommandHandler : IRequestHandler<CreateTaxPayerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTaxPayerCommand command, CancellationToken cancellationToken)
        {
            var payer = new Domain.Entities.TaxPayer()
            {
                Name = command.Name,
                Type = (TaxPayerType)command.Type,
                Status = (TaxPayerStatus)command.Status,
                RNC = command.RNC,
            };

            await _unitOfWork.Repository<Domain.Entities.TaxPayer>().AddAsync(payer);
            payer.AddDomainEvent(new TaxPayerCreatedEvent(payer));
            await _unitOfWork.SaveAsync(cancellationToken);
            return await Result<int>.SuccessAsync(payer.Id, "Tax Payer Created.");
        }
    }
}

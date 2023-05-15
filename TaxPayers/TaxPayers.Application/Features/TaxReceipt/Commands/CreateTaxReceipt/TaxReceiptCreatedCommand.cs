using AutoMapper;
using MediatR;
using TaxPayers.Shared;

namespace TaxPayers.Application.Features.TaxReceipt.Commands
{
    public class TaxReceiptCreatedCommand : IRequest<Result<int>>, IMapFrom<Domain.Entities.TaxReceipt>
    {
        public int TaxPayerId { get; set; }
        public string NCF { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
    }

    internal class TaxReceiptCreatedCommandHandler : IRequestHandler<TaxReceiptCreatedCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaxReceiptCreatedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(TaxReceiptCreatedCommand request, CancellationToken cancellationToken)
        {
            var tax = new Domain.Entities.TaxReceipt()
            {
                Amount = request.Amount,
                Tax = request.Amount * 0.18M,
                NCF = request.NCF,
                TaxPayerId = request.TaxPayerId
            };

            await _unitOfWork.Repository<Domain.Entities.TaxReceipt>().AddAsync(tax);
            tax.AddDomainEvent(new CreateTaxReceiptEvent(tax));
            await _unitOfWork.SaveAsync(cancellationToken);
            return await Result<int>.SuccessAsync(tax.Id, "Tax Receipt Created.");
        }
    }
}

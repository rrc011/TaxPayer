using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxPayers.Application.Features.TaxReceipt.Commands;
using TaxPayers.Application.Features.TaxReceipt.Queries;
using TaxPayers.Shared;

namespace TaxPayers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllTaxReceiptDto>>>> GetPlayersWithPagination([FromQuery] GetAllTaxReceiptQuery query)
        {
            var validator = new GetAllTaxReceiptValidator();

            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(TaxReceiptCreatedCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}

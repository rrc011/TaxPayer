using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxPayers.Application.Features.TaxPayer;
using TaxPayers.Shared;

namespace TaxPayers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxPayerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxPayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<GetTaxPayersWithPaginationDto>>> GetPlayersWithPagination([FromQuery] GetTaxPayersWithPaginationQuery query)
        {
            var validator = new GetTaxPayersWithPaginationValidator();

            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateTaxPayerCommand command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpPut]
        public async Task<ActionResult<Result<int>>> Update(UpdateTaxPayerCommand command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpDelete]
        public async Task<ActionResult<Result<int>>> Delete(DeletedTaxPayerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}

using Moq;
using TaxPayers.WebAPI.Controllers;
using MediatR;
using TaxPayers.Application.Features.TaxPayer.Queries;
using TaxPayers.Shared;
using TaxPayers.Application.Features.TaxPayer.Commands;
using TaxPayers.Application.Features.TaxPayer.Commands.UpdateTaxPayer;
using TaxPayers.Domain.Common.Enums;
using TaxPayers.Application.Features.TaxPayer.Commands.DeleteTaxPayer;

namespace TaxPayer.Test.Controllers
{
    public class TaxPayerControllerTest
    {
        private TaxPayerController _controller;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TaxPayerController(_mediatorMock.Object);
        }

        [Test]
        public async Task TaxPayerControllerTest_GetPlayersWithPagination()
        {
            // Arrange
            var query = new GetTaxPayersWithPaginationQuery
            {
                PageNumber = 1,
                PageSize = 10,
            };

            var expectedResponse = new PaginatedResult<GetTaxPayersWithPaginationDto>()
            {
                Data = new List<GetTaxPayersWithPaginationDto>
                {
                    new GetTaxPayersWithPaginationDto {}
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetTaxPayersWithPaginationQuery>(), 
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetPlayersWithPagination(query);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }

        [Test]
        public async Task TaxPayerControllerTest_Create()
        {
            // Arrange
            var input = new CreateTaxPayerCommand
            {
                Name = "name",
                RNC = "234523623456",
                Status = 1,
                Type = 1
            };

            var expectedResponse = new Result<int>();
            expectedResponse.Data = 1;

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateTaxPayerCommand>(),
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(input);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }

        [Test]
        public async Task TaxPayerControllerTest_Update()
        {
            // Arrange
            var input = new UpdateTaxPayerCommand
            {
                Name = "name",
                Status = (TaxPayerStatus)1,
                Type = (TaxPayerType)1,
                Id = 1
            };

            var expectedResponse = new Result<int>();
            expectedResponse.Data = 1;

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateTaxPayerCommand>(),
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Update(input);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }

        [Test]
        public async Task TaxPayerControllerTest_Delete()
        {
            // Arrange
            var input = new DeletedTaxPayerCommand
            {
                Id = 1,
            };

            var expectedResponse = new Result<int>();
            expectedResponse.Data = 1;

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeletedTaxPayerCommand>(),
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Delete(input);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }
    }
}

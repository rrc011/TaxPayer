using MediatR;
using Moq;
using TaxPayers.Application.Features.TaxReceipt.Commands;
using TaxPayers.Application.Features.TaxReceipt.Queries;
using TaxPayers.Shared;
using TaxPayers.WebAPI.Controllers;

namespace TaxPayer.Test.Controllers
{
    public class TaxReceiptControllerTest
    {
        private TaxReceiptController _controller;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TaxReceiptController(_mediatorMock.Object);
        }

        [Test]
        public async Task TaxReceiptController_GetTaxReceipt()
        {
            // Arrange
            var query = new GetAllTaxReceiptQuery
            {
                TaxPayerId = 3
            };

            var expectedResponse = new Result<List<GetAllTaxReceiptDto>>()
            {
                Data = new List<GetAllTaxReceiptDto>
                {
                    new GetAllTaxReceiptDto {}
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllTaxReceiptQuery>(),
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetTaxReceipt(query);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }

        [Test]
        public async Task TaxReceiptController_Create()
        {
            // Arrange
            var input = new TaxReceiptCreatedCommand
            {
                TaxPayerId = 3,
                Amount = 5000,
                NCF = "E42354235",
                Tax = 5000 * 0.18M
            };

            var expectedResponse = new Result<int>();
            expectedResponse.Data = 1;

            _mediatorMock.Setup(m => m.Send(It.IsAny<TaxReceiptCreatedCommand>(),
                                            It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Create(input);

            // Assert
            Assert.IsNotNull(result.Value.Data);
        }
    }
}

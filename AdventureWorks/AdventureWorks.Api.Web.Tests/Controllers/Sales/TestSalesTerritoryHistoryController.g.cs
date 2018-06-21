using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesTerritoryHistory")]
        [Trait("Area", "Controllers")]
        public partial class SalesTerritoryHistoryControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        var record = new ApiSalesTerritoryHistoryResponseModel();
                        var records = new List<ApiSalesTerritoryHistoryResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesTerritoryHistoryResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesTerritoryHistoryResponseModel>>(new List<ApiSalesTerritoryHistoryResponseModel>()));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesTerritoryHistoryResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTerritoryHistoryResponseModel()));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiSalesTerritoryHistoryResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTerritoryHistoryResponseModel>(null));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesTerritoryHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(mockResponse));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesTerritoryHistoryRequestModel>();
                        records.Add(new ApiSalesTerritoryHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiSalesTerritoryHistoryResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(mockResponse.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesTerritoryHistoryRequestModel>();
                        records.Add(new ApiSalesTerritoryHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesTerritoryHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(mockResponse));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesTerritoryHistoryRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiSalesTerritoryHistoryResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiSalesTerritoryHistoryResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryHistoryResponseModel>>(mockResponse.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesTerritoryHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesTerritoryHistoryRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesTerritoryHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        SalesTerritoryHistoryControllerMockFacade mock = new SalesTerritoryHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesTerritoryHistoryController controller = new SalesTerritoryHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class SalesTerritoryHistoryControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<SalesTerritoryHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<SalesTerritoryHistoryController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ISalesTerritoryHistoryService> ServiceMock { get; set; } = new Mock<ISalesTerritoryHistoryService>();
        }
}

/*<Codenesium>
    <Hash>243959ef367341205adeb46dd70bd338</Hash>
</Codenesium>*/
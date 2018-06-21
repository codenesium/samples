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
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "Controllers")]
        public partial class PurchaseOrderDetailControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        var record = new ApiPurchaseOrderDetailResponseModel();
                        var records = new List<ApiPurchaseOrderDetailResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderDetailResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPurchaseOrderDetailResponseModel>>(new List<ApiPurchaseOrderDetailResponseModel>()));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderDetailResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderDetailResponseModel()));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiPurchaseOrderDetailResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderDetailResponseModel>(null));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPurchaseOrderDetailResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(mockResponse));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPurchaseOrderDetailRequestModel>();
                        records.Add(new ApiPurchaseOrderDetailRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiPurchaseOrderDetailResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(mockResponse.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPurchaseOrderDetailRequestModel>();
                        records.Add(new ApiPurchaseOrderDetailRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPurchaseOrderDetailResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(mockResponse));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPurchaseOrderDetailRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiPurchaseOrderDetailResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiPurchaseOrderDetailResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderDetailResponseModel>>(mockResponse.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPurchaseOrderDetailRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderDetailRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderDetailRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        PurchaseOrderDetailControllerMockFacade mock = new PurchaseOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PurchaseOrderDetailController controller = new PurchaseOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class PurchaseOrderDetailControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<PurchaseOrderDetailController>> LoggerMock { get; set; } = new Mock<ILogger<PurchaseOrderDetailController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IPurchaseOrderDetailService> ServiceMock { get; set; } = new Mock<IPurchaseOrderDetailService>();
        }
}

/*<Codenesium>
    <Hash>d22d11ed06d0e6f11c2683046eb16abd</Hash>
</Codenesium>*/
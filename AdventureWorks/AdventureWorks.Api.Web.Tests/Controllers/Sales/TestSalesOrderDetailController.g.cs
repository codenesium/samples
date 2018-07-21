using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [Trait("Table", "SalesOrderDetail")]
        [Trait("Area", "Controllers")]
        public partial class SalesOrderDetailControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var record = new ApiSalesOrderDetailResponseModel();
                        var records = new List<ApiSalesOrderDetailResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesOrderDetailResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesOrderDetailResponseModel>>(new List<ApiSalesOrderDetailResponseModel>()));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesOrderDetailResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderDetailResponseModel()));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiSalesOrderDetailResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderDetailResponseModel>(null));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesOrderDetailResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesOrderDetailResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderDetailResponseModel>>(mockResponse));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesOrderDetailRequestModel>();
                        records.Add(new ApiSalesOrderDetailRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiSalesOrderDetailResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesOrderDetailResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderDetailResponseModel>>(mockResponse.Object));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesOrderDetailRequestModel>();
                        records.Add(new ApiSalesOrderDetailRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesOrderDetailResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesOrderDetailResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderDetailResponseModel>>(mockResponse));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesOrderDetailRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesOrderDetailResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesOrderDetailResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiSalesOrderDetailResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderDetailResponseModel>>(mockResponse.Object));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesOrderDetailRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderDetailResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>()))
                        .Callback<int, ApiSalesOrderDetailRequestModel>(
                                (id, model) => model.CarrierTrackingNumber.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiSalesOrderDetailResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderDetailResponseModel>(new ApiSalesOrderDetailResponseModel()));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderDetailModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSalesOrderDetailRequestModel>();
                        patch.Replace(x => x.CarrierTrackingNumber, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderDetailResponseModel>(null));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSalesOrderDetailRequestModel>();
                        patch.Replace(x => x.CarrierTrackingNumber, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderDetailResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderDetailResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderDetailResponseModel()));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderDetailModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderDetailRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderDetailResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderDetailResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderDetailResponseModel()));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderDetailModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderDetailRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderDetailResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderDetailResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderDetailResponseModel>(null));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderDetailModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderDetailRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SalesOrderDetailControllerMockFacade mock = new SalesOrderDetailControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesOrderDetailController controller = new SalesOrderDetailController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class SalesOrderDetailControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<SalesOrderDetailController>> LoggerMock { get; set; } = new Mock<ILogger<SalesOrderDetailController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ISalesOrderDetailService> ServiceMock { get; set; } = new Mock<ISalesOrderDetailService>();

                public Mock<IApiSalesOrderDetailModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesOrderDetailModelMapper>();
        }
}

/*<Codenesium>
    <Hash>1bbc589a05c96cb503c00d3ea79f2725</Hash>
</Codenesium>*/
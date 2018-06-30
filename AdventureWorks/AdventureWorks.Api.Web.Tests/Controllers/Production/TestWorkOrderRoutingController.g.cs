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
        [Trait("Table", "WorkOrderRouting")]
        [Trait("Area", "Controllers")]
        public partial class WorkOrderRoutingControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var record = new ApiWorkOrderRoutingResponseModel();
                        var records = new List<ApiWorkOrderRoutingResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkOrderRoutingResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiWorkOrderRoutingResponseModel>>(new List<ApiWorkOrderRoutingResponseModel>()));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkOrderRoutingResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderRoutingResponseModel()));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiWorkOrderRoutingResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderRoutingResponseModel>(null));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkOrderRoutingResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkOrderRoutingResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderRoutingResponseModel>>(mockResponse));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkOrderRoutingRequestModel>();
                        records.Add(new ApiWorkOrderRoutingRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiWorkOrderRoutingResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkOrderRoutingResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderRoutingResponseModel>>(mockResponse.Object));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkOrderRoutingRequestModel>();
                        records.Add(new ApiWorkOrderRoutingRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkOrderRoutingResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkOrderRoutingResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderRoutingResponseModel>>(mockResponse));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkOrderRoutingRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiWorkOrderRoutingResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkOrderRoutingResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiWorkOrderRoutingResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderRoutingResponseModel>>(mockResponse.Object));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkOrderRoutingRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>()))
                        .Callback<int, ApiWorkOrderRoutingRequestModel>(
                                (id, model) => model.ActualCost.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderRoutingResponseModel>(new ApiWorkOrderRoutingResponseModel()));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderRoutingModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkOrderRoutingRequestModel>();
                        patch.Replace(x => x.ActualCost, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderRoutingResponseModel>(null));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkOrderRoutingRequestModel>();
                        patch.Replace(x => x.ActualCost, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderRoutingResponseModel()));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderRoutingModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiWorkOrderRoutingRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderRoutingResponseModel()));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderRoutingModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiWorkOrderRoutingRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderRoutingRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderRoutingResponseModel>(null));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderRoutingModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiWorkOrderRoutingRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        WorkOrderRoutingControllerMockFacade mock = new WorkOrderRoutingControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkOrderRoutingController controller = new WorkOrderRoutingController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class WorkOrderRoutingControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<WorkOrderRoutingController>> LoggerMock { get; set; } = new Mock<ILogger<WorkOrderRoutingController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IWorkOrderRoutingService> ServiceMock { get; set; } = new Mock<IWorkOrderRoutingService>();

                public Mock<IApiWorkOrderRoutingModelMapper> ModelMapperMock { get; set; } = new Mock<IApiWorkOrderRoutingModelMapper>();
        }
}

/*<Codenesium>
    <Hash>0dc63d13426b964f01ed68b95e4de811</Hash>
</Codenesium>*/
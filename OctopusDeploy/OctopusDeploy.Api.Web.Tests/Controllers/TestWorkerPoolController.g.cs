using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerPool")]
        [Trait("Area", "Controllers")]
        public partial class WorkerPoolControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var record = new ApiWorkerPoolResponseModel();
                        var records = new List<ApiWorkerPoolResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkerPoolResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiWorkerPoolResponseModel>>(new List<ApiWorkerPoolResponseModel>()));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkerPoolResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiWorkerPoolResponseModel()));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiWorkerPoolResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerPoolResponseModel>(null));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkerPoolResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkerPoolResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerPoolResponseModel>>(mockResponse));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkerPoolRequestModel>();
                        records.Add(new ApiWorkerPoolRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiWorkerPoolResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkerPoolResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerPoolResponseModel>>(mockResponse.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkerPoolRequestModel>();
                        records.Add(new ApiWorkerPoolRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkerPoolResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkerPoolResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerPoolResponseModel>>(mockResponse));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkerPoolRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiWorkerPoolResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkerPoolResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiWorkerPoolResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerPoolResponseModel>>(mockResponse.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkerPoolRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>()))
                        .Callback<string, ApiWorkerPoolRequestModel>(
                                (id, model) => model.IsDefault.Should().Be(true)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerPoolResponseModel>(new ApiWorkerPoolResponseModel()));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkerPoolRequestModel>();
                        patch.Replace(x => x.IsDefault, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerPoolResponseModel>(null));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkerPoolRequestModel>();
                        patch.Replace(x => x.IsDefault, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiWorkerPoolRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiWorkerPoolRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        WorkerPoolControllerMockFacade mock = new WorkerPoolControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerPoolController controller = new WorkerPoolController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class WorkerPoolControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<WorkerPoolController>> LoggerMock { get; set; } = new Mock<ILogger<WorkerPoolController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IWorkerPoolService> ServiceMock { get; set; } = new Mock<IWorkerPoolService>();
        }
}

/*<Codenesium>
    <Hash>786dcab4fa0dcc3f4134c520c40a53c0</Hash>
</Codenesium>*/
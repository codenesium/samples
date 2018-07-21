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
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "Controllers")]
        public partial class WorkerTaskLeaseControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var record = new ApiWorkerTaskLeaseResponseModel();
                        var records = new List<ApiWorkerTaskLeaseResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkerTaskLeaseResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiWorkerTaskLeaseResponseModel>>(new List<ApiWorkerTaskLeaseResponseModel>()));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiWorkerTaskLeaseResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiWorkerTaskLeaseResponseModel()));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiWorkerTaskLeaseResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerTaskLeaseResponseModel>(null));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkerTaskLeaseResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkerTaskLeaseResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResponse));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkerTaskLeaseRequestModel>();
                        records.Add(new ApiWorkerTaskLeaseRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiWorkerTaskLeaseResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResponse.Object));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiWorkerTaskLeaseRequestModel>();
                        records.Add(new ApiWorkerTaskLeaseRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiWorkerTaskLeaseResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiWorkerTaskLeaseResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResponse));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkerTaskLeaseRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiWorkerTaskLeaseResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiWorkerTaskLeaseResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResponse.Object));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiWorkerTaskLeaseRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>()))
                        .Callback<string, ApiWorkerTaskLeaseRequestModel>(
                                (id, model) => model.Exclusive.Should().Be(true)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerTaskLeaseResponseModel>(new ApiWorkerTaskLeaseResponseModel()));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkerTaskLeaseModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkerTaskLeaseRequestModel>();
                        patch.Replace(x => x.Exclusive, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerTaskLeaseResponseModel>(null));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiWorkerTaskLeaseRequestModel>();
                        patch.Replace(x => x.Exclusive, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiWorkerTaskLeaseResponseModel()));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkerTaskLeaseModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiWorkerTaskLeaseRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiWorkerTaskLeaseResponseModel()));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkerTaskLeaseModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiWorkerTaskLeaseRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkerTaskLeaseResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiWorkerTaskLeaseResponseModel>(null));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkerTaskLeaseModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiWorkerTaskLeaseRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        WorkerTaskLeaseControllerMockFacade mock = new WorkerTaskLeaseControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        WorkerTaskLeaseController controller = new WorkerTaskLeaseController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class WorkerTaskLeaseControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<WorkerTaskLeaseController>> LoggerMock { get; set; } = new Mock<ILogger<WorkerTaskLeaseController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IWorkerTaskLeaseService> ServiceMock { get; set; } = new Mock<IWorkerTaskLeaseService>();

                public Mock<IApiWorkerTaskLeaseModelMapper> ModelMapperMock { get; set; } = new Mock<IApiWorkerTaskLeaseModelMapper>();
        }
}

/*<Codenesium>
    <Hash>e727670adf3bf842e07374a16810d4cc</Hash>
</Codenesium>*/
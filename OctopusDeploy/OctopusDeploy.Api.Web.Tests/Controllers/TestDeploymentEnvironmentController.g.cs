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
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "Controllers")]
        public partial class DeploymentEnvironmentControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var record = new ApiDeploymentEnvironmentResponseModel();
                        var records = new List<ApiDeploymentEnvironmentResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDeploymentEnvironmentResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDeploymentEnvironmentResponseModel>>(new List<ApiDeploymentEnvironmentResponseModel>()));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDeploymentEnvironmentResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentEnvironmentResponseModel()));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiDeploymentEnvironmentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentEnvironmentResponseModel>(null));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDeploymentEnvironmentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDeploymentEnvironmentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResponse));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDeploymentEnvironmentRequestModel>();
                        records.Add(new ApiDeploymentEnvironmentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiDeploymentEnvironmentResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResponse.Object));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDeploymentEnvironmentRequestModel>();
                        records.Add(new ApiDeploymentEnvironmentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDeploymentEnvironmentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDeploymentEnvironmentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResponse));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDeploymentEnvironmentRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDeploymentEnvironmentResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiDeploymentEnvironmentResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResponse.Object));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDeploymentEnvironmentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>()))
                        .Callback<string, ApiDeploymentEnvironmentRequestModel>(
                                (id, model) => model.JSON.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentEnvironmentResponseModel>(new ApiDeploymentEnvironmentResponseModel()));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentEnvironmentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDeploymentEnvironmentRequestModel>();
                        patch.Replace(x => x.JSON, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentEnvironmentResponseModel>(null));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDeploymentEnvironmentRequestModel>();
                        patch.Replace(x => x.JSON, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentEnvironmentResponseModel()));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentEnvironmentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentEnvironmentRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentEnvironmentResponseModel()));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentEnvironmentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentEnvironmentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentEnvironmentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentEnvironmentResponseModel>(null));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentEnvironmentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentEnvironmentRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DeploymentEnvironmentControllerMockFacade mock = new DeploymentEnvironmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DeploymentEnvironmentController controller = new DeploymentEnvironmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class DeploymentEnvironmentControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<DeploymentEnvironmentController>> LoggerMock { get; set; } = new Mock<ILogger<DeploymentEnvironmentController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IDeploymentEnvironmentService> ServiceMock { get; set; } = new Mock<IDeploymentEnvironmentService>();

                public Mock<IApiDeploymentEnvironmentModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDeploymentEnvironmentModelMapper>();
        }
}

/*<Codenesium>
    <Hash>98a8a0866b15b6fa19d7c6a869c281d6</Hash>
</Codenesium>*/
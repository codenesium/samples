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
        [Trait("Table", "DeploymentProcess")]
        [Trait("Area", "Controllers")]
        public partial class DeploymentProcessControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var record = new ApiDeploymentProcessResponseModel();
                        var records = new List<ApiDeploymentProcessResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDeploymentProcessResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDeploymentProcessResponseModel>>(new List<ApiDeploymentProcessResponseModel>()));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDeploymentProcessResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentProcessResponseModel()));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiDeploymentProcessResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentProcessResponseModel>(null));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDeploymentProcessResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDeploymentProcessResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentProcessResponseModel>>(mockResponse));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDeploymentProcessRequestModel>();
                        records.Add(new ApiDeploymentProcessRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiDeploymentProcessResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDeploymentProcessResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentProcessResponseModel>>(mockResponse.Object));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDeploymentProcessRequestModel>();
                        records.Add(new ApiDeploymentProcessRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDeploymentProcessResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDeploymentProcessResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentProcessResponseModel>>(mockResponse));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDeploymentProcessRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiDeploymentProcessResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDeploymentProcessResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiDeploymentProcessResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentProcessResponseModel>>(mockResponse.Object));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDeploymentProcessRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>()))
                        .Callback<string, ApiDeploymentProcessRequestModel>(
                                (id, model) => model.IsFrozen.Should().Be(true)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentProcessResponseModel>(new ApiDeploymentProcessResponseModel()));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentProcessModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDeploymentProcessRequestModel>();
                        patch.Replace(x => x.IsFrozen, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentProcessResponseModel>(null));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDeploymentProcessRequestModel>();
                        patch.Replace(x => x.IsFrozen, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentProcessResponseModel()));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentProcessModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentProcessRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiDeploymentProcessResponseModel()));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentProcessModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentProcessRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiDeploymentProcessResponseModel>(null));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentProcessModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiDeploymentProcessRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DeploymentProcessControllerMockFacade mock = new DeploymentProcessControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DeploymentProcessController controller = new DeploymentProcessController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class DeploymentProcessControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<DeploymentProcessController>> LoggerMock { get; set; } = new Mock<ILogger<DeploymentProcessController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IDeploymentProcessService> ServiceMock { get; set; } = new Mock<IDeploymentProcessService>();

                public Mock<IApiDeploymentProcessModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDeploymentProcessModelMapper>();
        }
}

/*<Codenesium>
    <Hash>92c14ad47a164f15814e11a1b3e74308</Hash>
</Codenesium>*/
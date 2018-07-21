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
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "Controllers")]
        public partial class ProjectTriggerControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var record = new ApiProjectTriggerResponseModel();
                        var records = new List<ApiProjectTriggerResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProjectTriggerResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProjectTriggerResponseModel>>(new List<ApiProjectTriggerResponseModel>()));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProjectTriggerResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiProjectTriggerResponseModel()));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiProjectTriggerResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiProjectTriggerResponseModel>(null));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProjectTriggerResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProjectTriggerResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProjectTriggerResponseModel>>(mockResponse));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProjectTriggerRequestModel>();
                        records.Add(new ApiProjectTriggerRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiProjectTriggerResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProjectTriggerResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProjectTriggerResponseModel>>(mockResponse.Object));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProjectTriggerRequestModel>();
                        records.Add(new ApiProjectTriggerRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProjectTriggerResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProjectTriggerResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProjectTriggerResponseModel>>(mockResponse));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProjectTriggerRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProjectTriggerResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProjectTriggerResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiProjectTriggerResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProjectTriggerResponseModel>>(mockResponse.Object));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProjectTriggerRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiProjectTriggerResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>()))
                        .Callback<string, ApiProjectTriggerRequestModel>(
                                (id, model) => model.IsDisabled.Should().Be(true)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiProjectTriggerResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiProjectTriggerResponseModel>(new ApiProjectTriggerResponseModel()));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProjectTriggerModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProjectTriggerRequestModel>();
                        patch.Replace(x => x.IsDisabled, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiProjectTriggerResponseModel>(null));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProjectTriggerRequestModel>();
                        patch.Replace(x => x.IsDisabled, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiProjectTriggerResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProjectTriggerResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiProjectTriggerResponseModel()));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProjectTriggerModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiProjectTriggerRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiProjectTriggerResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProjectTriggerResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiProjectTriggerResponseModel()));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProjectTriggerModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiProjectTriggerRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiProjectTriggerResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProjectTriggerResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiProjectTriggerResponseModel>(null));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProjectTriggerModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiProjectTriggerRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ProjectTriggerControllerMockFacade mock = new ProjectTriggerControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProjectTriggerController controller = new ProjectTriggerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class ProjectTriggerControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ProjectTriggerController>> LoggerMock { get; set; } = new Mock<ILogger<ProjectTriggerController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IProjectTriggerService> ServiceMock { get; set; } = new Mock<IProjectTriggerService>();

                public Mock<IApiProjectTriggerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProjectTriggerModelMapper>();
        }
}

/*<Codenesium>
    <Hash>5f646aaafb3eb870188345d148942218</Hash>
</Codenesium>*/
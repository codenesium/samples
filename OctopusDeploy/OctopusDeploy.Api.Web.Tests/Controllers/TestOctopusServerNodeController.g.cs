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
        [Trait("Table", "OctopusServerNode")]
        [Trait("Area", "Controllers")]
        public partial class OctopusServerNodeControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var record = new ApiOctopusServerNodeResponseModel();
                        var records = new List<ApiOctopusServerNodeResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiOctopusServerNodeResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiOctopusServerNodeResponseModel>>(new List<ApiOctopusServerNodeResponseModel>()));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiOctopusServerNodeResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiOctopusServerNodeResponseModel()));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiOctopusServerNodeResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiOctopusServerNodeResponseModel>(null));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiOctopusServerNodeResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiOctopusServerNodeResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOctopusServerNodeResponseModel>>(mockResponse));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiOctopusServerNodeRequestModel>();
                        records.Add(new ApiOctopusServerNodeRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiOctopusServerNodeResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiOctopusServerNodeResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOctopusServerNodeResponseModel>>(mockResponse.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiOctopusServerNodeRequestModel>();
                        records.Add(new ApiOctopusServerNodeRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiOctopusServerNodeResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiOctopusServerNodeResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOctopusServerNodeResponseModel>>(mockResponse));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiOctopusServerNodeRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiOctopusServerNodeResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiOctopusServerNodeResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiOctopusServerNodeResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOctopusServerNodeResponseModel>>(mockResponse.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiOctopusServerNodeRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>()))
                        .Callback<string, ApiOctopusServerNodeRequestModel>(
                                (id, model) => model.IsInMaintenanceMode.Should().Be(true)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiOctopusServerNodeResponseModel>(new ApiOctopusServerNodeResponseModel()));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiOctopusServerNodeRequestModel>();
                        patch.Replace(x => x.IsInMaintenanceMode, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiOctopusServerNodeResponseModel>(null));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiOctopusServerNodeRequestModel>();
                        patch.Replace(x => x.IsInMaintenanceMode, true);

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiOctopusServerNodeRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiOctopusServerNodeRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        OctopusServerNodeControllerMockFacade mock = new OctopusServerNodeControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        OctopusServerNodeController controller = new OctopusServerNodeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class OctopusServerNodeControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<OctopusServerNodeController>> LoggerMock { get; set; } = new Mock<ILogger<OctopusServerNodeController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IOctopusServerNodeService> ServiceMock { get; set; } = new Mock<IOctopusServerNodeService>();
        }
}

/*<Codenesium>
    <Hash>831e4cfa616ac78209636662114311e7</Hash>
</Codenesium>*/
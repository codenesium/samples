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
        [Trait("Table", "LibraryVariableSet")]
        [Trait("Area", "Controllers")]
        public partial class LibraryVariableSetControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var record = new ApiLibraryVariableSetResponseModel();
                        var records = new List<ApiLibraryVariableSetResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLibraryVariableSetResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiLibraryVariableSetResponseModel>>(new List<ApiLibraryVariableSetResponseModel>()));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLibraryVariableSetResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiLibraryVariableSetResponseModel()));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiLibraryVariableSetResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiLibraryVariableSetResponseModel>(null));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLibraryVariableSetResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLibraryVariableSetResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLibraryVariableSetResponseModel>>(mockResponse));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLibraryVariableSetRequestModel>();
                        records.Add(new ApiLibraryVariableSetRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiLibraryVariableSetResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLibraryVariableSetResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLibraryVariableSetResponseModel>>(mockResponse.Object));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLibraryVariableSetRequestModel>();
                        records.Add(new ApiLibraryVariableSetRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLibraryVariableSetResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLibraryVariableSetResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLibraryVariableSetResponseModel>>(mockResponse));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLibraryVariableSetRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiLibraryVariableSetResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLibraryVariableSetResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiLibraryVariableSetResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLibraryVariableSetResponseModel>>(mockResponse.Object));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLibraryVariableSetRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>()))
                        .Callback<string, ApiLibraryVariableSetRequestModel>(
                                (id, model) => model.ContentType.Should().Be("A")
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiLibraryVariableSetResponseModel>(new ApiLibraryVariableSetResponseModel()));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLibraryVariableSetModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLibraryVariableSetRequestModel>();
                        patch.Replace(x => x.ContentType, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiLibraryVariableSetResponseModel>(null));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLibraryVariableSetRequestModel>();
                        patch.Replace(x => x.ContentType, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiLibraryVariableSetResponseModel()));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLibraryVariableSetModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiLibraryVariableSetRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiLibraryVariableSetResponseModel()));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLibraryVariableSetModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiLibraryVariableSetRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiLibraryVariableSetResponseModel>(null));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLibraryVariableSetModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiLibraryVariableSetRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LibraryVariableSetControllerMockFacade mock = new LibraryVariableSetControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LibraryVariableSetController controller = new LibraryVariableSetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class LibraryVariableSetControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<LibraryVariableSetController>> LoggerMock { get; set; } = new Mock<ILogger<LibraryVariableSetController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ILibraryVariableSetService> ServiceMock { get; set; } = new Mock<ILibraryVariableSetService>();

                public Mock<IApiLibraryVariableSetModelMapper> ModelMapperMock { get; set; } = new Mock<IApiLibraryVariableSetModelMapper>();
        }
}

/*<Codenesium>
    <Hash>9b7d04a85cc6db9a78af1a08383b516e</Hash>
</Codenesium>*/
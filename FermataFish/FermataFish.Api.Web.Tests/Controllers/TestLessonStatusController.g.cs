using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
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

namespace FermataFishNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "Controllers")]
        public partial class LessonStatusControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var record = new ApiLessonStatusResponseModel();
                        var records = new List<ApiLessonStatusResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLessonStatusResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiLessonStatusResponseModel>>(new List<ApiLessonStatusResponseModel>()));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLessonStatusResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonStatusResponseModel()));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiLessonStatusResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonStatusResponseModel>(null));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLessonStatusResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLessonStatusResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonStatusResponseModel>>(mockResponse));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLessonStatusRequestModel>();
                        records.Add(new ApiLessonStatusRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiLessonStatusResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLessonStatusResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonStatusResponseModel>>(mockResponse.Object));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLessonStatusRequestModel>();
                        records.Add(new ApiLessonStatusRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLessonStatusResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLessonStatusResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonStatusResponseModel>>(mockResponse));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLessonStatusRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiLessonStatusResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLessonStatusResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiLessonStatusResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonStatusResponseModel>>(mockResponse.Object));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLessonStatusRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonStatusResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>()))
                        .Callback<int, ApiLessonStatusRequestModel>(
                                (id, model) => model.Name.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiLessonStatusResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonStatusResponseModel>(new ApiLessonStatusResponseModel()));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonStatusModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLessonStatusRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonStatusResponseModel>(null));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLessonStatusRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonStatusResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonStatusResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonStatusResponseModel()));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonStatusModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonStatusRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonStatusResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonStatusResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonStatusResponseModel()));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonStatusModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonStatusRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonStatusResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonStatusRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonStatusResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonStatusResponseModel>(null));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonStatusModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonStatusRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LessonStatusControllerMockFacade mock = new LessonStatusControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LessonStatusController controller = new LessonStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class LessonStatusControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<LessonStatusController>> LoggerMock { get; set; } = new Mock<ILogger<LessonStatusController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ILessonStatusService> ServiceMock { get; set; } = new Mock<ILessonStatusService>();

                public Mock<IApiLessonStatusModelMapper> ModelMapperMock { get; set; } = new Mock<IApiLessonStatusModelMapper>();
        }
}

/*<Codenesium>
    <Hash>b50d522debc7e72b39ad6bde0f1b4d26</Hash>
</Codenesium>*/
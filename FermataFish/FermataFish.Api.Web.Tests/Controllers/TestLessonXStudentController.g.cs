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
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "Controllers")]
        public partial class LessonXStudentControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var record = new ApiLessonXStudentResponseModel();
                        var records = new List<ApiLessonXStudentResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLessonXStudentResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiLessonXStudentResponseModel>>(new List<ApiLessonXStudentResponseModel>()));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiLessonXStudentResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonXStudentResponseModel()));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiLessonXStudentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonXStudentResponseModel>(null));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLessonXStudentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLessonXStudentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonXStudentResponseModel>>(mockResponse));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLessonXStudentRequestModel>();
                        records.Add(new ApiLessonXStudentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiLessonXStudentResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLessonXStudentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonXStudentResponseModel>>(mockResponse.Object));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiLessonXStudentRequestModel>();
                        records.Add(new ApiLessonXStudentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiLessonXStudentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiLessonXStudentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonXStudentResponseModel>>(mockResponse));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLessonXStudentRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiLessonXStudentResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiLessonXStudentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiLessonXStudentResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLessonXStudentResponseModel>>(mockResponse.Object));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiLessonXStudentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonXStudentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>()))
                        .Callback<int, ApiLessonXStudentRequestModel>(
                                (id, model) => model.LessonId.Should().Be(1)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiLessonXStudentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonXStudentResponseModel>(new ApiLessonXStudentResponseModel()));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonXStudentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLessonXStudentRequestModel>();
                        patch.Replace(x => x.LessonId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonXStudentResponseModel>(null));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiLessonXStudentRequestModel>();
                        patch.Replace(x => x.LessonId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonXStudentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonXStudentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonXStudentResponseModel()));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonXStudentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonXStudentRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonXStudentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonXStudentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiLessonXStudentResponseModel()));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonXStudentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonXStudentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiLessonXStudentResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiLessonXStudentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLessonXStudentResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiLessonXStudentResponseModel>(null));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLessonXStudentModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiLessonXStudentRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        LessonXStudentControllerMockFacade mock = new LessonXStudentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        LessonXStudentController controller = new LessonXStudentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class LessonXStudentControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<LessonXStudentController>> LoggerMock { get; set; } = new Mock<ILogger<LessonXStudentController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ILessonXStudentService> ServiceMock { get; set; } = new Mock<ILessonXStudentService>();

                public Mock<IApiLessonXStudentModelMapper> ModelMapperMock { get; set; } = new Mock<IApiLessonXStudentModelMapper>();
        }
}

/*<Codenesium>
    <Hash>2758a1a224dfcf327f359ac3db90aa35</Hash>
</Codenesium>*/
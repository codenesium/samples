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
        [Trait("Table", "TeacherSkill")]
        [Trait("Area", "Controllers")]
        public partial class TeacherSkillControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var record = new ApiTeacherSkillResponseModel();
                        var records = new List<ApiTeacherSkillResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTeacherSkillResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTeacherSkillResponseModel>>(new List<ApiTeacherSkillResponseModel>()));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTeacherSkillResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherSkillResponseModel()));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiTeacherSkillResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherSkillResponseModel>(null));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTeacherSkillResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherSkillResponseModel>>(mockResponse));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTeacherSkillRequestModel>();
                        records.Add(new ApiTeacherSkillRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiTeacherSkillResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherSkillResponseModel>>(mockResponse.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTeacherSkillRequestModel>();
                        records.Add(new ApiTeacherSkillRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTeacherSkillResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherSkillResponseModel>>(mockResponse));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTeacherSkillRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiTeacherSkillResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiTeacherSkillResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherSkillResponseModel>>(mockResponse.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTeacherSkillRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>()))
                        .Callback<int, ApiTeacherSkillRequestModel>(
                                (id, model) => model.Name.Should().Be("A")
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherSkillResponseModel>(new ApiTeacherSkillResponseModel()));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTeacherSkillRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherSkillResponseModel>(null));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTeacherSkillRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTeacherSkillRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTeacherSkillRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        TeacherSkillControllerMockFacade mock = new TeacherSkillControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TeacherSkillController controller = new TeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class TeacherSkillControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<TeacherSkillController>> LoggerMock { get; set; } = new Mock<ILogger<TeacherSkillController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ITeacherSkillService> ServiceMock { get; set; } = new Mock<ITeacherSkillService>();
        }
}

/*<Codenesium>
    <Hash>9bd148b1ac607a3b5626e4bd73347ee4</Hash>
</Codenesium>*/
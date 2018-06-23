using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace AdventureWorksNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Department")]
        [Trait("Area", "Controllers")]
        public partial class DepartmentControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var record = new ApiDepartmentResponseModel();
                        var records = new List<ApiDepartmentResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDepartmentResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDepartmentResponseModel>>(new List<ApiDepartmentResponseModel>()));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDepartmentResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ApiDepartmentResponseModel()));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(short));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiDepartmentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiDepartmentResponseModel>(null));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(short));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDepartmentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDepartmentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDepartmentResponseModel>>(mockResponse));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDepartmentRequestModel>();
                        records.Add(new ApiDepartmentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiDepartmentResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDepartmentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDepartmentResponseModel>>(mockResponse.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDepartmentRequestModel>();
                        records.Add(new ApiDepartmentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDepartmentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDepartmentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDepartmentResponseModel>>(mockResponse));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDepartmentRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiDepartmentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDepartmentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiDepartmentResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDepartmentResponseModel>>(mockResponse.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDepartmentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>()))
                        .Callback<short, ApiDepartmentRequestModel>(
                                (id, model) => model.GroupName.Should().Be("A")
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiDepartmentResponseModel>(new ApiDepartmentResponseModel()));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDepartmentRequestModel>();
                        patch.Replace(x => x.GroupName, "A");

                        IActionResult response = await controller.Patch(default(short), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiDepartmentResponseModel>(null));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDepartmentRequestModel>();
                        patch.Replace(x => x.GroupName, "A");

                        IActionResult response = await controller.Patch(default(short), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(short), new ApiDepartmentRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(short), new ApiDepartmentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(short));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<short>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        DepartmentControllerMockFacade mock = new DepartmentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DepartmentController controller = new DepartmentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(short));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<short>()));
                }
        }

        public class DepartmentControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<DepartmentController>> LoggerMock { get; set; } = new Mock<ILogger<DepartmentController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IDepartmentService> ServiceMock { get; set; } = new Mock<IDepartmentService>();
        }
}

/*<Codenesium>
    <Hash>901ec7504f3c91b8b55285ab4c95a49d</Hash>
</Codenesium>*/
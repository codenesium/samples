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
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "Controllers")]
        public partial class EmployeePayHistoryControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var record = new ApiEmployeePayHistoryResponseModel();
                        var records = new List<ApiEmployeePayHistoryResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiEmployeePayHistoryResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiEmployeePayHistoryResponseModel>>(new List<ApiEmployeePayHistoryResponseModel>()));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiEmployeePayHistoryResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeePayHistoryResponseModel()));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiEmployeePayHistoryResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeePayHistoryResponseModel>(null));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiEmployeePayHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiEmployeePayHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeePayHistoryResponseModel>>(mockResponse));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiEmployeePayHistoryRequestModel>();
                        records.Add(new ApiEmployeePayHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiEmployeePayHistoryResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiEmployeePayHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeePayHistoryResponseModel>>(mockResponse.Object));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiEmployeePayHistoryRequestModel>();
                        records.Add(new ApiEmployeePayHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiEmployeePayHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiEmployeePayHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeePayHistoryResponseModel>>(mockResponse));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiEmployeePayHistoryRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiEmployeePayHistoryResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiEmployeePayHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiEmployeePayHistoryResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeePayHistoryResponseModel>>(mockResponse.Object));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiEmployeePayHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiEmployeePayHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>()))
                        .Callback<int, ApiEmployeePayHistoryRequestModel>(
                                (id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiEmployeePayHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeePayHistoryResponseModel>(new ApiEmployeePayHistoryResponseModel()));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeePayHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiEmployeePayHistoryRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeePayHistoryResponseModel>(null));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiEmployeePayHistoryRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiEmployeePayHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeePayHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeePayHistoryResponseModel()));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeePayHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiEmployeePayHistoryRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiEmployeePayHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeePayHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeePayHistoryResponseModel()));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeePayHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiEmployeePayHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiEmployeePayHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeePayHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeePayHistoryResponseModel>(null));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeePayHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiEmployeePayHistoryRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        EmployeePayHistoryControllerMockFacade mock = new EmployeePayHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        EmployeePayHistoryController controller = new EmployeePayHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class EmployeePayHistoryControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<EmployeePayHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<EmployeePayHistoryController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IEmployeePayHistoryService> ServiceMock { get; set; } = new Mock<IEmployeePayHistoryService>();

                public Mock<IApiEmployeePayHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiEmployeePayHistoryModelMapper>();
        }
}

/*<Codenesium>
    <Hash>c7ac9e66e075ceba6b1e9aa84929f370</Hash>
</Codenesium>*/
using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "Controllers")]
        public partial class VersionInfoControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        var record = new ApiVersionInfoResponseModel();
                        var records = new List<ApiVersionInfoResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiVersionInfoResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiVersionInfoResponseModel>>(new List<ApiVersionInfoResponseModel>()));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiVersionInfoResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new ApiVersionInfoResponseModel()));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(long));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiVersionInfoResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<ApiVersionInfoResponseModel>(null));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(long));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiVersionInfoResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiVersionInfoResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoResponseModel>>(mockResponse));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiVersionInfoRequestModel>();
                        records.Add(new ApiVersionInfoRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiVersionInfoResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiVersionInfoResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoResponseModel>>(mockResponse.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiVersionInfoRequestModel>();
                        records.Add(new ApiVersionInfoRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiVersionInfoResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiVersionInfoResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoResponseModel>>(mockResponse));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiVersionInfoRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiVersionInfoResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiVersionInfoResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiVersionInfoResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoResponseModel>>(mockResponse.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiVersionInfoRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(long), new ApiVersionInfoRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(long), new ApiVersionInfoRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(long));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<long>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(long));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<long>()));
                }
        }

        public class VersionInfoControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<VersionInfoController>> LoggerMock { get; set; } = new Mock<ILogger<VersionInfoController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IVersionInfoService> ServiceMock { get; set; } = new Mock<IVersionInfoService>();
        }
}

/*<Codenesium>
    <Hash>334ea1760654011de18c2dc2538948a5</Hash>
</Codenesium>*/
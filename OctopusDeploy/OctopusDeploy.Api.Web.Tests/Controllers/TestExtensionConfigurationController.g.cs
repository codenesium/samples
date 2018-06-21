using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
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
        [Trait("Table", "ExtensionConfiguration")]
        [Trait("Area", "Controllers")]
        public partial class ExtensionConfigurationControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        var record = new ApiExtensionConfigurationResponseModel();
                        var records = new List<ApiExtensionConfigurationResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiExtensionConfigurationResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiExtensionConfigurationResponseModel>>(new List<ApiExtensionConfigurationResponseModel>()));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiExtensionConfigurationResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiExtensionConfigurationResponseModel()));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiExtensionConfigurationResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiExtensionConfigurationResponseModel>(null));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiExtensionConfigurationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiExtensionConfigurationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiExtensionConfigurationResponseModel>>(mockResponse));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiExtensionConfigurationRequestModel>();
                        records.Add(new ApiExtensionConfigurationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiExtensionConfigurationResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiExtensionConfigurationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiExtensionConfigurationResponseModel>>(mockResponse.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiExtensionConfigurationRequestModel>();
                        records.Add(new ApiExtensionConfigurationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiExtensionConfigurationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiExtensionConfigurationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiExtensionConfigurationResponseModel>>(mockResponse));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiExtensionConfigurationRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiExtensionConfigurationResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiExtensionConfigurationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiExtensionConfigurationResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiExtensionConfigurationResponseModel>>(mockResponse.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiExtensionConfigurationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiExtensionConfigurationRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiExtensionConfigurationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ExtensionConfigurationControllerMockFacade mock = new ExtensionConfigurationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ExtensionConfigurationController controller = new ExtensionConfigurationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class ExtensionConfigurationControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ExtensionConfigurationController>> LoggerMock { get; set; } = new Mock<ILogger<ExtensionConfigurationController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IExtensionConfigurationService> ServiceMock { get; set; } = new Mock<IExtensionConfigurationService>();
        }
}

/*<Codenesium>
    <Hash>7d4551ab3573ece418a7413c1b899a46</Hash>
</Codenesium>*/
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
        [Trait("Table", "User")]
        [Trait("Area", "Controllers")]
        public partial class UserControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        var record = new ApiUserResponseModel();
                        var records = new List<ApiUserResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiUserResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiUserResponseModel>>(new List<ApiUserResponseModel>()));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiUserResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiUserResponseModel()));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiUserResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiUserResponseModel>(null));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        UserControllerMockFacade mock = new UserControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiUserResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiUserResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUserResponseModel>>(mockResponse));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiUserRequestModel>();
                        records.Add(new ApiUserRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiUserResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiUserResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUserResponseModel>>(mockResponse.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiUserRequestModel>();
                        records.Add(new ApiUserRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiUserResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiUserResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUserResponseModel>>(mockResponse));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiUserRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiUserResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiUserResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiUserResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUserResponseModel>>(mockResponse.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiUserRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiUserRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiUserRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        UserControllerMockFacade mock = new UserControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        UserController controller = new UserController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class UserControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<UserController>> LoggerMock { get; set; } = new Mock<ILogger<UserController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IUserService> ServiceMock { get; set; } = new Mock<IUserService>();
        }
}

/*<Codenesium>
    <Hash>4b151c72da198989841be5abb1bcb8ce</Hash>
</Codenesium>*/
using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Chain")]
        [Trait("Area", "Controllers")]
        public partial class ChainControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var record = new ApiChainResponseModel();
                        var records = new List<ApiChainResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiChainResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiChainResponseModel>>(new List<ApiChainResponseModel>()));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiChainResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiChainResponseModel()));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiChainResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainResponseModel>(null));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiChainResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiChainResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainResponseModel>>(mockResponse));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiChainRequestModel>();
                        records.Add(new ApiChainRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiChainResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiChainResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainResponseModel>>(mockResponse.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiChainRequestModel>();
                        records.Add(new ApiChainRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiChainResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiChainResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainResponseModel>>(mockResponse));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiChainRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiChainResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiChainResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiChainResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainResponseModel>>(mockResponse.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiChainRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>()))
                        .Callback<int, ApiChainRequestModel>(
                                (id, model) => model.ChainStatusId.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainResponseModel>(new ApiChainResponseModel()));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiChainRequestModel>();
                        patch.Replace(x => x.ChainStatusId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainResponseModel>(null));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiChainRequestModel>();
                        patch.Replace(x => x.ChainStatusId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiChainRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiChainRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ChainControllerMockFacade mock = new ChainControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class ChainControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ChainController>> LoggerMock { get; set; } = new Mock<ILogger<ChainController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IChainService> ServiceMock { get; set; } = new Mock<IChainService>();
        }
}

/*<Codenesium>
    <Hash>4bdf6bfe08ed84e3bc68c88d808c60c1</Hash>
</Codenesium>*/
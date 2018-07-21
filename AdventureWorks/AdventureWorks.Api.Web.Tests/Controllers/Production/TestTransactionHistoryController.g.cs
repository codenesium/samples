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
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "Controllers")]
        public partial class TransactionHistoryControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var record = new ApiTransactionHistoryResponseModel();
                        var records = new List<ApiTransactionHistoryResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTransactionHistoryResponseModel>>(new List<ApiTransactionHistoryResponseModel>()));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryResponseModel()));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiTransactionHistoryResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryResponseModel>(null));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTransactionHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTransactionHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryResponseModel>>(mockResponse));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTransactionHistoryRequestModel>();
                        records.Add(new ApiTransactionHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiTransactionHistoryResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryResponseModel>>(mockResponse.Object));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTransactionHistoryRequestModel>();
                        records.Add(new ApiTransactionHistoryRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTransactionHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTransactionHistoryResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryResponseModel>>(mockResponse));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTransactionHistoryRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionHistoryResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiTransactionHistoryResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryResponseModel>>(mockResponse.Object));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTransactionHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>()))
                        .Callback<int, ApiTransactionHistoryRequestModel>(
                                (id, model) => model.ActualCost.Should().Be(1m)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryResponseModel>(new ApiTransactionHistoryResponseModel()));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTransactionHistoryRequestModel>();
                        patch.Replace(x => x.ActualCost, 1m);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryResponseModel>(null));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTransactionHistoryRequestModel>();
                        patch.Replace(x => x.ActualCost, 1m);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryResponseModel()));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryResponseModel()));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryResponseModel>(null));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class TransactionHistoryControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<TransactionHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionHistoryController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ITransactionHistoryService> ServiceMock { get; set; } = new Mock<ITransactionHistoryService>();

                public Mock<IApiTransactionHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionHistoryModelMapper>();
        }
}

/*<Codenesium>
    <Hash>43eb2ad3b39b30cea552531711aeb55e</Hash>
</Codenesium>*/
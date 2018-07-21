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
        [Trait("Table", "SalesOrderHeader")]
        [Trait("Area", "Controllers")]
        public partial class SalesOrderHeaderControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var record = new ApiSalesOrderHeaderResponseModel();
                        var records = new List<ApiSalesOrderHeaderResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesOrderHeaderResponseModel>>(new List<ApiSalesOrderHeaderResponseModel>()));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderResponseModel()));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiSalesOrderHeaderResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderResponseModel>(null));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesOrderHeaderResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesOrderHeaderResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderResponseModel>>(mockResponse));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesOrderHeaderRequestModel>();
                        records.Add(new ApiSalesOrderHeaderRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderResponseModel>>(mockResponse.Object));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSalesOrderHeaderRequestModel>();
                        records.Add(new ApiSalesOrderHeaderRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSalesOrderHeaderResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSalesOrderHeaderResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderResponseModel>>(mockResponse));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesOrderHeaderRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesOrderHeaderResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiSalesOrderHeaderResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderResponseModel>>(mockResponse.Object));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSalesOrderHeaderRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>()))
                        .Callback<int, ApiSalesOrderHeaderRequestModel>(
                                (id, model) => model.AccountNumber.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderResponseModel>(new ApiSalesOrderHeaderResponseModel()));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSalesOrderHeaderRequestModel>();
                        patch.Replace(x => x.AccountNumber, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderResponseModel>(null));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSalesOrderHeaderRequestModel>();
                        patch.Replace(x => x.AccountNumber, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderResponseModel()));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderResponseModel()));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderResponseModel>(null));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class SalesOrderHeaderControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<SalesOrderHeaderController>> LoggerMock { get; set; } = new Mock<ILogger<SalesOrderHeaderController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ISalesOrderHeaderService> ServiceMock { get; set; } = new Mock<ISalesOrderHeaderService>();

                public Mock<IApiSalesOrderHeaderModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesOrderHeaderModelMapper>();
        }
}

/*<Codenesium>
    <Hash>f925bd60bc044065d0a5fe5129c99b78</Hash>
</Codenesium>*/
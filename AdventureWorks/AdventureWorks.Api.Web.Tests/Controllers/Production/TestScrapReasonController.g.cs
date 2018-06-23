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
        [Trait("Table", "ScrapReason")]
        [Trait("Area", "Controllers")]
        public partial class ScrapReasonControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var record = new ApiScrapReasonResponseModel();
                        var records = new List<ApiScrapReasonResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiScrapReasonResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiScrapReasonResponseModel>>(new List<ApiScrapReasonResponseModel>()));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiScrapReasonResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ApiScrapReasonResponseModel()));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(short));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiScrapReasonResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiScrapReasonResponseModel>(null));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiScrapReasonResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiScrapReasonResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiScrapReasonResponseModel>>(mockResponse));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiScrapReasonRequestModel>();
                        records.Add(new ApiScrapReasonRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiScrapReasonResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiScrapReasonResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiScrapReasonResponseModel>>(mockResponse.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiScrapReasonRequestModel>();
                        records.Add(new ApiScrapReasonRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiScrapReasonResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiScrapReasonResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiScrapReasonResponseModel>>(mockResponse));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiScrapReasonRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiScrapReasonResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiScrapReasonResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiScrapReasonResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiScrapReasonResponseModel>>(mockResponse.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiScrapReasonRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>()))
                        .Callback<short, ApiScrapReasonRequestModel>(
                                (id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiScrapReasonResponseModel>(new ApiScrapReasonResponseModel()));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiScrapReasonRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(short), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiScrapReasonResponseModel>(null));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiScrapReasonRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(short), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(short), new ApiScrapReasonRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(short), new ApiScrapReasonRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ScrapReasonControllerMockFacade mock = new ScrapReasonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ScrapReasonController controller = new ScrapReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(short));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<short>()));
                }
        }

        public class ScrapReasonControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ScrapReasonController>> LoggerMock { get; set; } = new Mock<ILogger<ScrapReasonController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IScrapReasonService> ServiceMock { get; set; } = new Mock<IScrapReasonService>();
        }
}

/*<Codenesium>
    <Hash>88582a367042e1188a74630459376db6</Hash>
</Codenesium>*/
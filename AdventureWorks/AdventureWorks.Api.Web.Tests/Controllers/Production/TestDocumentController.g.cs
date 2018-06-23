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
        [Trait("Table", "Document")]
        [Trait("Area", "Controllers")]
        public partial class DocumentControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var record = new ApiDocumentResponseModel();
                        var records = new List<ApiDocumentResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDocumentResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDocumentResponseModel>>(new List<ApiDocumentResponseModel>()));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDocumentResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new ApiDocumentResponseModel()));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(Guid));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiDocumentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<Guid>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult<ApiDocumentResponseModel>(null));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(Guid));

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<Guid>()));
                }

                [Fact]
                public async void BulkInsert_No_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDocumentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDocumentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDocumentResponseModel>>(mockResponse));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDocumentRequestModel>();
                        records.Add(new ApiDocumentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiDocumentResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDocumentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDocumentResponseModel>>(mockResponse.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDocumentRequestModel>();
                        records.Add(new ApiDocumentRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDocumentResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDocumentResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDocumentResponseModel>>(mockResponse));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDocumentRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiDocumentResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDocumentResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiDocumentResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDocumentResponseModel>>(mockResponse.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDocumentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>()))
                        .Callback<Guid, ApiDocumentRequestModel>(
                                (id, model) => model.ChangeNumber.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult<ApiDocumentResponseModel>(new ApiDocumentResponseModel()));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDocumentRequestModel>();
                        patch.Replace(x => x.ChangeNumber, 1);

                        IActionResult response = await controller.Patch(default(Guid), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult<ApiDocumentResponseModel>(null));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDocumentRequestModel>();
                        patch.Replace(x => x.ChangeNumber, 1);

                        IActionResult response = await controller.Patch(default(Guid), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<Guid>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(Guid), new ApiDocumentRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(Guid), new ApiDocumentRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(Guid));

                        response.Should().BeOfType<NoContentResult>();
                        (response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<Guid>()));
                }

                [Fact]
                public async void Delete_Errors()
                {
                        DocumentControllerMockFacade mock = new DocumentControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DocumentController controller = new DocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(Guid));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<Guid>()));
                }
        }

        public class DocumentControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<DocumentController>> LoggerMock { get; set; } = new Mock<ILogger<DocumentController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IDocumentService> ServiceMock { get; set; } = new Mock<IDocumentService>();
        }
}

/*<Codenesium>
    <Hash>e70387bc5e0a2ca95b5ec5d00a81cf4d</Hash>
</Codenesium>*/
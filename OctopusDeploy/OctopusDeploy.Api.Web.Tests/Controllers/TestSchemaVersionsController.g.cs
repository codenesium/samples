using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [Trait("Table", "SchemaVersions")]
        [Trait("Area", "Controllers")]
        public partial class SchemaVersionsControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var record = new ApiSchemaVersionsResponseModel();
                        var records = new List<ApiSchemaVersionsResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSchemaVersionsResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSchemaVersionsResponseModel>>(new List<ApiSchemaVersionsResponseModel>()));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSchemaVersionsResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaVersionsResponseModel()));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiSchemaVersionsResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaVersionsResponseModel>(null));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSchemaVersionsResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSchemaVersionsResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaVersionsResponseModel>>(mockResponse));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSchemaVersionsRequestModel>();
                        records.Add(new ApiSchemaVersionsRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiSchemaVersionsResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSchemaVersionsResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaVersionsResponseModel>>(mockResponse.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSchemaVersionsRequestModel>();
                        records.Add(new ApiSchemaVersionsRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSchemaVersionsResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSchemaVersionsResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaVersionsResponseModel>>(mockResponse));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSchemaVersionsRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiSchemaVersionsResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSchemaVersionsResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiSchemaVersionsResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaVersionsResponseModel>>(mockResponse.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSchemaVersionsRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>()))
                        .Callback<int, ApiSchemaVersionsRequestModel>(
                                (id, model) => model.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaVersionsResponseModel>(new ApiSchemaVersionsResponseModel()));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSchemaVersionsRequestModel>();
                        patch.Replace(x => x.Applied, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaVersionsResponseModel>(null));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSchemaVersionsRequestModel>();
                        patch.Replace(x => x.Applied, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSchemaVersionsRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSchemaVersionsRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        SchemaVersionsControllerMockFacade mock = new SchemaVersionsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaVersionsController controller = new SchemaVersionsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class SchemaVersionsControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<SchemaVersionsController>> LoggerMock { get; set; } = new Mock<ILogger<SchemaVersionsController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ISchemaVersionsService> ServiceMock { get; set; } = new Mock<ISchemaVersionsService>();
        }
}

/*<Codenesium>
    <Hash>e7b295deef86e8b1b4d7fbea2694dc70</Hash>
</Codenesium>*/
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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SchemaAPerson")]
        [Trait("Area", "Controllers")]
        public partial class SchemaAPersonControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var record = new ApiSchemaAPersonResponseModel();
                        var records = new List<ApiSchemaAPersonResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSchemaAPersonResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSchemaAPersonResponseModel>>(new List<ApiSchemaAPersonResponseModel>()));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiSchemaAPersonResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonResponseModel()));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiSchemaAPersonResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonResponseModel>(null));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSchemaAPersonResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSchemaAPersonResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonResponseModel>>(mockResponse));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSchemaAPersonRequestModel>();
                        records.Add(new ApiSchemaAPersonRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiSchemaAPersonResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSchemaAPersonResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonResponseModel>>(mockResponse.Object));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiSchemaAPersonRequestModel>();
                        records.Add(new ApiSchemaAPersonRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiSchemaAPersonResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiSchemaAPersonResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonResponseModel>>(mockResponse));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSchemaAPersonRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSchemaAPersonResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiSchemaAPersonResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiSchemaAPersonResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonResponseModel>>(mockResponse.Object));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiSchemaAPersonRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>()))
                        .Callback<int, ApiSchemaAPersonRequestModel>(
                                (id, model) => model.Name.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonResponseModel>(new ApiSchemaAPersonResponseModel()));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSchemaAPersonRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonResponseModel>(null));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiSchemaAPersonRequestModel>();
                        patch.Replace(x => x.Name, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonResponseModel()));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonResponseModel()));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonResponseModel>(null));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class SchemaAPersonControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<SchemaAPersonController>> LoggerMock { get; set; } = new Mock<ILogger<SchemaAPersonController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ISchemaAPersonService> ServiceMock { get; set; } = new Mock<ISchemaAPersonService>();

                public Mock<IApiSchemaAPersonModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSchemaAPersonModelMapper>();
        }
}

/*<Codenesium>
    <Hash>ca506d7f98e176977c9293faec7fec19</Hash>
</Codenesium>*/
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
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "Controllers")]
        public partial class DatabaseLogControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var record = new ApiDatabaseLogResponseModel();
                        var records = new List<ApiDatabaseLogResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDatabaseLogResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDatabaseLogResponseModel>>(new List<ApiDatabaseLogResponseModel>()));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiDatabaseLogResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogResponseModel()));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiDatabaseLogResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogResponseModel>(null));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDatabaseLogResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDatabaseLogResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogResponseModel>>(mockResponse));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDatabaseLogRequestModel>();
                        records.Add(new ApiDatabaseLogRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiDatabaseLogResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDatabaseLogResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogResponseModel>>(mockResponse.Object));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiDatabaseLogRequestModel>();
                        records.Add(new ApiDatabaseLogRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiDatabaseLogResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiDatabaseLogResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogResponseModel>>(mockResponse));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDatabaseLogRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDatabaseLogResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiDatabaseLogResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiDatabaseLogResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogResponseModel>>(mockResponse.Object));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiDatabaseLogRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDatabaseLogResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>()))
                        .Callback<int, ApiDatabaseLogRequestModel>(
                                (id, model) => model.DatabaseUser.Should().Be("A")
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogResponseModel>(new ApiDatabaseLogResponseModel()));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDatabaseLogRequestModel>();
                        patch.Replace(x => x.DatabaseUser, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogResponseModel>(null));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiDatabaseLogRequestModel>();
                        patch.Replace(x => x.DatabaseUser, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDatabaseLogResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogResponseModel()));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiDatabaseLogRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDatabaseLogResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogResponseModel()));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiDatabaseLogRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiDatabaseLogResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogResponseModel>(null));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiDatabaseLogRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class DatabaseLogControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<DatabaseLogController>> LoggerMock { get; set; } = new Mock<ILogger<DatabaseLogController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IDatabaseLogService> ServiceMock { get; set; } = new Mock<IDatabaseLogService>();

                public Mock<IApiDatabaseLogModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDatabaseLogModelMapper>();
        }
}

/*<Codenesium>
    <Hash>ef5cbd4771363db7bd51b3306da5eace</Hash>
</Codenesium>*/
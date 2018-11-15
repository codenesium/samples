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
			var record = new ApiDatabaseLogServerResponseModel();
			var records = new List<ApiDatabaseLogServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDatabaseLogServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDatabaseLogServerResponseModel>>(new List<ApiDatabaseLogServerResponseModel>()));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDatabaseLogServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogServerResponseModel()));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDatabaseLogServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogServerResponseModel>(null));
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

			var mockResponse = ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.CreateResponse(null as ApiDatabaseLogServerResponseModel);

			mockResponse.SetRecord(new ApiDatabaseLogServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogServerResponseModel>>(mockResponse));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDatabaseLogServerRequestModel>();
			records.Add(new ApiDatabaseLogServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiDatabaseLogServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDatabaseLogServerResponseModel>>(null as ApiDatabaseLogServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogServerResponseModel>>(mockResponse.Object));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDatabaseLogServerRequestModel>();
			records.Add(new ApiDatabaseLogServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.CreateResponse(null as ApiDatabaseLogServerResponseModel);

			mockResponse.SetRecord(new ApiDatabaseLogServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogServerResponseModel>>(mockResponse));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDatabaseLogServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDatabaseLogServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDatabaseLogServerResponseModel>>(null as ApiDatabaseLogServerResponseModel);
			var mockRecord = new ApiDatabaseLogServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDatabaseLogServerResponseModel>>(mockResponse.Object));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDatabaseLogServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDatabaseLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()))
			.Callback<int, ApiDatabaseLogServerRequestModel>(
				(id, model) => model.DatabaseUser.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogServerResponseModel>(new ApiDatabaseLogServerResponseModel()));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDatabaseLogServerRequestModel>();
			patch.Replace(x => x.DatabaseUser, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogServerResponseModel>(null));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDatabaseLogServerRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiDatabaseLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogServerResponseModel()));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDatabaseLogServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDatabaseLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDatabaseLogServerResponseModel()));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDatabaseLogServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DatabaseLogControllerMockFacade mock = new DatabaseLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDatabaseLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDatabaseLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDatabaseLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDatabaseLogServerResponseModel>(null));
			DatabaseLogController controller = new DatabaseLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDatabaseLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDatabaseLogServerRequestModel());

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

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
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

		public Mock<IApiDatabaseLogServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDatabaseLogServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>8507512585c7f304b42de509f9780ba5</Hash>
</Codenesium>*/
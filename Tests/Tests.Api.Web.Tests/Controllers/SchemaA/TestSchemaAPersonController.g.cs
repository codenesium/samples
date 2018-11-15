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
			var record = new ApiSchemaAPersonServerResponseModel();
			var records = new List<ApiSchemaAPersonServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSchemaAPersonServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSchemaAPersonServerResponseModel>>(new List<ApiSchemaAPersonServerResponseModel>()));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSchemaAPersonServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonServerResponseModel()));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSchemaAPersonServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonServerResponseModel>(null));
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

			var mockResponse = ValidationResponseFactory<ApiSchemaAPersonServerResponseModel>.CreateResponse(null as ApiSchemaAPersonServerResponseModel);

			mockResponse.SetRecord(new ApiSchemaAPersonServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonServerResponseModel>>(mockResponse));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSchemaAPersonServerRequestModel>();
			records.Add(new ApiSchemaAPersonServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSchemaAPersonServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSchemaAPersonServerResponseModel>>(null as ApiSchemaAPersonServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonServerResponseModel>>(mockResponse.Object));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSchemaAPersonServerRequestModel>();
			records.Add(new ApiSchemaAPersonServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSchemaAPersonServerResponseModel>.CreateResponse(null as ApiSchemaAPersonServerResponseModel);

			mockResponse.SetRecord(new ApiSchemaAPersonServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonServerResponseModel>>(mockResponse));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSchemaAPersonServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSchemaAPersonServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSchemaAPersonServerResponseModel>>(null as ApiSchemaAPersonServerResponseModel);
			var mockRecord = new ApiSchemaAPersonServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaAPersonServerResponseModel>>(mockResponse.Object));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSchemaAPersonServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()))
			.Callback<int, ApiSchemaAPersonServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonServerResponseModel>(new ApiSchemaAPersonServerResponseModel()));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSchemaAPersonServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonServerResponseModel>(null));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSchemaAPersonServerRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonServerResponseModel()));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaAPersonServerResponseModel()));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SchemaAPersonControllerMockFacade mock = new SchemaAPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaAPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaAPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaAPersonServerResponseModel>(null));
			SchemaAPersonController controller = new SchemaAPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaAPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaAPersonServerRequestModel());

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

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
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

		public Mock<IApiSchemaAPersonServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSchemaAPersonServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>e9d8139e8a16f0fd917a3fc2fa2a87a5</Hash>
</Codenesium>*/
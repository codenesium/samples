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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "Controllers")]
	public partial class SchemaBPersonControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var record = new ApiSchemaBPersonServerResponseModel();
			var records = new List<ApiSchemaBPersonServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSchemaBPersonServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSchemaBPersonServerResponseModel>>(new List<ApiSchemaBPersonServerResponseModel>()));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSchemaBPersonServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaBPersonServerResponseModel()));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSchemaBPersonServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaBPersonServerResponseModel>(null));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSchemaBPersonServerResponseModel>.CreateResponse(null as ApiSchemaBPersonServerResponseModel);

			mockResponse.SetRecord(new ApiSchemaBPersonServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaBPersonServerResponseModel>>(mockResponse));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSchemaBPersonServerRequestModel>();
			records.Add(new ApiSchemaBPersonServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSchemaBPersonServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSchemaBPersonServerResponseModel>>(null as ApiSchemaBPersonServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaBPersonServerResponseModel>>(mockResponse.Object));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSchemaBPersonServerRequestModel>();
			records.Add(new ApiSchemaBPersonServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSchemaBPersonServerResponseModel>.CreateResponse(null as ApiSchemaBPersonServerResponseModel);

			mockResponse.SetRecord(new ApiSchemaBPersonServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaBPersonServerResponseModel>>(mockResponse));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSchemaBPersonServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSchemaBPersonServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSchemaBPersonServerResponseModel>>(null as ApiSchemaBPersonServerResponseModel);
			var mockRecord = new ApiSchemaBPersonServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSchemaBPersonServerResponseModel>>(mockResponse.Object));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSchemaBPersonServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaBPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()))
			.Callback<int, ApiSchemaBPersonServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSchemaBPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaBPersonServerResponseModel>(new ApiSchemaBPersonServerResponseModel()));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaBPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSchemaBPersonServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaBPersonServerResponseModel>(null));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSchemaBPersonServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaBPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaBPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaBPersonServerResponseModel()));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaBPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaBPersonServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaBPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaBPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSchemaBPersonServerResponseModel()));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaBPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaBPersonServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSchemaBPersonServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSchemaBPersonServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSchemaBPersonServerResponseModel>(null));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSchemaBPersonServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSchemaBPersonServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SchemaBPersonControllerMockFacade mock = new SchemaBPersonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SchemaBPersonController controller = new SchemaBPersonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SchemaBPersonControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SchemaBPersonController>> LoggerMock { get; set; } = new Mock<ILogger<SchemaBPersonController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISchemaBPersonService> ServiceMock { get; set; } = new Mock<ISchemaBPersonService>();

		public Mock<IApiSchemaBPersonServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSchemaBPersonServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4089242c5e055494c3dcb33cbc4cc5b5</Hash>
</Codenesium>*/
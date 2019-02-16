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
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "Controllers")]
	public partial class TestAllFieldTypeControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var record = new ApiTestAllFieldTypeServerResponseModel();
			var records = new List<ApiTestAllFieldTypeServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypeServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiTestAllFieldTypeServerResponseModel>>(new List<ApiTestAllFieldTypeServerResponseModel>()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypeServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeServerResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTestAllFieldTypeServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeServerResponseModel>(null));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.CreateResponse(null as ApiTestAllFieldTypeServerResponseModel);

			mockResponse.SetRecord(new ApiTestAllFieldTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResponse));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypeServerRequestModel>();
			records.Add(new ApiTestAllFieldTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTestAllFieldTypeServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(null as ApiTestAllFieldTypeServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResponse.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypeServerRequestModel>();
			records.Add(new ApiTestAllFieldTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.CreateResponse(null as ApiTestAllFieldTypeServerResponseModel);

			mockResponse.SetRecord(new ApiTestAllFieldTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResponse));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypeServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTestAllFieldTypeServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(null as ApiTestAllFieldTypeServerResponseModel);
			var mockRecord = new ApiTestAllFieldTypeServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResponse.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()))
			.Callback<int, ApiTestAllFieldTypeServerRequestModel>(
				(id, model) => model.FieldBigInt.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeServerResponseModel>(new ApiTestAllFieldTypeServerResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypeServerRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeServerResponseModel>(null));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypeServerRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeServerResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeServerResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeServerResponseModel>(null));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TestAllFieldTypeControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TestAllFieldTypeController>> LoggerMock { get; set; } = new Mock<ILogger<TestAllFieldTypeController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITestAllFieldTypeService> ServiceMock { get; set; } = new Mock<ITestAllFieldTypeService>();

		public Mock<IApiTestAllFieldTypeServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTestAllFieldTypeServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3a15fddfa773c36b7f81cc607b31b81f</Hash>
</Codenesium>*/
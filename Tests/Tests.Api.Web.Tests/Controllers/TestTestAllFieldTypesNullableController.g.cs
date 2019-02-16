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
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Controllers")]
	public partial class TestAllFieldTypesNullableControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var record = new ApiTestAllFieldTypesNullableServerResponseModel();
			var records = new List<ApiTestAllFieldTypesNullableServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypesNullableServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiTestAllFieldTypesNullableServerResponseModel>>(new List<ApiTestAllFieldTypesNullableServerResponseModel>()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypesNullableServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableServerResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTestAllFieldTypesNullableServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableServerResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.CreateResponse(null as ApiTestAllFieldTypesNullableServerResponseModel);

			mockResponse.SetRecord(new ApiTestAllFieldTypesNullableServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResponse));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypesNullableServerRequestModel>();
			records.Add(new ApiTestAllFieldTypesNullableServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTestAllFieldTypesNullableServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(null as ApiTestAllFieldTypesNullableServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResponse.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypesNullableServerRequestModel>();
			records.Add(new ApiTestAllFieldTypesNullableServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.CreateResponse(null as ApiTestAllFieldTypesNullableServerResponseModel);

			mockResponse.SetRecord(new ApiTestAllFieldTypesNullableServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResponse));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypesNullableServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(null as ApiTestAllFieldTypesNullableServerResponseModel);
			var mockRecord = new ApiTestAllFieldTypesNullableServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResponse.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypesNullableServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()))
			.Callback<int, ApiTestAllFieldTypesNullableServerRequestModel>(
				(id, model) => model.FieldBigInt.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableServerResponseModel>(new ApiTestAllFieldTypesNullableServerResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypesNullableServerRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableServerResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypesNullableServerRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableServerResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypesNullableServerResponseModel()));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypesNullableServerResponseModel>(null));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypesNullableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TestAllFieldTypesNullableControllerMockFacade mock = new TestAllFieldTypesNullableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TestAllFieldTypesNullableController controller = new TestAllFieldTypesNullableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TestAllFieldTypesNullableControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TestAllFieldTypesNullableController>> LoggerMock { get; set; } = new Mock<ILogger<TestAllFieldTypesNullableController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITestAllFieldTypesNullableService> ServiceMock { get; set; } = new Mock<ITestAllFieldTypesNullableService>();

		public Mock<IApiTestAllFieldTypesNullableServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTestAllFieldTypesNullableServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9f07f0dc2ac53b083eff0d061ae2eceb</Hash>
</Codenesium>*/
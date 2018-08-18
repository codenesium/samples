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
			var record = new ApiTestAllFieldTypeResponseModel();
			var records = new List<ApiTestAllFieldTypeResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypeResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTestAllFieldTypeResponseModel>>(new List<ApiTestAllFieldTypeResponseModel>()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTestAllFieldTypeResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTestAllFieldTypeResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiTestAllFieldTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTestAllFieldTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeResponseModel>>(mockResponse));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypeRequestModel>();
			records.Add(new ApiTestAllFieldTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTestAllFieldTypeResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeResponseModel>>(mockResponse.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTestAllFieldTypeRequestModel>();
			records.Add(new ApiTestAllFieldTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTestAllFieldTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTestAllFieldTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeResponseModel>>(mockResponse));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypeRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTestAllFieldTypeResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTestAllFieldTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTestAllFieldTypeResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTestAllFieldTypeResponseModel>>(mockResponse.Object));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTestAllFieldTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>()))
			.Callback<int, ApiTestAllFieldTypeRequestModel>(
				(id, model) => model.FieldBigInt.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeResponseModel>(new ApiTestAllFieldTypeResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypeRequestModel>();
			patch.Replace(x => x.FieldBigInt, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeResponseModel>(null));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTestAllFieldTypeRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTestAllFieldTypeResponseModel()));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TestAllFieldTypeControllerMockFacade mock = new TestAllFieldTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTestAllFieldTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTestAllFieldTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTestAllFieldTypeResponseModel>(null));
			TestAllFieldTypeController controller = new TestAllFieldTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTestAllFieldTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTestAllFieldTypeRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiTestAllFieldTypeModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTestAllFieldTypeModelMapper>();
	}
}

/*<Codenesium>
    <Hash>888c51f3b91192b53eec15b69eb14357</Hash>
</Codenesium>*/
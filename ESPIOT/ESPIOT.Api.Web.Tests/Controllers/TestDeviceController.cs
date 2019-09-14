using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "Controllers")]
	public partial class DeviceControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var record = new ApiDeviceServerResponseModel();
			var records = new List<ApiDeviceServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeviceServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiDeviceServerResponseModel>>(new List<ApiDeviceServerResponseModel>()));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeviceServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceServerResponseModel()));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDeviceServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceServerResponseModel>(null));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDeviceServerResponseModel>.CreateResponse(null as ApiDeviceServerResponseModel);

			mockResponse.SetRecord(new ApiDeviceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceServerResponseModel>>(mockResponse));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeviceServerRequestModel>();
			records.Add(new ApiDeviceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiDeviceServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeviceServerResponseModel>>(null as ApiDeviceServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceServerResponseModel>>(mockResponse.Object));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeviceServerRequestModel>();
			records.Add(new ApiDeviceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDeviceServerResponseModel>.CreateResponse(null as ApiDeviceServerResponseModel);

			mockResponse.SetRecord(new ApiDeviceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceServerResponseModel>>(mockResponse));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeviceServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDeviceServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeviceServerResponseModel>>(null as ApiDeviceServerResponseModel);
			var mockRecord = new ApiDeviceServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceServerResponseModel>>(mockResponse.Object));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeviceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()))
			.Callback<int, ApiDeviceServerRequestModel>(
				(id, model) => model.DateOfLastPing.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDeviceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceServerResponseModel>(new ApiDeviceServerResponseModel()));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeviceServerRequestModel>();
			patch.Replace(x => x.DateOfLastPing, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceServerResponseModel>(null));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeviceServerRequestModel>();
			patch.Replace(x => x.DateOfLastPing, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceServerResponseModel()));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceServerResponseModel()));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceServerResponseModel>(null));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeviceControllerMockFacade mock = new DeviceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeviceController controller = new DeviceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class DeviceControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<DeviceController>> LoggerMock { get; set; } = new Mock<ILogger<DeviceController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IDeviceService> ServiceMock { get; set; } = new Mock<IDeviceService>();

		public Mock<IApiDeviceServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDeviceServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>fceeb95b3f4be32a35546026c2ada933</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
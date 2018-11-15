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
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Controllers")]
	public partial class DeviceActionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var record = new ApiDeviceActionServerResponseModel();
			var records = new List<ApiDeviceActionServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeviceActionServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDeviceActionServerResponseModel>>(new List<ApiDeviceActionServerResponseModel>()));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeviceActionServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceActionServerResponseModel()));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDeviceActionServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceActionServerResponseModel>(null));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDeviceActionServerResponseModel>.CreateResponse(null as ApiDeviceActionServerResponseModel);

			mockResponse.SetRecord(new ApiDeviceActionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceActionServerResponseModel>>(mockResponse));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeviceActionServerRequestModel>();
			records.Add(new ApiDeviceActionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiDeviceActionServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeviceActionServerResponseModel>>(null as ApiDeviceActionServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceActionServerResponseModel>>(mockResponse.Object));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeviceActionServerRequestModel>();
			records.Add(new ApiDeviceActionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDeviceActionServerResponseModel>.CreateResponse(null as ApiDeviceActionServerResponseModel);

			mockResponse.SetRecord(new ApiDeviceActionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceActionServerResponseModel>>(mockResponse));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeviceActionServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDeviceActionServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeviceActionServerResponseModel>>(null as ApiDeviceActionServerResponseModel);
			var mockRecord = new ApiDeviceActionServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeviceActionServerResponseModel>>(mockResponse.Object));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeviceActionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceActionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()))
			.Callback<int, ApiDeviceActionServerRequestModel>(
				(id, model) => model.DeviceId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDeviceActionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceActionServerResponseModel>(new ApiDeviceActionServerResponseModel()));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceActionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeviceActionServerRequestModel>();
			patch.Replace(x => x.DeviceId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceActionServerResponseModel>(null));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeviceActionServerRequestModel>();
			patch.Replace(x => x.DeviceId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceActionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceActionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceActionServerResponseModel()));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceActionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceActionServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceActionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceActionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeviceActionServerResponseModel()));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceActionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceActionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeviceActionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeviceActionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeviceActionServerResponseModel>(null));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeviceActionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeviceActionServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeviceActionControllerMockFacade mock = new DeviceActionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeviceActionController controller = new DeviceActionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class DeviceActionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<DeviceActionController>> LoggerMock { get; set; } = new Mock<ILogger<DeviceActionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IDeviceActionService> ServiceMock { get; set; } = new Mock<IDeviceActionService>();

		public Mock<IApiDeviceActionServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDeviceActionServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>d44fad5a8125fb5657137a28cb25f73b</Hash>
</Codenesium>*/
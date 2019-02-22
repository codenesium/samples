using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapability")]
	[Trait("Area", "Controllers")]
	public partial class VehicleCapabilityControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var record = new ApiVehicleCapabilityServerResponseModel();
			var records = new List<ApiVehicleCapabilityServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilityServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVehicleCapabilityServerResponseModel>>(new List<ApiVehicleCapabilityServerResponseModel>()));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilityServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilityServerResponseModel()));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVehicleCapabilityServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilityServerResponseModel>(null));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilityServerResponseModel>.CreateResponse(null as ApiVehicleCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResponse));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilityServerRequestModel>();
			records.Add(new ApiVehicleCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVehicleCapabilityServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(null as ApiVehicleCapabilityServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResponse.Object));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilityServerRequestModel>();
			records.Add(new ApiVehicleCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilityServerResponseModel>.CreateResponse(null as ApiVehicleCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResponse));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilityServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVehicleCapabilityServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(null as ApiVehicleCapabilityServerResponseModel);
			var mockRecord = new ApiVehicleCapabilityServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResponse.Object));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()))
			.Callback<int, ApiVehicleCapabilityServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilityServerResponseModel>(new ApiVehicleCapabilityServerResponseModel()));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilityServerResponseModel>(null));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilityServerResponseModel()));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilityServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilityServerResponseModel()));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilityServerResponseModel>(null));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilityServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilityControllerMockFacade mock = new VehicleCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilityController controller = new VehicleCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VehicleCapabilityControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VehicleCapabilityController>> LoggerMock { get; set; } = new Mock<ILogger<VehicleCapabilityController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVehicleCapabilityService> ServiceMock { get; set; } = new Mock<IVehicleCapabilityService>();

		public Mock<IApiVehicleCapabilityServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVehicleCapabilityServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>7532753d8f7393aed9f74031216c0ce2</Hash>
</Codenesium>*/
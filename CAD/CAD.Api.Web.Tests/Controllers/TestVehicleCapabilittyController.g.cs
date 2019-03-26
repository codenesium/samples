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
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "Controllers")]
	public partial class VehicleCapabilittyControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var record = new ApiVehicleCapabilittyServerResponseModel();
			var records = new List<ApiVehicleCapabilittyServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilittyServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVehicleCapabilittyServerResponseModel>>(new List<ApiVehicleCapabilittyServerResponseModel>()));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilittyServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilittyServerResponseModel()));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVehicleCapabilittyServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilittyServerResponseModel>(null));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilittyServerResponseModel>.CreateResponse(null as ApiVehicleCapabilittyServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilittyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResponse));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilittyServerRequestModel>();
			records.Add(new ApiVehicleCapabilittyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVehicleCapabilittyServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(null as ApiVehicleCapabilittyServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResponse.Object));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilittyServerRequestModel>();
			records.Add(new ApiVehicleCapabilittyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilittyServerResponseModel>.CreateResponse(null as ApiVehicleCapabilittyServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilittyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResponse));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilittyServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVehicleCapabilittyServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(null as ApiVehicleCapabilittyServerResponseModel);
			var mockRecord = new ApiVehicleCapabilittyServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResponse.Object));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilittyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()))
			.Callback<int, ApiVehicleCapabilittyServerRequestModel>(
				(id, model) => model.VehicleCapabilityId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilittyServerResponseModel>(new ApiVehicleCapabilittyServerResponseModel()));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilittyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilittyServerResponseModel>(null));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilittyServerResponseModel()));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilittyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilittyServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilittyServerResponseModel()));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilittyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilittyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilittyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilittyServerResponseModel>(null));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilittyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilittyServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilittyControllerMockFacade mock = new VehicleCapabilittyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilittyController controller = new VehicleCapabilittyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VehicleCapabilittyControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VehicleCapabilittyController>> LoggerMock { get; set; } = new Mock<ILogger<VehicleCapabilittyController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVehicleCapabilittyService> ServiceMock { get; set; } = new Mock<IVehicleCapabilittyService>();

		public Mock<IApiVehicleCapabilittyServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVehicleCapabilittyServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>a108f5a3797b13e55e01c90d6d6e8a4c</Hash>
</Codenesium>*/
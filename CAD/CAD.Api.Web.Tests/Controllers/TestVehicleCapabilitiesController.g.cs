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
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "Controllers")]
	public partial class VehicleCapabilitiesControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var record = new ApiVehicleCapabilitiesServerResponseModel();
			var records = new List<ApiVehicleCapabilitiesServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilitiesServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVehicleCapabilitiesServerResponseModel>>(new List<ApiVehicleCapabilitiesServerResponseModel>()));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleCapabilitiesServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilitiesServerResponseModel()));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVehicleCapabilitiesServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilitiesServerResponseModel>(null));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilitiesServerResponseModel>.CreateResponse(null as ApiVehicleCapabilitiesServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilitiesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResponse));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilitiesServerRequestModel>();
			records.Add(new ApiVehicleCapabilitiesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVehicleCapabilitiesServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(null as ApiVehicleCapabilitiesServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResponse.Object));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleCapabilitiesServerRequestModel>();
			records.Add(new ApiVehicleCapabilitiesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleCapabilitiesServerResponseModel>.CreateResponse(null as ApiVehicleCapabilitiesServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleCapabilitiesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResponse));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilitiesServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVehicleCapabilitiesServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(null as ApiVehicleCapabilitiesServerResponseModel);
			var mockRecord = new ApiVehicleCapabilitiesServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResponse.Object));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleCapabilitiesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()))
			.Callback<int, ApiVehicleCapabilitiesServerRequestModel>(
				(id, model) => model.VehicleCapabilityId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilitiesServerResponseModel>(new ApiVehicleCapabilitiesServerResponseModel()));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilitiesServerResponseModel>(null));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilitiesServerResponseModel()));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleCapabilitiesServerResponseModel()));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleCapabilitiesServerResponseModel>(null));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleCapabilitiesServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleCapabilitiesControllerMockFacade mock = new VehicleCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleCapabilitiesController controller = new VehicleCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VehicleCapabilitiesControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VehicleCapabilitiesController>> LoggerMock { get; set; } = new Mock<ILogger<VehicleCapabilitiesController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVehicleCapabilitiesService> ServiceMock { get; set; } = new Mock<IVehicleCapabilitiesService>();

		public Mock<IApiVehicleCapabilitiesServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVehicleCapabilitiesServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9912ab5388d9354d53626aee8955d075</Hash>
</Codenesium>*/
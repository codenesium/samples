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
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "Controllers")]
	public partial class VehicleOfficerControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var record = new ApiVehicleOfficerServerResponseModel();
			var records = new List<ApiVehicleOfficerServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleOfficerServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVehicleOfficerServerResponseModel>>(new List<ApiVehicleOfficerServerResponseModel>()));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehicleOfficerServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleOfficerServerResponseModel()));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVehicleOfficerServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleOfficerServerResponseModel>(null));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleOfficerServerResponseModel>.CreateResponse(null as ApiVehicleOfficerServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleOfficerServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleOfficerServerResponseModel>>(mockResponse));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleOfficerServerRequestModel>();
			records.Add(new ApiVehicleOfficerServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVehicleOfficerServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleOfficerServerResponseModel>>(null as ApiVehicleOfficerServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleOfficerServerResponseModel>>(mockResponse.Object));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehicleOfficerServerRequestModel>();
			records.Add(new ApiVehicleOfficerServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehicleOfficerServerResponseModel>.CreateResponse(null as ApiVehicleOfficerServerResponseModel);

			mockResponse.SetRecord(new ApiVehicleOfficerServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleOfficerServerResponseModel>>(mockResponse));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleOfficerServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVehicleOfficerServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehicleOfficerServerResponseModel>>(null as ApiVehicleOfficerServerResponseModel);
			var mockRecord = new ApiVehicleOfficerServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehicleOfficerServerResponseModel>>(mockResponse.Object));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehicleOfficerServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()))
			.Callback<int, ApiVehicleOfficerServerRequestModel>(
				(id, model) => model.OfficerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVehicleOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleOfficerServerResponseModel>(new ApiVehicleOfficerServerResponseModel()));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleOfficerServerResponseModel>(null));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehicleOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleOfficerServerResponseModel()));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleOfficerServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehicleOfficerServerResponseModel()));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleOfficerServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehicleOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehicleOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehicleOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehicleOfficerServerResponseModel>(null));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehicleOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehicleOfficerServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehicleOfficerControllerMockFacade mock = new VehicleOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehicleOfficerController controller = new VehicleOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VehicleOfficerControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VehicleOfficerController>> LoggerMock { get; set; } = new Mock<ILogger<VehicleOfficerController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVehicleOfficerService> ServiceMock { get; set; } = new Mock<IVehicleOfficerService>();

		public Mock<IApiVehicleOfficerServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVehicleOfficerServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>327c0c43edd4713568742b80d93b1669</Hash>
</Codenesium>*/
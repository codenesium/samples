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
	[Trait("Table", "VehCapability")]
	[Trait("Area", "Controllers")]
	public partial class VehCapabilityControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var record = new ApiVehCapabilityServerResponseModel();
			var records = new List<ApiVehCapabilityServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehCapabilityServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVehCapabilityServerResponseModel>>(new List<ApiVehCapabilityServerResponseModel>()));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVehCapabilityServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehCapabilityServerResponseModel()));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVehCapabilityServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehCapabilityServerResponseModel>(null));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehCapabilityServerResponseModel>.CreateResponse(null as ApiVehCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiVehCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehCapabilityServerResponseModel>>(mockResponse));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehCapabilityServerRequestModel>();
			records.Add(new ApiVehCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVehCapabilityServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehCapabilityServerResponseModel>>(null as ApiVehCapabilityServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehCapabilityServerResponseModel>>(mockResponse.Object));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVehCapabilityServerRequestModel>();
			records.Add(new ApiVehCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVehCapabilityServerResponseModel>.CreateResponse(null as ApiVehCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiVehCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehCapabilityServerResponseModel>>(mockResponse));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehCapabilityServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVehCapabilityServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVehCapabilityServerResponseModel>>(null as ApiVehCapabilityServerResponseModel);
			var mockRecord = new ApiVehCapabilityServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVehCapabilityServerResponseModel>>(mockResponse.Object));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVehCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()))
			.Callback<int, ApiVehCapabilityServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVehCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehCapabilityServerResponseModel>(new ApiVehCapabilityServerResponseModel()));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehCapabilityServerResponseModel>(null));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVehCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehCapabilityServerResponseModel()));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehCapabilityServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVehCapabilityServerResponseModel()));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVehCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVehCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVehCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVehCapabilityServerResponseModel>(null));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVehCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVehCapabilityServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VehCapabilityControllerMockFacade mock = new VehCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VehCapabilityController controller = new VehCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VehCapabilityControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VehCapabilityController>> LoggerMock { get; set; } = new Mock<ILogger<VehCapabilityController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVehCapabilityService> ServiceMock { get; set; } = new Mock<IVehCapabilityService>();

		public Mock<IApiVehCapabilityServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVehCapabilityServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>6f413866fc036bb47fd9ed10cc6b4e5a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
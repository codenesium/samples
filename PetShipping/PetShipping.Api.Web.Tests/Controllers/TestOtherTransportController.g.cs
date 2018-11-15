using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Controllers")]
	public partial class OtherTransportControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var record = new ApiOtherTransportServerResponseModel();
			var records = new List<ApiOtherTransportServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOtherTransportServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiOtherTransportServerResponseModel>>(new List<ApiOtherTransportServerResponseModel>()));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOtherTransportServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOtherTransportServerResponseModel()));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiOtherTransportServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOtherTransportServerResponseModel>(null));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOtherTransportServerResponseModel>.CreateResponse(null as ApiOtherTransportServerResponseModel);

			mockResponse.SetRecord(new ApiOtherTransportServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOtherTransportServerResponseModel>>(mockResponse));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOtherTransportServerRequestModel>();
			records.Add(new ApiOtherTransportServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiOtherTransportServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOtherTransportServerResponseModel>>(null as ApiOtherTransportServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOtherTransportServerResponseModel>>(mockResponse.Object));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOtherTransportServerRequestModel>();
			records.Add(new ApiOtherTransportServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOtherTransportServerResponseModel>.CreateResponse(null as ApiOtherTransportServerResponseModel);

			mockResponse.SetRecord(new ApiOtherTransportServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOtherTransportServerResponseModel>>(mockResponse));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOtherTransportServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiOtherTransportServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOtherTransportServerResponseModel>>(null as ApiOtherTransportServerResponseModel);
			var mockRecord = new ApiOtherTransportServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOtherTransportServerResponseModel>>(mockResponse.Object));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOtherTransportServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOtherTransportServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()))
			.Callback<int, ApiOtherTransportServerRequestModel>(
				(id, model) => model.HandlerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiOtherTransportServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOtherTransportServerResponseModel>(new ApiOtherTransportServerResponseModel()));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOtherTransportServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOtherTransportServerRequestModel>();
			patch.Replace(x => x.HandlerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOtherTransportServerResponseModel>(null));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOtherTransportServerRequestModel>();
			patch.Replace(x => x.HandlerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOtherTransportServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOtherTransportServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOtherTransportServerResponseModel()));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOtherTransportServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOtherTransportServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOtherTransportServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOtherTransportServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOtherTransportServerResponseModel()));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOtherTransportServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOtherTransportServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOtherTransportServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOtherTransportServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOtherTransportServerResponseModel>(null));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOtherTransportServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOtherTransportServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OtherTransportControllerMockFacade mock = new OtherTransportControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OtherTransportController controller = new OtherTransportController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class OtherTransportControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<OtherTransportController>> LoggerMock { get; set; } = new Mock<ILogger<OtherTransportController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IOtherTransportService> ServiceMock { get; set; } = new Mock<IOtherTransportService>();

		public Mock<IApiOtherTransportServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiOtherTransportServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>f7746cc46b1b2f7a3192cb5e82792f2d</Hash>
</Codenesium>*/
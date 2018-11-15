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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "Controllers")]
	public partial class TransactionStatuControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var record = new ApiTransactionStatuServerResponseModel();
			var records = new List<ApiTransactionStatuServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionStatuServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTransactionStatuServerResponseModel>>(new List<ApiTransactionStatuServerResponseModel>()));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionStatuServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatuServerResponseModel()));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTransactionStatuServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatuServerResponseModel>(null));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.CreateResponse(null as ApiTransactionStatuServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionStatuServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatuServerResponseModel>>(mockResponse));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionStatuServerRequestModel>();
			records.Add(new ApiTransactionStatuServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTransactionStatuServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionStatuServerResponseModel>>(null as ApiTransactionStatuServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatuServerResponseModel>>(mockResponse.Object));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionStatuServerRequestModel>();
			records.Add(new ApiTransactionStatuServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionStatuServerResponseModel>.CreateResponse(null as ApiTransactionStatuServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionStatuServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatuServerResponseModel>>(mockResponse));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionStatuServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionStatuServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionStatuServerResponseModel>>(null as ApiTransactionStatuServerResponseModel);
			var mockRecord = new ApiTransactionStatuServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatuServerResponseModel>>(mockResponse.Object));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionStatuServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()))
			.Callback<int, ApiTransactionStatuServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTransactionStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatuServerResponseModel>(new ApiTransactionStatuServerResponseModel()));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionStatuServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatuServerResponseModel>(null));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionStatuServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatuServerResponseModel()));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatuServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatuServerResponseModel()));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatuServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatuServerResponseModel>(null));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatuServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionStatuControllerMockFacade mock = new TransactionStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionStatuController controller = new TransactionStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TransactionStatuControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TransactionStatuController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionStatuController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITransactionStatuService> ServiceMock { get; set; } = new Mock<ITransactionStatuService>();

		public Mock<IApiTransactionStatuServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionStatuServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>36242af323b0d14ee8738eab8c9c9894</Hash>
</Codenesium>*/
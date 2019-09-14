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
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "Controllers")]
	public partial class TransactionStatusControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var record = new ApiTransactionStatusServerResponseModel();
			var records = new List<ApiTransactionStatusServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionStatusServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiTransactionStatusServerResponseModel>>(new List<ApiTransactionStatusServerResponseModel>()));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionStatusServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatusServerResponseModel()));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTransactionStatusServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatusServerResponseModel>(null));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionStatusServerResponseModel>.CreateResponse(null as ApiTransactionStatusServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionStatusServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatusServerResponseModel>>(mockResponse));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionStatusServerRequestModel>();
			records.Add(new ApiTransactionStatusServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTransactionStatusServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionStatusServerResponseModel>>(null as ApiTransactionStatusServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatusServerResponseModel>>(mockResponse.Object));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionStatusServerRequestModel>();
			records.Add(new ApiTransactionStatusServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionStatusServerResponseModel>.CreateResponse(null as ApiTransactionStatusServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionStatusServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatusServerResponseModel>>(mockResponse));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionStatusServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionStatusServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionStatusServerResponseModel>>(null as ApiTransactionStatusServerResponseModel);
			var mockRecord = new ApiTransactionStatusServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionStatusServerResponseModel>>(mockResponse.Object));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionStatusServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()))
			.Callback<int, ApiTransactionStatusServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTransactionStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatusServerResponseModel>(new ApiTransactionStatusServerResponseModel()));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionStatusServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatusServerResponseModel>(null));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionStatusServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatusServerResponseModel()));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatusServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionStatusServerResponseModel()));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatusServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionStatusServerResponseModel>(null));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionStatusServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionStatusControllerMockFacade mock = new TransactionStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionStatusController controller = new TransactionStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TransactionStatusControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TransactionStatusController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionStatusController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITransactionStatusService> ServiceMock { get; set; } = new Mock<ITransactionStatusService>();

		public Mock<IApiTransactionStatusServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionStatusServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9a752e7f8fae5b92f04cb0191bbe84ef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
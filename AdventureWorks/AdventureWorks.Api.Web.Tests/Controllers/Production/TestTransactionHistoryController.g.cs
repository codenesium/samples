using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Controllers")]
	public partial class TransactionHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var record = new ApiTransactionHistoryServerResponseModel();
			var records = new List<ApiTransactionHistoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTransactionHistoryServerResponseModel>>(new List<ApiTransactionHistoryServerResponseModel>()));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryServerResponseModel()));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTransactionHistoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryServerResponseModel>(null));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionHistoryServerResponseModel>.CreateResponse(null as ApiTransactionHistoryServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionHistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryServerResponseModel>>(mockResponse));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryServerRequestModel>();
			records.Add(new ApiTransactionHistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTransactionHistoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryServerResponseModel>>(null as ApiTransactionHistoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryServerResponseModel>>(mockResponse.Object));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryServerRequestModel>();
			records.Add(new ApiTransactionHistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionHistoryServerResponseModel>.CreateResponse(null as ApiTransactionHistoryServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionHistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryServerResponseModel>>(mockResponse));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionHistoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryServerResponseModel>>(null as ApiTransactionHistoryServerResponseModel);
			var mockRecord = new ApiTransactionHistoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryServerResponseModel>>(mockResponse.Object));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()))
			.Callback<int, ApiTransactionHistoryServerRequestModel>(
				(id, model) => model.ActualCost.Should().Be(1m)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryServerResponseModel>(new ApiTransactionHistoryServerResponseModel()));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryServerRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryServerResponseModel>(null));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryServerRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryServerResponseModel()));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryServerResponseModel()));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryServerResponseModel>(null));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryControllerMockFacade mock = new TransactionHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryController controller = new TransactionHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TransactionHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TransactionHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITransactionHistoryService> ServiceMock { get; set; } = new Mock<ITransactionHistoryService>();

		public Mock<IApiTransactionHistoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionHistoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>23c423731ed3c447a8f8d106631e4746</Hash>
</Codenesium>*/
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
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Controllers")]
	public partial class TransactionHistoryArchiveControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var record = new ApiTransactionHistoryArchiveServerResponseModel();
			var records = new List<ApiTransactionHistoryArchiveServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryArchiveServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTransactionHistoryArchiveServerResponseModel>>(new List<ApiTransactionHistoryArchiveServerResponseModel>()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryArchiveServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveServerResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTransactionHistoryArchiveServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveServerResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.CreateResponse(null as ApiTransactionHistoryArchiveServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionHistoryArchiveServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResponse));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryArchiveServerRequestModel>();
			records.Add(new ApiTransactionHistoryArchiveServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTransactionHistoryArchiveServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(null as ApiTransactionHistoryArchiveServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResponse.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryArchiveServerRequestModel>();
			records.Add(new ApiTransactionHistoryArchiveServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTransactionHistoryArchiveServerResponseModel>.CreateResponse(null as ApiTransactionHistoryArchiveServerResponseModel);

			mockResponse.SetRecord(new ApiTransactionHistoryArchiveServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResponse));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryArchiveServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(null as ApiTransactionHistoryArchiveServerResponseModel);
			var mockRecord = new ApiTransactionHistoryArchiveServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResponse.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryArchiveServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()))
			.Callback<int, ApiTransactionHistoryArchiveServerRequestModel>(
				(id, model) => model.ActualCost.Should().Be(1m)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveServerResponseModel>(new ApiTransactionHistoryArchiveServerResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveServerResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveServerRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveServerResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveServerResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveServerResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TransactionHistoryArchiveControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TransactionHistoryArchiveController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionHistoryArchiveController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITransactionHistoryArchiveService> ServiceMock { get; set; } = new Mock<ITransactionHistoryArchiveService>();

		public Mock<IApiTransactionHistoryArchiveServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionHistoryArchiveServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5c7d24d961bd102b0d4afb54face2448</Hash>
</Codenesium>*/
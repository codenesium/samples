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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Controllers")]
	public partial class WorkOrderControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var record = new ApiWorkOrderServerResponseModel();
			var records = new List<ApiWorkOrderServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiWorkOrderServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiWorkOrderServerResponseModel>>(new List<ApiWorkOrderServerResponseModel>()));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiWorkOrderServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderServerResponseModel()));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiWorkOrderServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderServerResponseModel>(null));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiWorkOrderServerResponseModel>.CreateResponse(null as ApiWorkOrderServerResponseModel);

			mockResponse.SetRecord(new ApiWorkOrderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderServerResponseModel>>(mockResponse));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiWorkOrderServerRequestModel>();
			records.Add(new ApiWorkOrderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiWorkOrderServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiWorkOrderServerResponseModel>>(null as ApiWorkOrderServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderServerResponseModel>>(mockResponse.Object));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiWorkOrderServerRequestModel>();
			records.Add(new ApiWorkOrderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiWorkOrderServerResponseModel>.CreateResponse(null as ApiWorkOrderServerResponseModel);

			mockResponse.SetRecord(new ApiWorkOrderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderServerResponseModel>>(mockResponse));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiWorkOrderServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiWorkOrderServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiWorkOrderServerResponseModel>>(null as ApiWorkOrderServerResponseModel);
			var mockRecord = new ApiWorkOrderServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiWorkOrderServerResponseModel>>(mockResponse.Object));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiWorkOrderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiWorkOrderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>()))
			.Callback<int, ApiWorkOrderServerRequestModel>(
				(id, model) => model.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiWorkOrderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderServerResponseModel>(new ApiWorkOrderServerResponseModel()));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiWorkOrderServerRequestModel>();
			patch.Replace(x => x.DueDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderServerResponseModel>(null));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiWorkOrderServerRequestModel>();
			patch.Replace(x => x.DueDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiWorkOrderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkOrderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderServerResponseModel()));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiWorkOrderServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiWorkOrderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkOrderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiWorkOrderServerResponseModel()));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiWorkOrderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiWorkOrderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiWorkOrderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiWorkOrderServerResponseModel>(null));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiWorkOrderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiWorkOrderServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			WorkOrderControllerMockFacade mock = new WorkOrderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			WorkOrderController controller = new WorkOrderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class WorkOrderControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<WorkOrderController>> LoggerMock { get; set; } = new Mock<ILogger<WorkOrderController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IWorkOrderService> ServiceMock { get; set; } = new Mock<IWorkOrderService>();

		public Mock<IApiWorkOrderServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiWorkOrderServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>47ceb45263b5d6f9f7c1784d8f6619a3</Hash>
</Codenesium>*/
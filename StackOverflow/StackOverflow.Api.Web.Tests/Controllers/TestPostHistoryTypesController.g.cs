using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "Controllers")]
	public partial class PostHistoryTypesControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var record = new ApiPostHistoryTypesServerResponseModel();
			var records = new List<ApiPostHistoryTypesServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypesServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPostHistoryTypesServerResponseModel>>(new List<ApiPostHistoryTypesServerResponseModel>()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypesServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesServerResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPostHistoryTypesServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesServerResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPostHistoryTypesServerResponseModel>.CreateResponse(null as ApiPostHistoryTypesServerResponseModel);

			mockResponse.SetRecord(new ApiPostHistoryTypesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResponse));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypesServerRequestModel>();
			records.Add(new ApiPostHistoryTypesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPostHistoryTypesServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(null as ApiPostHistoryTypesServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResponse.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypesServerRequestModel>();
			records.Add(new ApiPostHistoryTypesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPostHistoryTypesServerResponseModel>.CreateResponse(null as ApiPostHistoryTypesServerResponseModel);

			mockResponse.SetRecord(new ApiPostHistoryTypesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResponse));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypesServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPostHistoryTypesServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(null as ApiPostHistoryTypesServerResponseModel);
			var mockRecord = new ApiPostHistoryTypesServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResponse.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()))
			.Callback<int, ApiPostHistoryTypesServerRequestModel>(
				(id, model) => model.RwType.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesServerResponseModel>(new ApiPostHistoryTypesServerResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypesServerRequestModel>();
			patch.Replace(x => x.RwType, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesServerResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypesServerRequestModel>();
			patch.Replace(x => x.RwType, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesServerResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypesServerResponseModel()));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypesServerResponseModel>(null));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypesServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryTypesControllerMockFacade mock = new PostHistoryTypesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypesController controller = new PostHistoryTypesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PostHistoryTypesControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PostHistoryTypesController>> LoggerMock { get; set; } = new Mock<ILogger<PostHistoryTypesController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPostHistoryTypesService> ServiceMock { get; set; } = new Mock<IPostHistoryTypesService>();

		public Mock<IApiPostHistoryTypesServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPostHistoryTypesServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>c4bd7eae391e4735cf3ddb91efa4f1c5</Hash>
</Codenesium>*/
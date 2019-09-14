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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Controllers")]
	public partial class PostHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var record = new ApiPostHistoryServerResponseModel();
			var records = new List<ApiPostHistoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPostHistoryServerResponseModel>>(new List<ApiPostHistoryServerResponseModel>()));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryServerResponseModel()));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPostHistoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryServerResponseModel>(null));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPostHistoryServerResponseModel>.CreateResponse(null as ApiPostHistoryServerResponseModel);

			mockResponse.SetRecord(new ApiPostHistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryServerResponseModel>>(mockResponse));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryServerRequestModel>();
			records.Add(new ApiPostHistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPostHistoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryServerResponseModel>>(null as ApiPostHistoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryServerResponseModel>>(mockResponse.Object));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryServerRequestModel>();
			records.Add(new ApiPostHistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPostHistoryServerResponseModel>.CreateResponse(null as ApiPostHistoryServerResponseModel);

			mockResponse.SetRecord(new ApiPostHistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryServerResponseModel>>(mockResponse));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPostHistoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryServerResponseModel>>(null as ApiPostHistoryServerResponseModel);
			var mockRecord = new ApiPostHistoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryServerResponseModel>>(mockResponse.Object));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()))
			.Callback<int, ApiPostHistoryServerRequestModel>(
				(id, model) => model.Comment.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPostHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryServerResponseModel>(new ApiPostHistoryServerResponseModel()));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryServerRequestModel>();
			patch.Replace(x => x.Comment, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryServerResponseModel>(null));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryServerRequestModel>();
			patch.Replace(x => x.Comment, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryServerResponseModel()));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryServerResponseModel()));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryServerResponseModel>(null));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryControllerMockFacade mock = new PostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryController controller = new PostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PostHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PostHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<PostHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPostHistoryService> ServiceMock { get; set; } = new Mock<IPostHistoryService>();

		public Mock<IApiPostHistoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPostHistoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b3dd167f19a6f282347db0b940804369</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
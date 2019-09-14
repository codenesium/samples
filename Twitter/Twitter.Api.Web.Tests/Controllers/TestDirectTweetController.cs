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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Controllers")]
	public partial class DirectTweetControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var record = new ApiDirectTweetServerResponseModel();
			var records = new List<ApiDirectTweetServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDirectTweetServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiDirectTweetServerResponseModel>>(new List<ApiDirectTweetServerResponseModel>()));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDirectTweetServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDirectTweetServerResponseModel()));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDirectTweetServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDirectTweetServerResponseModel>(null));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDirectTweetServerResponseModel>.CreateResponse(null as ApiDirectTweetServerResponseModel);

			mockResponse.SetRecord(new ApiDirectTweetServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDirectTweetServerResponseModel>>(mockResponse));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDirectTweetServerRequestModel>();
			records.Add(new ApiDirectTweetServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiDirectTweetServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDirectTweetServerResponseModel>>(null as ApiDirectTweetServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDirectTweetServerResponseModel>>(mockResponse.Object));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDirectTweetServerRequestModel>();
			records.Add(new ApiDirectTweetServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiDirectTweetServerResponseModel>.CreateResponse(null as ApiDirectTweetServerResponseModel);

			mockResponse.SetRecord(new ApiDirectTweetServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDirectTweetServerResponseModel>>(mockResponse));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDirectTweetServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDirectTweetServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDirectTweetServerResponseModel>>(null as ApiDirectTweetServerResponseModel);
			var mockRecord = new ApiDirectTweetServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDirectTweetServerResponseModel>>(mockResponse.Object));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDirectTweetServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDirectTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()))
			.Callback<int, ApiDirectTweetServerRequestModel>(
				(id, model) => model.Content.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDirectTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDirectTweetServerResponseModel>(new ApiDirectTweetServerResponseModel()));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDirectTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDirectTweetServerRequestModel>();
			patch.Replace(x => x.Content, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDirectTweetServerResponseModel>(null));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDirectTweetServerRequestModel>();
			patch.Replace(x => x.Content, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDirectTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDirectTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDirectTweetServerResponseModel()));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDirectTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDirectTweetServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDirectTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDirectTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDirectTweetServerResponseModel()));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDirectTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDirectTweetServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDirectTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDirectTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDirectTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDirectTweetServerResponseModel>(null));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDirectTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDirectTweetServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DirectTweetControllerMockFacade mock = new DirectTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DirectTweetController controller = new DirectTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class DirectTweetControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<DirectTweetController>> LoggerMock { get; set; } = new Mock<ILogger<DirectTweetController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IDirectTweetService> ServiceMock { get; set; } = new Mock<IDirectTweetService>();

		public Mock<IApiDirectTweetServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDirectTweetServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>e51c1704367638f54cb464a417ce3d08</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
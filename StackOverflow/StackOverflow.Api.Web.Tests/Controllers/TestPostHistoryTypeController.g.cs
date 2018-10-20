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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Controllers")]
	public partial class PostHistoryTypeControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var record = new ApiPostHistoryTypeResponseModel();
			var records = new List<ApiPostHistoryTypeResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypeResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPostHistoryTypeResponseModel>>(new List<ApiPostHistoryTypeResponseModel>()));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPostHistoryTypeResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypeResponseModel()));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPostHistoryTypeResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypeResponseModel>(null));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPostHistoryTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPostHistoryTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypeResponseModel>>(mockResponse));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypeRequestModel>();
			records.Add(new ApiPostHistoryTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiPostHistoryTypeResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypeResponseModel>>(mockResponse.Object));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPostHistoryTypeRequestModel>();
			records.Add(new ApiPostHistoryTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPostHistoryTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPostHistoryTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypeResponseModel>>(mockResponse));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypeRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPostHistoryTypeResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPostHistoryTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiPostHistoryTypeResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPostHistoryTypeResponseModel>>(mockResponse.Object));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPostHistoryTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>()))
			.Callback<int, ApiPostHistoryTypeRequestModel>(
				(id, model) => model.Type.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypeResponseModel>(new ApiPostHistoryTypeResponseModel()));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypeRequestModel>();
			patch.Replace(x => x.Type, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypeResponseModel>(null));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPostHistoryTypeRequestModel>();
			patch.Replace(x => x.Type, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypeResponseModel()));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypeRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPostHistoryTypeResponseModel()));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPostHistoryTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPostHistoryTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPostHistoryTypeResponseModel>(null));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPostHistoryTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPostHistoryTypeRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PostHistoryTypeControllerMockFacade mock = new PostHistoryTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PostHistoryTypeController controller = new PostHistoryTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PostHistoryTypeControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PostHistoryTypeController>> LoggerMock { get; set; } = new Mock<ILogger<PostHistoryTypeController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPostHistoryTypeService> ServiceMock { get; set; } = new Mock<IPostHistoryTypeService>();

		public Mock<IApiPostHistoryTypeModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPostHistoryTypeModelMapper>();
	}
}

/*<Codenesium>
    <Hash>a52ee61869de269aae021187d8ed7991</Hash>
</Codenesium>*/
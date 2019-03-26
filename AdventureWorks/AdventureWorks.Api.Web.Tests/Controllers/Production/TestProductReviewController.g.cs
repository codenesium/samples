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
	[Trait("Table", "ProductReview")]
	[Trait("Area", "Controllers")]
	public partial class ProductReviewControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var record = new ApiProductReviewServerResponseModel();
			var records = new List<ApiProductReviewServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductReviewServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiProductReviewServerResponseModel>>(new List<ApiProductReviewServerResponseModel>()));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductReviewServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductReviewServerResponseModel()));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductReviewServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductReviewServerResponseModel>(null));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductReviewServerResponseModel>.CreateResponse(null as ApiProductReviewServerResponseModel);

			mockResponse.SetRecord(new ApiProductReviewServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductReviewServerResponseModel>>(mockResponse));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductReviewServerRequestModel>();
			records.Add(new ApiProductReviewServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductReviewServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductReviewServerResponseModel>>(null as ApiProductReviewServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductReviewServerResponseModel>>(mockResponse.Object));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductReviewServerRequestModel>();
			records.Add(new ApiProductReviewServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductReviewServerResponseModel>.CreateResponse(null as ApiProductReviewServerResponseModel);

			mockResponse.SetRecord(new ApiProductReviewServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductReviewServerResponseModel>>(mockResponse));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductReviewServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductReviewServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductReviewServerResponseModel>>(null as ApiProductReviewServerResponseModel);
			var mockRecord = new ApiProductReviewServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductReviewServerResponseModel>>(mockResponse.Object));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductReviewServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductReviewServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>()))
			.Callback<int, ApiProductReviewServerRequestModel>(
				(id, model) => model.Comment.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductReviewServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductReviewServerResponseModel>(new ApiProductReviewServerResponseModel()));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductReviewServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductReviewServerRequestModel>();
			patch.Replace(x => x.Comment, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductReviewServerResponseModel>(null));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductReviewServerRequestModel>();
			patch.Replace(x => x.Comment, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductReviewServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductReviewServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductReviewServerResponseModel()));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductReviewServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductReviewServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductReviewServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductReviewServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductReviewServerResponseModel()));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductReviewServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductReviewServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductReviewServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductReviewServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductReviewServerResponseModel>(null));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductReviewServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductReviewServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductReviewControllerMockFacade mock = new ProductReviewControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductReviewController controller = new ProductReviewController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductReviewControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductReviewController>> LoggerMock { get; set; } = new Mock<ILogger<ProductReviewController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductReviewService> ServiceMock { get; set; } = new Mock<IProductReviewService>();

		public Mock<IApiProductReviewServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductReviewServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>562a032a64b68476883c687ba26bdecc</Hash>
</Codenesium>*/
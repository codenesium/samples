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
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Controllers")]
	public partial class ShoppingCartItemControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var record = new ApiShoppingCartItemServerResponseModel();
			var records = new List<ApiShoppingCartItemServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiShoppingCartItemServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiShoppingCartItemServerResponseModel>>(new List<ApiShoppingCartItemServerResponseModel>()));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiShoppingCartItemServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemServerResponseModel()));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiShoppingCartItemServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemServerResponseModel>(null));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.CreateResponse(null as ApiShoppingCartItemServerResponseModel);

			mockResponse.SetRecord(new ApiShoppingCartItemServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemServerResponseModel>>(mockResponse));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiShoppingCartItemServerRequestModel>();
			records.Add(new ApiShoppingCartItemServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiShoppingCartItemServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiShoppingCartItemServerResponseModel>>(null as ApiShoppingCartItemServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemServerResponseModel>>(mockResponse.Object));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiShoppingCartItemServerRequestModel>();
			records.Add(new ApiShoppingCartItemServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.CreateResponse(null as ApiShoppingCartItemServerResponseModel);

			mockResponse.SetRecord(new ApiShoppingCartItemServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemServerResponseModel>>(mockResponse));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiShoppingCartItemServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiShoppingCartItemServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiShoppingCartItemServerResponseModel>>(null as ApiShoppingCartItemServerResponseModel);
			var mockRecord = new ApiShoppingCartItemServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemServerResponseModel>>(mockResponse.Object));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiShoppingCartItemServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()))
			.Callback<int, ApiShoppingCartItemServerRequestModel>(
				(id, model) => model.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemServerResponseModel>(new ApiShoppingCartItemServerResponseModel()));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiShoppingCartItemServerRequestModel>();
			patch.Replace(x => x.DateCreated, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemServerResponseModel>(null));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiShoppingCartItemServerRequestModel>();
			patch.Replace(x => x.DateCreated, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemServerResponseModel()));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemServerResponseModel()));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemServerResponseModel>(null));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ShoppingCartItemControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ShoppingCartItemController>> LoggerMock { get; set; } = new Mock<ILogger<ShoppingCartItemController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IShoppingCartItemService> ServiceMock { get; set; } = new Mock<IShoppingCartItemService>();

		public Mock<IApiShoppingCartItemServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiShoppingCartItemServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>99d5e068e3dd2334ada86df352425f73</Hash>
</Codenesium>*/
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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "Controllers")]
	public partial class ProductCategoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var record = new ApiProductCategoryServerResponseModel();
			var records = new List<ApiProductCategoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductCategoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductCategoryServerResponseModel>>(new List<ApiProductCategoryServerResponseModel>()));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductCategoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCategoryServerResponseModel()));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductCategoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCategoryServerResponseModel>(null));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductCategoryServerResponseModel>.CreateResponse(null as ApiProductCategoryServerResponseModel);

			mockResponse.SetRecord(new ApiProductCategoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCategoryServerResponseModel>>(mockResponse));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductCategoryServerRequestModel>();
			records.Add(new ApiProductCategoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductCategoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductCategoryServerResponseModel>>(null as ApiProductCategoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCategoryServerResponseModel>>(mockResponse.Object));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductCategoryServerRequestModel>();
			records.Add(new ApiProductCategoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductCategoryServerResponseModel>.CreateResponse(null as ApiProductCategoryServerResponseModel);

			mockResponse.SetRecord(new ApiProductCategoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCategoryServerResponseModel>>(mockResponse));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductCategoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductCategoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductCategoryServerResponseModel>>(null as ApiProductCategoryServerResponseModel);
			var mockRecord = new ApiProductCategoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCategoryServerResponseModel>>(mockResponse.Object));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductCategoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()))
			.Callback<int, ApiProductCategoryServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductCategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCategoryServerResponseModel>(new ApiProductCategoryServerResponseModel()));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductCategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCategoryServerResponseModel>(null));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductCategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCategoryServerResponseModel()));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCategoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCategoryServerResponseModel()));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCategoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCategoryServerResponseModel>(null));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCategoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductCategoryControllerMockFacade mock = new ProductCategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductCategoryController controller = new ProductCategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductCategoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductCategoryController>> LoggerMock { get; set; } = new Mock<ILogger<ProductCategoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductCategoryService> ServiceMock { get; set; } = new Mock<IProductCategoryService>();

		public Mock<IApiProductCategoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductCategoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>f136cc1be3cef10cc8540a6fa786a709</Hash>
</Codenesium>*/
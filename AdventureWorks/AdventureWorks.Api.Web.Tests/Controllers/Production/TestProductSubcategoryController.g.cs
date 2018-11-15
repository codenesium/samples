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
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Controllers")]
	public partial class ProductSubcategoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var record = new ApiProductSubcategoryServerResponseModel();
			var records = new List<ApiProductSubcategoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductSubcategoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductSubcategoryServerResponseModel>>(new List<ApiProductSubcategoryServerResponseModel>()));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductSubcategoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductSubcategoryServerResponseModel()));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductSubcategoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductSubcategoryServerResponseModel>(null));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.CreateResponse(null as ApiProductSubcategoryServerResponseModel);

			mockResponse.SetRecord(new ApiProductSubcategoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductSubcategoryServerResponseModel>>(mockResponse));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductSubcategoryServerRequestModel>();
			records.Add(new ApiProductSubcategoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductSubcategoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductSubcategoryServerResponseModel>>(null as ApiProductSubcategoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductSubcategoryServerResponseModel>>(mockResponse.Object));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductSubcategoryServerRequestModel>();
			records.Add(new ApiProductSubcategoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.CreateResponse(null as ApiProductSubcategoryServerResponseModel);

			mockResponse.SetRecord(new ApiProductSubcategoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductSubcategoryServerResponseModel>>(mockResponse));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductSubcategoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductSubcategoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductSubcategoryServerResponseModel>>(null as ApiProductSubcategoryServerResponseModel);
			var mockRecord = new ApiProductSubcategoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductSubcategoryServerResponseModel>>(mockResponse.Object));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductSubcategoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductSubcategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()))
			.Callback<int, ApiProductSubcategoryServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductSubcategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductSubcategoryServerResponseModel>(new ApiProductSubcategoryServerResponseModel()));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductSubcategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductSubcategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductSubcategoryServerResponseModel>(null));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductSubcategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductSubcategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductSubcategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductSubcategoryServerResponseModel()));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductSubcategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductSubcategoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductSubcategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductSubcategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductSubcategoryServerResponseModel()));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductSubcategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductSubcategoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductSubcategoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductSubcategoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductSubcategoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductSubcategoryServerResponseModel>(null));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductSubcategoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductSubcategoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductSubcategoryControllerMockFacade mock = new ProductSubcategoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductSubcategoryController controller = new ProductSubcategoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductSubcategoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductSubcategoryController>> LoggerMock { get; set; } = new Mock<ILogger<ProductSubcategoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductSubcategoryService> ServiceMock { get; set; } = new Mock<IProductSubcategoryService>();

		public Mock<IApiProductSubcategoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductSubcategoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3572b0abe3ada431959f63f0044df110</Hash>
</Codenesium>*/
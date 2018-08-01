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
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "Controllers")]
	public partial class ProductListPriceHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var record = new ApiProductListPriceHistoryResponseModel();
			var records = new List<ApiProductListPriceHistoryResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductListPriceHistoryResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductListPriceHistoryResponseModel>>(new List<ApiProductListPriceHistoryResponseModel>()));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductListPriceHistoryResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductListPriceHistoryResponseModel()));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductListPriceHistoryResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductListPriceHistoryResponseModel>(null));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiProductListPriceHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiProductListPriceHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductListPriceHistoryResponseModel>>(mockResponse));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductListPriceHistoryRequestModel>();
			records.Add(new ApiProductListPriceHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiProductListPriceHistoryResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductListPriceHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductListPriceHistoryResponseModel>>(mockResponse.Object));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductListPriceHistoryRequestModel>();
			records.Add(new ApiProductListPriceHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiProductListPriceHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiProductListPriceHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductListPriceHistoryResponseModel>>(mockResponse));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductListPriceHistoryRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductListPriceHistoryResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductListPriceHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiProductListPriceHistoryResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductListPriceHistoryResponseModel>>(mockResponse.Object));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductListPriceHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductListPriceHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>()))
			.Callback<int, ApiProductListPriceHistoryRequestModel>(
				(id, model) => model.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductListPriceHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductListPriceHistoryResponseModel>(new ApiProductListPriceHistoryResponseModel()));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductListPriceHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductListPriceHistoryRequestModel>();
			patch.Replace(x => x.EndDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductListPriceHistoryResponseModel>(null));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductListPriceHistoryRequestModel>();
			patch.Replace(x => x.EndDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductListPriceHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductListPriceHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductListPriceHistoryResponseModel()));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductListPriceHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductListPriceHistoryRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductListPriceHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductListPriceHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductListPriceHistoryResponseModel()));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductListPriceHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductListPriceHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductListPriceHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductListPriceHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductListPriceHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductListPriceHistoryResponseModel>(null));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductListPriceHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductListPriceHistoryRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			ProductListPriceHistoryControllerMockFacade mock = new ProductListPriceHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductListPriceHistoryController controller = new ProductListPriceHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductListPriceHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductListPriceHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<ProductListPriceHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductListPriceHistoryService> ServiceMock { get; set; } = new Mock<IProductListPriceHistoryService>();

		public Mock<IApiProductListPriceHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductListPriceHistoryModelMapper>();
	}
}

/*<Codenesium>
    <Hash>ac11bfaba8e1f0a88e0ca0d52245f72f</Hash>
</Codenesium>*/
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
	[Trait("Table", "ProductCostHistory")]
	[Trait("Area", "Controllers")]
	public partial class ProductCostHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var record = new ApiProductCostHistoryResponseModel();
			var records = new List<ApiProductCostHistoryResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductCostHistoryResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductCostHistoryResponseModel>>(new List<ApiProductCostHistoryResponseModel>()));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductCostHistoryResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCostHistoryResponseModel()));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductCostHistoryResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCostHistoryResponseModel>(null));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiProductCostHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiProductCostHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCostHistoryResponseModel>>(mockResponse));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductCostHistoryRequestModel>();
			records.Add(new ApiProductCostHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiProductCostHistoryResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductCostHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCostHistoryResponseModel>>(mockResponse.Object));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductCostHistoryRequestModel>();
			records.Add(new ApiProductCostHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiProductCostHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiProductCostHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCostHistoryResponseModel>>(mockResponse));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductCostHistoryRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductCostHistoryResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductCostHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiProductCostHistoryResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductCostHistoryResponseModel>>(mockResponse.Object));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductCostHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCostHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>()))
			.Callback<int, ApiProductCostHistoryRequestModel>(
				(id, model) => model.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductCostHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCostHistoryResponseModel>(new ApiProductCostHistoryResponseModel()));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCostHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductCostHistoryRequestModel>();
			patch.Replace(x => x.EndDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCostHistoryResponseModel>(null));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductCostHistoryRequestModel>();
			patch.Replace(x => x.EndDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCostHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCostHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCostHistoryResponseModel()));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCostHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCostHistoryRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCostHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCostHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductCostHistoryResponseModel()));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCostHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCostHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductCostHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductCostHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductCostHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductCostHistoryResponseModel>(null));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductCostHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductCostHistoryRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductCostHistoryControllerMockFacade mock = new ProductCostHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductCostHistoryController controller = new ProductCostHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductCostHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductCostHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<ProductCostHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductCostHistoryService> ServiceMock { get; set; } = new Mock<IProductCostHistoryService>();

		public Mock<IApiProductCostHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductCostHistoryModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3c973926ed8d5476b28398489154adaa</Hash>
</Codenesium>*/
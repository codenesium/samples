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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Controllers")]
	public partial class ProductDescriptionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var record = new ApiProductDescriptionServerResponseModel();
			var records = new List<ApiProductDescriptionServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductDescriptionServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductDescriptionServerResponseModel>>(new List<ApiProductDescriptionServerResponseModel>()));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductDescriptionServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductDescriptionServerResponseModel()));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductDescriptionServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductDescriptionServerResponseModel>(null));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.CreateResponse(null as ApiProductDescriptionServerResponseModel);

			mockResponse.SetRecord(new ApiProductDescriptionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductDescriptionServerResponseModel>>(mockResponse));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductDescriptionServerRequestModel>();
			records.Add(new ApiProductDescriptionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductDescriptionServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductDescriptionServerResponseModel>>(null as ApiProductDescriptionServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductDescriptionServerResponseModel>>(mockResponse.Object));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductDescriptionServerRequestModel>();
			records.Add(new ApiProductDescriptionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.CreateResponse(null as ApiProductDescriptionServerResponseModel);

			mockResponse.SetRecord(new ApiProductDescriptionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductDescriptionServerResponseModel>>(mockResponse));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductDescriptionServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductDescriptionServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductDescriptionServerResponseModel>>(null as ApiProductDescriptionServerResponseModel);
			var mockRecord = new ApiProductDescriptionServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductDescriptionServerResponseModel>>(mockResponse.Object));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductDescriptionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductDescriptionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()))
			.Callback<int, ApiProductDescriptionServerRequestModel>(
				(id, model) => model.Description.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductDescriptionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductDescriptionServerResponseModel>(new ApiProductDescriptionServerResponseModel()));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductDescriptionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductDescriptionServerRequestModel>();
			patch.Replace(x => x.Description, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductDescriptionServerResponseModel>(null));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductDescriptionServerRequestModel>();
			patch.Replace(x => x.Description, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductDescriptionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductDescriptionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductDescriptionServerResponseModel()));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductDescriptionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductDescriptionServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductDescriptionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductDescriptionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductDescriptionServerResponseModel()));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductDescriptionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductDescriptionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductDescriptionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductDescriptionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductDescriptionServerResponseModel>(null));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductDescriptionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductDescriptionServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductDescriptionControllerMockFacade mock = new ProductDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductDescriptionController controller = new ProductDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductDescriptionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductDescriptionController>> LoggerMock { get; set; } = new Mock<ILogger<ProductDescriptionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductDescriptionService> ServiceMock { get; set; } = new Mock<IProductDescriptionService>();

		public Mock<IApiProductDescriptionServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductDescriptionServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4bddc42bff79d8cf37ca890e0e3791a4</Hash>
</Codenesium>*/
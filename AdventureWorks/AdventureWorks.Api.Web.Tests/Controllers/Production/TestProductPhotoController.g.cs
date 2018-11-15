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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Controllers")]
	public partial class ProductPhotoControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var record = new ApiProductPhotoServerResponseModel();
			var records = new List<ApiProductPhotoServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductPhotoServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductPhotoServerResponseModel>>(new List<ApiProductPhotoServerResponseModel>()));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductPhotoServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductPhotoServerResponseModel()));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductPhotoServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductPhotoServerResponseModel>(null));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductPhotoServerResponseModel>.CreateResponse(null as ApiProductPhotoServerResponseModel);

			mockResponse.SetRecord(new ApiProductPhotoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductPhotoServerResponseModel>>(mockResponse));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductPhotoServerRequestModel>();
			records.Add(new ApiProductPhotoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductPhotoServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductPhotoServerResponseModel>>(null as ApiProductPhotoServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductPhotoServerResponseModel>>(mockResponse.Object));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductPhotoServerRequestModel>();
			records.Add(new ApiProductPhotoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductPhotoServerResponseModel>.CreateResponse(null as ApiProductPhotoServerResponseModel);

			mockResponse.SetRecord(new ApiProductPhotoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductPhotoServerResponseModel>>(mockResponse));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductPhotoServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductPhotoServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductPhotoServerResponseModel>>(null as ApiProductPhotoServerResponseModel);
			var mockRecord = new ApiProductPhotoServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductPhotoServerResponseModel>>(mockResponse.Object));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductPhotoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()))
			.Callback<int, ApiProductPhotoServerRequestModel>(
				(id, model) => model.LargePhotoFileName.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductPhotoServerResponseModel>(new ApiProductPhotoServerResponseModel()));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductPhotoServerRequestModel>();
			patch.Replace(x => x.LargePhotoFileName, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductPhotoServerResponseModel>(null));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductPhotoServerRequestModel>();
			patch.Replace(x => x.LargePhotoFileName, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductPhotoServerResponseModel()));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductPhotoServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductPhotoServerResponseModel()));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductPhotoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductPhotoServerResponseModel>(null));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductPhotoServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductPhotoControllerMockFacade mock = new ProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductPhotoController controller = new ProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductPhotoControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductPhotoController>> LoggerMock { get; set; } = new Mock<ILogger<ProductPhotoController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductPhotoService> ServiceMock { get; set; } = new Mock<IProductPhotoService>();

		public Mock<IApiProductPhotoServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductPhotoServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>797186d385b239ac2ffd386c43d1ab4e</Hash>
</Codenesium>*/
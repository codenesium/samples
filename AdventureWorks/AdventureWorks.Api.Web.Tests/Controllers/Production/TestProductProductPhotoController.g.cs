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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "Controllers")]
	public partial class ProductProductPhotoControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var record = new ApiProductProductPhotoServerResponseModel();
			var records = new List<ApiProductProductPhotoServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductProductPhotoServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiProductProductPhotoServerResponseModel>>(new List<ApiProductProductPhotoServerResponseModel>()));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiProductProductPhotoServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductProductPhotoServerResponseModel()));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiProductProductPhotoServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductProductPhotoServerResponseModel>(null));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductProductPhotoServerResponseModel>.CreateResponse(null as ApiProductProductPhotoServerResponseModel);

			mockResponse.SetRecord(new ApiProductProductPhotoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductProductPhotoServerResponseModel>>(mockResponse));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductProductPhotoServerRequestModel>();
			records.Add(new ApiProductProductPhotoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiProductProductPhotoServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductProductPhotoServerResponseModel>>(null as ApiProductProductPhotoServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductProductPhotoServerResponseModel>>(mockResponse.Object));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiProductProductPhotoServerRequestModel>();
			records.Add(new ApiProductProductPhotoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiProductProductPhotoServerResponseModel>.CreateResponse(null as ApiProductProductPhotoServerResponseModel);

			mockResponse.SetRecord(new ApiProductProductPhotoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductProductPhotoServerResponseModel>>(mockResponse));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductProductPhotoServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiProductProductPhotoServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiProductProductPhotoServerResponseModel>>(null as ApiProductProductPhotoServerResponseModel);
			var mockRecord = new ApiProductProductPhotoServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductProductPhotoServerResponseModel>>(mockResponse.Object));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiProductProductPhotoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()))
			.Callback<int, ApiProductProductPhotoServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiProductProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductProductPhotoServerResponseModel>(new ApiProductProductPhotoServerResponseModel()));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductProductPhotoServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductProductPhotoServerResponseModel>(null));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiProductProductPhotoServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductProductPhotoServerResponseModel()));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductProductPhotoServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductProductPhotoServerResponseModel()));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductProductPhotoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiProductProductPhotoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductProductPhotoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiProductProductPhotoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductProductPhotoServerResponseModel>(null));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductProductPhotoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiProductProductPhotoServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ProductProductPhotoControllerMockFacade mock = new ProductProductPhotoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ProductProductPhotoController controller = new ProductProductPhotoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ProductProductPhotoControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ProductProductPhotoController>> LoggerMock { get; set; } = new Mock<ILogger<ProductProductPhotoController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IProductProductPhotoService> ServiceMock { get; set; } = new Mock<IProductProductPhotoService>();

		public Mock<IApiProductProductPhotoServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductProductPhotoServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>7b62f2bea09ff66963bf2f929be04e0e</Hash>
</Codenesium>*/
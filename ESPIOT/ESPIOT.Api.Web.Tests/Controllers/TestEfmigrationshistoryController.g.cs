using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "Controllers")]
	public partial class EfmigrationshistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var record = new ApiEfmigrationshistoryServerResponseModel();
			var records = new List<ApiEfmigrationshistoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEfmigrationshistoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiEfmigrationshistoryServerResponseModel>>(new List<ApiEfmigrationshistoryServerResponseModel>()));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEfmigrationshistoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiEfmigrationshistoryServerResponseModel()));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiEfmigrationshistoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiEfmigrationshistoryServerResponseModel>(null));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiEfmigrationshistoryServerResponseModel>.CreateResponse(null as ApiEfmigrationshistoryServerResponseModel);

			mockResponse.SetRecord(new ApiEfmigrationshistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResponse));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEfmigrationshistoryServerRequestModel>();
			records.Add(new ApiEfmigrationshistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiEfmigrationshistoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(null as ApiEfmigrationshistoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResponse.Object));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEfmigrationshistoryServerRequestModel>();
			records.Add(new ApiEfmigrationshistoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiEfmigrationshistoryServerResponseModel>.CreateResponse(null as ApiEfmigrationshistoryServerResponseModel);

			mockResponse.SetRecord(new ApiEfmigrationshistoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResponse));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEfmigrationshistoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiEfmigrationshistoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(null as ApiEfmigrationshistoryServerResponseModel);
			var mockRecord = new ApiEfmigrationshistoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResponse.Object));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEfmigrationshistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()))
			.Callback<string, ApiEfmigrationshistoryServerRequestModel>(
				(id, model) => model.ProductVersion.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiEfmigrationshistoryServerResponseModel>(new ApiEfmigrationshistoryServerResponseModel()));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEfmigrationshistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel>();
			patch.Replace(x => x.ProductVersion, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiEfmigrationshistoryServerResponseModel>(null));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel>();
			patch.Replace(x => x.ProductVersion, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiEfmigrationshistoryServerResponseModel()));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEfmigrationshistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiEfmigrationshistoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiEfmigrationshistoryServerResponseModel()));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEfmigrationshistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiEfmigrationshistoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiEfmigrationshistoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiEfmigrationshistoryServerResponseModel>(null));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEfmigrationshistoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiEfmigrationshistoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			EfmigrationshistoryControllerMockFacade mock = new EfmigrationshistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EfmigrationshistoryController controller = new EfmigrationshistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class EfmigrationshistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<EfmigrationshistoryController>> LoggerMock { get; set; } = new Mock<ILogger<EfmigrationshistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IEfmigrationshistoryService> ServiceMock { get; set; } = new Mock<IEfmigrationshistoryService>();

		public Mock<IApiEfmigrationshistoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiEfmigrationshistoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>6e2694ad94d727b0f12811d5693c2aa1</Hash>
</Codenesium>*/
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
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Controllers")]
	public partial class ErrorLogControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var record = new ApiErrorLogServerResponseModel();
			var records = new List<ApiErrorLogServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiErrorLogServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiErrorLogServerResponseModel>>(new List<ApiErrorLogServerResponseModel>()));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiErrorLogServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiErrorLogServerResponseModel()));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiErrorLogServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiErrorLogServerResponseModel>(null));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiErrorLogServerResponseModel>.CreateResponse(null as ApiErrorLogServerResponseModel);

			mockResponse.SetRecord(new ApiErrorLogServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiErrorLogServerResponseModel>>(mockResponse));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiErrorLogServerRequestModel>();
			records.Add(new ApiErrorLogServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiErrorLogServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiErrorLogServerResponseModel>>(null as ApiErrorLogServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiErrorLogServerResponseModel>>(mockResponse.Object));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiErrorLogServerRequestModel>();
			records.Add(new ApiErrorLogServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiErrorLogServerResponseModel>.CreateResponse(null as ApiErrorLogServerResponseModel);

			mockResponse.SetRecord(new ApiErrorLogServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiErrorLogServerResponseModel>>(mockResponse));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiErrorLogServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiErrorLogServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiErrorLogServerResponseModel>>(null as ApiErrorLogServerResponseModel);
			var mockRecord = new ApiErrorLogServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiErrorLogServerResponseModel>>(mockResponse.Object));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiErrorLogServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiErrorLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()))
			.Callback<int, ApiErrorLogServerRequestModel>(
				(id, model) => model.ErrorLine.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiErrorLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiErrorLogServerResponseModel>(new ApiErrorLogServerResponseModel()));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiErrorLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiErrorLogServerRequestModel>();
			patch.Replace(x => x.ErrorLine, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiErrorLogServerResponseModel>(null));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiErrorLogServerRequestModel>();
			patch.Replace(x => x.ErrorLine, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiErrorLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiErrorLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiErrorLogServerResponseModel()));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiErrorLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiErrorLogServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiErrorLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiErrorLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiErrorLogServerResponseModel()));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiErrorLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiErrorLogServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiErrorLogServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiErrorLogServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiErrorLogServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiErrorLogServerResponseModel>(null));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiErrorLogServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiErrorLogServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ErrorLogControllerMockFacade mock = new ErrorLogControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ErrorLogController controller = new ErrorLogController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ErrorLogControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ErrorLogController>> LoggerMock { get; set; } = new Mock<ILogger<ErrorLogController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IErrorLogService> ServiceMock { get; set; } = new Mock<IErrorLogService>();

		public Mock<IApiErrorLogServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiErrorLogServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>11580b5bf1e3031bc627df7bb35bf5c8</Hash>
</Codenesium>*/
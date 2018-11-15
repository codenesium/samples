using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Controllers")]
	public partial class VersionInfoControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var record = new ApiVersionInfoServerResponseModel();
			var records = new List<ApiVersionInfoServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVersionInfoServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiVersionInfoServerResponseModel>>(new List<ApiVersionInfoServerResponseModel>()));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVersionInfoServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new ApiVersionInfoServerResponseModel()));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(long));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVersionInfoServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<ApiVersionInfoServerResponseModel>(null));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(long));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVersionInfoServerResponseModel>.CreateResponse(null as ApiVersionInfoServerResponseModel);

			mockResponse.SetRecord(new ApiVersionInfoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoServerResponseModel>>(mockResponse));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVersionInfoServerRequestModel>();
			records.Add(new ApiVersionInfoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVersionInfoServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVersionInfoServerResponseModel>>(null as ApiVersionInfoServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoServerResponseModel>>(mockResponse.Object));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVersionInfoServerRequestModel>();
			records.Add(new ApiVersionInfoServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVersionInfoServerResponseModel>.CreateResponse(null as ApiVersionInfoServerResponseModel);

			mockResponse.SetRecord(new ApiVersionInfoServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoServerResponseModel>>(mockResponse));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVersionInfoServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVersionInfoServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVersionInfoServerResponseModel>>(null as ApiVersionInfoServerResponseModel);
			var mockRecord = new ApiVersionInfoServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVersionInfoServerResponseModel>>(mockResponse.Object));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVersionInfoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVersionInfoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()))
			.Callback<long, ApiVersionInfoServerRequestModel>(
				(id, model) => model.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVersionInfoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<ApiVersionInfoServerResponseModel>(new ApiVersionInfoServerResponseModel()));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVersionInfoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVersionInfoServerRequestModel>();
			patch.Replace(x => x.AppliedOn, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(long), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<ApiVersionInfoServerResponseModel>(null));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVersionInfoServerRequestModel>();
			patch.Replace(x => x.AppliedOn, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(long), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVersionInfoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVersionInfoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new ApiVersionInfoServerResponseModel()));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVersionInfoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(long), new ApiVersionInfoServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVersionInfoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVersionInfoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new ApiVersionInfoServerResponseModel()));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVersionInfoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(long), new ApiVersionInfoServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVersionInfoServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<ApiVersionInfoServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVersionInfoServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult<ApiVersionInfoServerResponseModel>(null));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVersionInfoServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(long), new ApiVersionInfoServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<long>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(long));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<long>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			VersionInfoControllerMockFacade mock = new VersionInfoControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<long>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VersionInfoController controller = new VersionInfoController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(long));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<long>()));
		}
	}

	public class VersionInfoControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VersionInfoController>> LoggerMock { get; set; } = new Mock<ILogger<VersionInfoController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVersionInfoService> ServiceMock { get; set; } = new Mock<IVersionInfoService>();

		public Mock<IApiVersionInfoServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVersionInfoServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>eb83d8b8503e90143507d32ee37ef1a5</Hash>
</Codenesium>*/
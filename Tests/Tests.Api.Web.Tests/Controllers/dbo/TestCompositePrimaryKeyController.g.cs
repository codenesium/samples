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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Controllers")]
	public partial class CompositePrimaryKeyControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var record = new ApiCompositePrimaryKeyServerResponseModel();
			var records = new List<ApiCompositePrimaryKeyServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCompositePrimaryKeyServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiCompositePrimaryKeyServerResponseModel>>(new List<ApiCompositePrimaryKeyServerResponseModel>()));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCompositePrimaryKeyServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCompositePrimaryKeyServerResponseModel()));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCompositePrimaryKeyServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCompositePrimaryKeyServerResponseModel>(null));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCompositePrimaryKeyServerResponseModel>.CreateResponse(null as ApiCompositePrimaryKeyServerResponseModel);

			mockResponse.SetRecord(new ApiCompositePrimaryKeyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResponse));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCompositePrimaryKeyServerRequestModel>();
			records.Add(new ApiCompositePrimaryKeyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCompositePrimaryKeyServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(null as ApiCompositePrimaryKeyServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResponse.Object));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCompositePrimaryKeyServerRequestModel>();
			records.Add(new ApiCompositePrimaryKeyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCompositePrimaryKeyServerResponseModel>.CreateResponse(null as ApiCompositePrimaryKeyServerResponseModel);

			mockResponse.SetRecord(new ApiCompositePrimaryKeyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResponse));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCompositePrimaryKeyServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCompositePrimaryKeyServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(null as ApiCompositePrimaryKeyServerResponseModel);
			var mockRecord = new ApiCompositePrimaryKeyServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResponse.Object));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCompositePrimaryKeyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()))
			.Callback<int, ApiCompositePrimaryKeyServerRequestModel>(
				(id, model) => model.Id2.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCompositePrimaryKeyServerResponseModel>(new ApiCompositePrimaryKeyServerResponseModel()));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCompositePrimaryKeyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel>();
			patch.Replace(x => x.Id2, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCompositePrimaryKeyServerResponseModel>(null));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel>();
			patch.Replace(x => x.Id2, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCompositePrimaryKeyServerResponseModel()));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCompositePrimaryKeyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCompositePrimaryKeyServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCompositePrimaryKeyServerResponseModel()));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCompositePrimaryKeyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCompositePrimaryKeyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCompositePrimaryKeyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCompositePrimaryKeyServerResponseModel>(null));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCompositePrimaryKeyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCompositePrimaryKeyServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CompositePrimaryKeyControllerMockFacade mock = new CompositePrimaryKeyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CompositePrimaryKeyController controller = new CompositePrimaryKeyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class CompositePrimaryKeyControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CompositePrimaryKeyController>> LoggerMock { get; set; } = new Mock<ILogger<CompositePrimaryKeyController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICompositePrimaryKeyService> ServiceMock { get; set; } = new Mock<ICompositePrimaryKeyService>();

		public Mock<IApiCompositePrimaryKeyServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCompositePrimaryKeyServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>f6f36d32f32570d832d551310e38e706</Hash>
</Codenesium>*/
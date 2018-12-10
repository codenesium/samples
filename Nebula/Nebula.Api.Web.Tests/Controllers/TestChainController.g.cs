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
	[Trait("Table", "Chain")]
	[Trait("Area", "Controllers")]
	public partial class ChainControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var record = new ApiChainServerResponseModel();
			var records = new List<ApiChainServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiChainServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiChainServerResponseModel>>(new List<ApiChainServerResponseModel>()));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiChainServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiChainServerResponseModel()));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiChainServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainServerResponseModel>(null));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ChainControllerMockFacade mock = new ChainControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiChainServerResponseModel>.CreateResponse(null as ApiChainServerResponseModel);

			mockResponse.SetRecord(new ApiChainServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainServerResponseModel>>(mockResponse));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiChainServerRequestModel>();
			records.Add(new ApiChainServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiChainServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiChainServerResponseModel>>(null as ApiChainServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainServerResponseModel>>(mockResponse.Object));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiChainServerRequestModel>();
			records.Add(new ApiChainServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiChainServerResponseModel>.CreateResponse(null as ApiChainServerResponseModel);

			mockResponse.SetRecord(new ApiChainServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainServerResponseModel>>(mockResponse));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiChainServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiChainServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiChainServerResponseModel>>(null as ApiChainServerResponseModel);
			var mockRecord = new ApiChainServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiChainServerResponseModel>>(mockResponse.Object));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiChainServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiChainServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()))
			.Callback<int, ApiChainServerRequestModel>(
				(id, model) => model.ChainStatusId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiChainServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainServerResponseModel>(new ApiChainServerResponseModel()));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiChainServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiChainServerRequestModel>();
			patch.Replace(x => x.ChainStatusId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainServerResponseModel>(null));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiChainServerRequestModel>();
			patch.Replace(x => x.ChainStatusId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiChainServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiChainServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiChainServerResponseModel()));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiChainServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiChainServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiChainServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiChainServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiChainServerResponseModel()));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiChainServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiChainServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiChainServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiChainServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiChainServerResponseModel>(null));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiChainServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiChainServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ChainControllerMockFacade mock = new ChainControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ChainController controller = new ChainController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ChainControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ChainController>> LoggerMock { get; set; } = new Mock<ILogger<ChainController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IChainService> ServiceMock { get; set; } = new Mock<IChainService>();

		public Mock<IApiChainServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiChainServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>cae1e3de431249f6d1210824bfe609df</Hash>
</Codenesium>*/
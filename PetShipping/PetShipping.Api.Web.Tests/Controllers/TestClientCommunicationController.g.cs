using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "Controllers")]
	public partial class ClientCommunicationControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var record = new ApiClientCommunicationServerResponseModel();
			var records = new List<ApiClientCommunicationServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiClientCommunicationServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiClientCommunicationServerResponseModel>>(new List<ApiClientCommunicationServerResponseModel>()));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiClientCommunicationServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiClientCommunicationServerResponseModel()));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiClientCommunicationServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiClientCommunicationServerResponseModel>(null));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiClientCommunicationServerResponseModel>.CreateResponse(null as ApiClientCommunicationServerResponseModel);

			mockResponse.SetRecord(new ApiClientCommunicationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiClientCommunicationServerResponseModel>>(mockResponse));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiClientCommunicationServerRequestModel>();
			records.Add(new ApiClientCommunicationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiClientCommunicationServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiClientCommunicationServerResponseModel>>(null as ApiClientCommunicationServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiClientCommunicationServerResponseModel>>(mockResponse.Object));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiClientCommunicationServerRequestModel>();
			records.Add(new ApiClientCommunicationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiClientCommunicationServerResponseModel>.CreateResponse(null as ApiClientCommunicationServerResponseModel);

			mockResponse.SetRecord(new ApiClientCommunicationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiClientCommunicationServerResponseModel>>(mockResponse));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiClientCommunicationServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiClientCommunicationServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiClientCommunicationServerResponseModel>>(null as ApiClientCommunicationServerResponseModel);
			var mockRecord = new ApiClientCommunicationServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiClientCommunicationServerResponseModel>>(mockResponse.Object));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiClientCommunicationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiClientCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>()))
			.Callback<int, ApiClientCommunicationServerRequestModel>(
				(id, model) => model.ClientId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiClientCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiClientCommunicationServerResponseModel>(new ApiClientCommunicationServerResponseModel()));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiClientCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiClientCommunicationServerRequestModel>();
			patch.Replace(x => x.ClientId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiClientCommunicationServerResponseModel>(null));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiClientCommunicationServerRequestModel>();
			patch.Replace(x => x.ClientId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiClientCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiClientCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiClientCommunicationServerResponseModel()));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiClientCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiClientCommunicationServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiClientCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiClientCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiClientCommunicationServerResponseModel()));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiClientCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiClientCommunicationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiClientCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiClientCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiClientCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiClientCommunicationServerResponseModel>(null));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiClientCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiClientCommunicationServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ClientCommunicationControllerMockFacade mock = new ClientCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ClientCommunicationController controller = new ClientCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ClientCommunicationControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ClientCommunicationController>> LoggerMock { get; set; } = new Mock<ILogger<ClientCommunicationController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IClientCommunicationService> ServiceMock { get; set; } = new Mock<IClientCommunicationService>();

		public Mock<IApiClientCommunicationServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiClientCommunicationServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>67274fe07f091e39bdd0776346314753</Hash>
</Codenesium>*/
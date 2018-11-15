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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "Controllers")]
	public partial class HandlerPipelineStepControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var record = new ApiHandlerPipelineStepServerResponseModel();
			var records = new List<ApiHandlerPipelineStepServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiHandlerPipelineStepServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiHandlerPipelineStepServerResponseModel>>(new List<ApiHandlerPipelineStepServerResponseModel>()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiHandlerPipelineStepServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepServerResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiHandlerPipelineStepServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepServerResponseModel>(null));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.CreateResponse(null as ApiHandlerPipelineStepServerResponseModel);

			mockResponse.SetRecord(new ApiHandlerPipelineStepServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResponse));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiHandlerPipelineStepServerRequestModel>();
			records.Add(new ApiHandlerPipelineStepServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiHandlerPipelineStepServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(null as ApiHandlerPipelineStepServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResponse.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiHandlerPipelineStepServerRequestModel>();
			records.Add(new ApiHandlerPipelineStepServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.CreateResponse(null as ApiHandlerPipelineStepServerResponseModel);

			mockResponse.SetRecord(new ApiHandlerPipelineStepServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResponse));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiHandlerPipelineStepServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiHandlerPipelineStepServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(null as ApiHandlerPipelineStepServerResponseModel);
			var mockRecord = new ApiHandlerPipelineStepServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResponse.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiHandlerPipelineStepServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()))
			.Callback<int, ApiHandlerPipelineStepServerRequestModel>(
				(id, model) => model.HandlerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepServerResponseModel>(new ApiHandlerPipelineStepServerResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel>();
			patch.Replace(x => x.HandlerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepServerResponseModel>(null));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel>();
			patch.Replace(x => x.HandlerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepServerResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepServerResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepServerResponseModel>(null));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class HandlerPipelineStepControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<HandlerPipelineStepController>> LoggerMock { get; set; } = new Mock<ILogger<HandlerPipelineStepController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IHandlerPipelineStepService> ServiceMock { get; set; } = new Mock<IHandlerPipelineStepService>();

		public Mock<IApiHandlerPipelineStepServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiHandlerPipelineStepServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b9ec4af24acac4c09608e2aaa1b95d7a</Hash>
</Codenesium>*/
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
			var record = new ApiHandlerPipelineStepResponseModel();
			var records = new List<ApiHandlerPipelineStepResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiHandlerPipelineStepResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiHandlerPipelineStepResponseModel>>(new List<ApiHandlerPipelineStepResponseModel>()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiHandlerPipelineStepResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiHandlerPipelineStepResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiHandlerPipelineStepResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiHandlerPipelineStepResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepResponseModel>>(mockResponse));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiHandlerPipelineStepRequestModel>();
			records.Add(new ApiHandlerPipelineStepRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiHandlerPipelineStepResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiHandlerPipelineStepResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepResponseModel>>(mockResponse.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiHandlerPipelineStepRequestModel>();
			records.Add(new ApiHandlerPipelineStepRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = new CreateResponse<ApiHandlerPipelineStepResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiHandlerPipelineStepResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepResponseModel>>(mockResponse));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiHandlerPipelineStepRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiHandlerPipelineStepResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiHandlerPipelineStepResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiHandlerPipelineStepResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiHandlerPipelineStepResponseModel>>(mockResponse.Object));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiHandlerPipelineStepRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>()))
			.Callback<int, ApiHandlerPipelineStepRequestModel>(
				(id, model) => model.HandlerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepResponseModel>(new ApiHandlerPipelineStepResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiHandlerPipelineStepRequestModel>();
			patch.Replace(x => x.HandlerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepResponseModel>(null));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiHandlerPipelineStepRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiHandlerPipelineStepResponseModel()));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			HandlerPipelineStepControllerMockFacade mock = new HandlerPipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiHandlerPipelineStepResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiHandlerPipelineStepResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiHandlerPipelineStepResponseModel>(null));
			HandlerPipelineStepController controller = new HandlerPipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiHandlerPipelineStepModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiHandlerPipelineStepRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiHandlerPipelineStepModelMapper> ModelMapperMock { get; set; } = new Mock<IApiHandlerPipelineStepModelMapper>();
	}
}

/*<Codenesium>
    <Hash>384b5b8e60a15b5eb71a50bb2d52e4a4</Hash>
</Codenesium>*/
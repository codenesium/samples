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
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "Controllers")]
	public partial class PipelineStepStatusControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var record = new ApiPipelineStepStatusServerResponseModel();
			var records = new List<ApiPipelineStepStatusServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStatusServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPipelineStepStatusServerResponseModel>>(new List<ApiPipelineStepStatusServerResponseModel>()));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStatusServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStatusServerResponseModel()));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStepStatusServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStatusServerResponseModel>(null));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepStatusServerResponseModel>.CreateResponse(null as ApiPipelineStepStatusServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepStatusServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResponse));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStatusServerRequestModel>();
			records.Add(new ApiPipelineStepStatusServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPipelineStepStatusServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(null as ApiPipelineStepStatusServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResponse.Object));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStatusServerRequestModel>();
			records.Add(new ApiPipelineStepStatusServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepStatusServerResponseModel>.CreateResponse(null as ApiPipelineStepStatusServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepStatusServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResponse));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStatusServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepStatusServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(null as ApiPipelineStepStatusServerResponseModel);
			var mockRecord = new ApiPipelineStepStatusServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResponse.Object));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStatusServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()))
			.Callback<int, ApiPipelineStepStatusServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStatusServerResponseModel>(new ApiPipelineStepStatusServerResponseModel()));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStatusServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStatusServerResponseModel>(null));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStatusServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStatusServerResponseModel()));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStatusServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStatusServerResponseModel()));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStatusServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStatusServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStatusServerResponseModel>(null));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStatusServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStatusServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepStatusControllerMockFacade mock = new PipelineStepStatusControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepStatusController controller = new PipelineStepStatusController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PipelineStepStatusControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PipelineStepStatusController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStepStatusController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPipelineStepStatusService> ServiceMock { get; set; } = new Mock<IPipelineStepStatusService>();

		public Mock<IApiPipelineStepStatusServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepStatusServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>d5464cb3a72fbf72493d7065951b7dd7</Hash>
</Codenesium>*/
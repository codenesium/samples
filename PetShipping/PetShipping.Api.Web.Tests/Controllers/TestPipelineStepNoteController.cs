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
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "Controllers")]
	public partial class PipelineStepNoteControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var record = new ApiPipelineStepNoteServerResponseModel();
			var records = new List<ApiPipelineStepNoteServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepNoteServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPipelineStepNoteServerResponseModel>>(new List<ApiPipelineStepNoteServerResponseModel>()));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepNoteServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepNoteServerResponseModel()));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStepNoteServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepNoteServerResponseModel>(null));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepNoteServerResponseModel>.CreateResponse(null as ApiPipelineStepNoteServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepNoteServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResponse));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepNoteServerRequestModel>();
			records.Add(new ApiPipelineStepNoteServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPipelineStepNoteServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(null as ApiPipelineStepNoteServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResponse.Object));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepNoteServerRequestModel>();
			records.Add(new ApiPipelineStepNoteServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepNoteServerResponseModel>.CreateResponse(null as ApiPipelineStepNoteServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepNoteServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResponse));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepNoteServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepNoteServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(null as ApiPipelineStepNoteServerResponseModel);
			var mockRecord = new ApiPipelineStepNoteServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResponse.Object));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepNoteServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()))
			.Callback<int, ApiPipelineStepNoteServerRequestModel>(
				(id, model) => model.EmployeeId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepNoteServerResponseModel>(new ApiPipelineStepNoteServerResponseModel()));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepNoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepNoteServerRequestModel>();
			patch.Replace(x => x.EmployeeId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepNoteServerResponseModel>(null));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepNoteServerRequestModel>();
			patch.Replace(x => x.EmployeeId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepNoteServerResponseModel()));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepNoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepNoteServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepNoteServerResponseModel()));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepNoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepNoteServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepNoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepNoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepNoteServerResponseModel>(null));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepNoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepNoteServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepNoteControllerMockFacade mock = new PipelineStepNoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepNoteController controller = new PipelineStepNoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PipelineStepNoteControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PipelineStepNoteController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStepNoteController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPipelineStepNoteService> ServiceMock { get; set; } = new Mock<IPipelineStepNoteService>();

		public Mock<IApiPipelineStepNoteServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepNoteServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>0eb6a8b388cc9e9c063aa185fec6f29c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
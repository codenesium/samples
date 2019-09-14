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
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "Controllers")]
	public partial class PipelineStepStepRequirementControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var record = new ApiPipelineStepStepRequirementServerResponseModel();
			var records = new List<ApiPipelineStepStepRequirementServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStepRequirementServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPipelineStepStepRequirementServerResponseModel>>(new List<ApiPipelineStepStepRequirementServerResponseModel>()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStepRequirementServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementServerResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStepStepRequirementServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementServerResponseModel>(null));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.CreateResponse(null as ApiPipelineStepStepRequirementServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepStepRequirementServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResponse));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStepRequirementServerRequestModel>();
			records.Add(new ApiPipelineStepStepRequirementServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPipelineStepStepRequirementServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(null as ApiPipelineStepStepRequirementServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResponse.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStepRequirementServerRequestModel>();
			records.Add(new ApiPipelineStepStepRequirementServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.CreateResponse(null as ApiPipelineStepStepRequirementServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepStepRequirementServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResponse));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStepRequirementServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(null as ApiPipelineStepStepRequirementServerResponseModel);
			var mockRecord = new ApiPipelineStepStepRequirementServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResponse.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStepRequirementServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()))
			.Callback<int, ApiPipelineStepStepRequirementServerRequestModel>(
				(id, model) => model.Details.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementServerResponseModel>(new ApiPipelineStepStepRequirementServerResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel>();
			patch.Replace(x => x.Details, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementServerResponseModel>(null));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel>();
			patch.Replace(x => x.Details, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementServerResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementServerResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementServerResponseModel>(null));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PipelineStepStepRequirementControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PipelineStepStepRequirementController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStepStepRequirementController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPipelineStepStepRequirementService> ServiceMock { get; set; } = new Mock<IPipelineStepStepRequirementService>();

		public Mock<IApiPipelineStepStepRequirementServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepStepRequirementServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>a1e25fd7370db4a219c7213422c454f4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
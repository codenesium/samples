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
			var record = new ApiPipelineStepStepRequirementResponseModel();
			var records = new List<ApiPipelineStepStepRequirementResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStepRequirementResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPipelineStepStepRequirementResponseModel>>(new List<ApiPipelineStepStepRequirementResponseModel>()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepStepRequirementResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStepStepRequirementResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiPipelineStepStepRequirementResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPipelineStepStepRequirementResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResponse));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStepRequirementRequestModel>();
			records.Add(new ApiPipelineStepStepRequirementRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiPipelineStepStepRequirementResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResponse.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepStepRequirementRequestModel>();
			records.Add(new ApiPipelineStepStepRequirementRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPipelineStepStepRequirementResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPipelineStepStepRequirementResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResponse));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStepRequirementRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepStepRequirementResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiPipelineStepStepRequirementResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResponse.Object));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepStepRequirementRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>()))
			.Callback<int, ApiPipelineStepStepRequirementRequestModel>(
				(id, model) => model.Details.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementResponseModel>(new ApiPipelineStepStepRequirementResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel>();
			patch.Replace(x => x.Details, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementResponseModel>(null));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepStepRequirementResponseModel()));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStepStepRequirementControllerMockFacade mock = new PipelineStepStepRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepStepRequirementRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepStepRequirementResponseModel>(null));
			PipelineStepStepRequirementController controller = new PipelineStepStepRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepStepRequirementModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepStepRequirementRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiPipelineStepStepRequirementModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepStepRequirementModelMapper>();
	}
}

/*<Codenesium>
    <Hash>d927cbdd7f8c54523c473bdfe0f4a54e</Hash>
</Codenesium>*/
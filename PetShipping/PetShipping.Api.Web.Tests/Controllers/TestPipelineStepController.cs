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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "Controllers")]
	public partial class PipelineStepControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var record = new ApiPipelineStepServerResponseModel();
			var records = new List<ApiPipelineStepServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPipelineStepServerResponseModel>>(new List<ApiPipelineStepServerResponseModel>()));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStepServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepServerResponseModel()));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStepServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepServerResponseModel>(null));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepServerResponseModel>.CreateResponse(null as ApiPipelineStepServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepServerResponseModel>>(mockResponse));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepServerRequestModel>();
			records.Add(new ApiPipelineStepServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPipelineStepServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepServerResponseModel>>(null as ApiPipelineStepServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepServerResponseModel>>(mockResponse.Object));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStepServerRequestModel>();
			records.Add(new ApiPipelineStepServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStepServerResponseModel>.CreateResponse(null as ApiPipelineStepServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStepServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepServerResponseModel>>(mockResponse));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStepServerResponseModel>>(null as ApiPipelineStepServerResponseModel);
			var mockRecord = new ApiPipelineStepServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepServerResponseModel>>(mockResponse.Object));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStepServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()))
			.Callback<int, ApiPipelineStepServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepServerResponseModel>(new ApiPipelineStepServerResponseModel()));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepServerResponseModel>(null));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStepServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepServerResponseModel()));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepServerResponseModel()));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStepServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepServerResponseModel>(null));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStepServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStepControllerMockFacade mock = new PipelineStepControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStepController controller = new PipelineStepController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PipelineStepControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PipelineStepController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStepController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPipelineStepService> ServiceMock { get; set; } = new Mock<IPipelineStepService>();

		public Mock<IApiPipelineStepServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>05092bb7f4c661143d525fa08f3804c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
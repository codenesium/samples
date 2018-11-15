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
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Controllers")]
	public partial class PipelineStatuControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var record = new ApiPipelineStatuServerResponseModel();
			var records = new List<ApiPipelineStatuServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStatuServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPipelineStatuServerResponseModel>>(new List<ApiPipelineStatuServerResponseModel>()));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPipelineStatuServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStatuServerResponseModel()));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPipelineStatuServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStatuServerResponseModel>(null));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.CreateResponse(null as ApiPipelineStatuServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStatuServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStatuServerResponseModel>>(mockResponse));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStatuServerRequestModel>();
			records.Add(new ApiPipelineStatuServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPipelineStatuServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStatuServerResponseModel>>(null as ApiPipelineStatuServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStatuServerResponseModel>>(mockResponse.Object));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPipelineStatuServerRequestModel>();
			records.Add(new ApiPipelineStatuServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.CreateResponse(null as ApiPipelineStatuServerResponseModel);

			mockResponse.SetRecord(new ApiPipelineStatuServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStatuServerResponseModel>>(mockResponse));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStatuServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStatuServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPipelineStatuServerResponseModel>>(null as ApiPipelineStatuServerResponseModel);
			var mockRecord = new ApiPipelineStatuServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStatuServerResponseModel>>(mockResponse.Object));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPipelineStatuServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>()))
			.Callback<int, ApiPipelineStatuServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPipelineStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStatuServerResponseModel>(new ApiPipelineStatuServerResponseModel()));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStatuServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStatuServerResponseModel>(null));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPipelineStatuServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStatuServerResponseModel()));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStatuServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStatuServerResponseModel()));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStatuServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPipelineStatuServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStatuServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStatuServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStatuServerResponseModel>(null));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStatuServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPipelineStatuServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PipelineStatuControllerMockFacade mock = new PipelineStatuControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PipelineStatuController controller = new PipelineStatuController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PipelineStatuControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PipelineStatuController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStatuController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPipelineStatuService> ServiceMock { get; set; } = new Mock<IPipelineStatuService>();

		public Mock<IApiPipelineStatuServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStatuServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>90249e982cb1756050a6b2dbf9bc26ae</Hash>
</Codenesium>*/
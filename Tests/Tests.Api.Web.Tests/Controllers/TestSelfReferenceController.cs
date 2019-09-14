using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Controllers")]
	public partial class SelfReferenceControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var record = new ApiSelfReferenceServerResponseModel();
			var records = new List<ApiSelfReferenceServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSelfReferenceServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiSelfReferenceServerResponseModel>>(new List<ApiSelfReferenceServerResponseModel>()));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSelfReferenceServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSelfReferenceServerResponseModel()));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSelfReferenceServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSelfReferenceServerResponseModel>(null));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.CreateResponse(null as ApiSelfReferenceServerResponseModel);

			mockResponse.SetRecord(new ApiSelfReferenceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSelfReferenceServerResponseModel>>(mockResponse));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSelfReferenceServerRequestModel>();
			records.Add(new ApiSelfReferenceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSelfReferenceServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSelfReferenceServerResponseModel>>(null as ApiSelfReferenceServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSelfReferenceServerResponseModel>>(mockResponse.Object));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSelfReferenceServerRequestModel>();
			records.Add(new ApiSelfReferenceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.CreateResponse(null as ApiSelfReferenceServerResponseModel);

			mockResponse.SetRecord(new ApiSelfReferenceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSelfReferenceServerResponseModel>>(mockResponse));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSelfReferenceServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSelfReferenceServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSelfReferenceServerResponseModel>>(null as ApiSelfReferenceServerResponseModel);
			var mockRecord = new ApiSelfReferenceServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSelfReferenceServerResponseModel>>(mockResponse.Object));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSelfReferenceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSelfReferenceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()))
			.Callback<int, ApiSelfReferenceServerRequestModel>(
				(id, model) => model.SelfReferenceId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSelfReferenceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSelfReferenceServerResponseModel>(new ApiSelfReferenceServerResponseModel()));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSelfReferenceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSelfReferenceServerRequestModel>();
			patch.Replace(x => x.SelfReferenceId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSelfReferenceServerResponseModel>(null));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSelfReferenceServerRequestModel>();
			patch.Replace(x => x.SelfReferenceId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSelfReferenceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSelfReferenceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSelfReferenceServerResponseModel()));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSelfReferenceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSelfReferenceServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSelfReferenceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSelfReferenceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSelfReferenceServerResponseModel()));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSelfReferenceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSelfReferenceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSelfReferenceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSelfReferenceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSelfReferenceServerResponseModel>(null));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSelfReferenceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSelfReferenceServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SelfReferenceControllerMockFacade mock = new SelfReferenceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SelfReferenceController controller = new SelfReferenceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SelfReferenceControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SelfReferenceController>> LoggerMock { get; set; } = new Mock<ILogger<SelfReferenceController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISelfReferenceService> ServiceMock { get; set; } = new Mock<ISelfReferenceService>();

		public Mock<IApiSelfReferenceServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSelfReferenceServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5f3fca47da7db86b01331eef1356c30a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
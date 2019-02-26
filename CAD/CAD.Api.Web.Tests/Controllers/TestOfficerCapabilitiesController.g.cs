using CADNS.Api.Contracts;
using CADNS.Api.Services;
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
using Xunit;

namespace CADNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "Controllers")]
	public partial class OfficerCapabilitiesControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var record = new ApiOfficerCapabilitiesServerResponseModel();
			var records = new List<ApiOfficerCapabilitiesServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerCapabilitiesServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiOfficerCapabilitiesServerResponseModel>>(new List<ApiOfficerCapabilitiesServerResponseModel>()));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerCapabilitiesServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilitiesServerResponseModel()));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiOfficerCapabilitiesServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilitiesServerResponseModel>(null));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerCapabilitiesServerResponseModel>.CreateResponse(null as ApiOfficerCapabilitiesServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerCapabilitiesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResponse));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerCapabilitiesServerRequestModel>();
			records.Add(new ApiOfficerCapabilitiesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiOfficerCapabilitiesServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(null as ApiOfficerCapabilitiesServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResponse.Object));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerCapabilitiesServerRequestModel>();
			records.Add(new ApiOfficerCapabilitiesServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerCapabilitiesServerResponseModel>.CreateResponse(null as ApiOfficerCapabilitiesServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerCapabilitiesServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResponse));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerCapabilitiesServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiOfficerCapabilitiesServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(null as ApiOfficerCapabilitiesServerResponseModel);
			var mockRecord = new ApiOfficerCapabilitiesServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResponse.Object));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerCapabilitiesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()))
			.Callback<int, ApiOfficerCapabilitiesServerRequestModel>(
				(id, model) => model.OfficerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilitiesServerResponseModel>(new ApiOfficerCapabilitiesServerResponseModel()));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilitiesServerResponseModel>(null));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilitiesServerResponseModel()));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilitiesServerResponseModel()));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilitiesServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilitiesServerResponseModel>(null));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilitiesServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilitiesServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerCapabilitiesControllerMockFacade mock = new OfficerCapabilitiesControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerCapabilitiesController controller = new OfficerCapabilitiesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class OfficerCapabilitiesControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<OfficerCapabilitiesController>> LoggerMock { get; set; } = new Mock<ILogger<OfficerCapabilitiesController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IOfficerCapabilitiesService> ServiceMock { get; set; } = new Mock<IOfficerCapabilitiesService>();

		public Mock<IApiOfficerCapabilitiesServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiOfficerCapabilitiesServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>875c2e93d95e6473579b4deeda77d000</Hash>
</Codenesium>*/
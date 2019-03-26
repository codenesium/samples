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
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "Controllers")]
	public partial class OfficerCapabilityControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var record = new ApiOfficerCapabilityServerResponseModel();
			var records = new List<ApiOfficerCapabilityServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerCapabilityServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiOfficerCapabilityServerResponseModel>>(new List<ApiOfficerCapabilityServerResponseModel>()));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerCapabilityServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilityServerResponseModel()));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiOfficerCapabilityServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilityServerResponseModel>(null));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerCapabilityServerResponseModel>.CreateResponse(null as ApiOfficerCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResponse));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerCapabilityServerRequestModel>();
			records.Add(new ApiOfficerCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiOfficerCapabilityServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(null as ApiOfficerCapabilityServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResponse.Object));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerCapabilityServerRequestModel>();
			records.Add(new ApiOfficerCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerCapabilityServerResponseModel>.CreateResponse(null as ApiOfficerCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResponse));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerCapabilityServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiOfficerCapabilityServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(null as ApiOfficerCapabilityServerResponseModel);
			var mockRecord = new ApiOfficerCapabilityServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResponse.Object));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()))
			.Callback<int, ApiOfficerCapabilityServerRequestModel>(
				(id, model) => model.OfficerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilityServerResponseModel>(new ApiOfficerCapabilityServerResponseModel()));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerCapabilityServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilityServerResponseModel>(null));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerCapabilityServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilityServerResponseModel()));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilityServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerCapabilityServerResponseModel()));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerCapabilityServerResponseModel>(null));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerCapabilityServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerCapabilityControllerMockFacade mock = new OfficerCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerCapabilityController controller = new OfficerCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class OfficerCapabilityControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<OfficerCapabilityController>> LoggerMock { get; set; } = new Mock<ILogger<OfficerCapabilityController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IOfficerCapabilityService> ServiceMock { get; set; } = new Mock<IOfficerCapabilityService>();

		public Mock<IApiOfficerCapabilityServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiOfficerCapabilityServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>c2f0d8044f516f478f35065e0478202c</Hash>
</Codenesium>*/
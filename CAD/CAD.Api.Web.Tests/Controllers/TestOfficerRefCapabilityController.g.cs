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
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "Controllers")]
	public partial class OfficerRefCapabilityControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var record = new ApiOfficerRefCapabilityServerResponseModel();
			var records = new List<ApiOfficerRefCapabilityServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerRefCapabilityServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiOfficerRefCapabilityServerResponseModel>>(new List<ApiOfficerRefCapabilityServerResponseModel>()));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiOfficerRefCapabilityServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerRefCapabilityServerResponseModel()));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiOfficerRefCapabilityServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerRefCapabilityServerResponseModel>(null));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerRefCapabilityServerResponseModel>.CreateResponse(null as ApiOfficerRefCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerRefCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResponse));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerRefCapabilityServerRequestModel>();
			records.Add(new ApiOfficerRefCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiOfficerRefCapabilityServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(null as ApiOfficerRefCapabilityServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResponse.Object));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiOfficerRefCapabilityServerRequestModel>();
			records.Add(new ApiOfficerRefCapabilityServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiOfficerRefCapabilityServerResponseModel>.CreateResponse(null as ApiOfficerRefCapabilityServerResponseModel);

			mockResponse.SetRecord(new ApiOfficerRefCapabilityServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResponse));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerRefCapabilityServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiOfficerRefCapabilityServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(null as ApiOfficerRefCapabilityServerResponseModel);
			var mockRecord = new ApiOfficerRefCapabilityServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResponse.Object));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiOfficerRefCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()))
			.Callback<int, ApiOfficerRefCapabilityServerRequestModel>(
				(id, model) => model.CapabilityId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerRefCapabilityServerResponseModel>(new ApiOfficerRefCapabilityServerResponseModel()));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerRefCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel>();
			patch.Replace(x => x.CapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerRefCapabilityServerResponseModel>(null));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel>();
			patch.Replace(x => x.CapabilityId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerRefCapabilityServerResponseModel()));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerRefCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiOfficerRefCapabilityServerResponseModel()));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerRefCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiOfficerRefCapabilityServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiOfficerRefCapabilityServerResponseModel>(null));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiOfficerRefCapabilityServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiOfficerRefCapabilityServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			OfficerRefCapabilityControllerMockFacade mock = new OfficerRefCapabilityControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			OfficerRefCapabilityController controller = new OfficerRefCapabilityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class OfficerRefCapabilityControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<OfficerRefCapabilityController>> LoggerMock { get; set; } = new Mock<ILogger<OfficerRefCapabilityController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IOfficerRefCapabilityService> ServiceMock { get; set; } = new Mock<IOfficerRefCapabilityService>();

		public Mock<IApiOfficerRefCapabilityServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiOfficerRefCapabilityServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>90de8893a5f7a818a6a20f224ea8933b</Hash>
</Codenesium>*/
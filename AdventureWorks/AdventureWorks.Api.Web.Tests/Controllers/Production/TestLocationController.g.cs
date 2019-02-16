using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "Controllers")]
	public partial class LocationControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var record = new ApiLocationServerResponseModel();
			var records = new List<ApiLocationServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiLocationServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiLocationServerResponseModel>>(new List<ApiLocationServerResponseModel>()));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiLocationServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ApiLocationServerResponseModel()));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(short));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiLocationServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiLocationServerResponseModel>(null));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(short));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiLocationServerResponseModel>.CreateResponse(null as ApiLocationServerResponseModel);

			mockResponse.SetRecord(new ApiLocationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLocationServerResponseModel>>(mockResponse));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiLocationServerRequestModel>();
			records.Add(new ApiLocationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiLocationServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiLocationServerResponseModel>>(null as ApiLocationServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLocationServerResponseModel>>(mockResponse.Object));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiLocationServerRequestModel>();
			records.Add(new ApiLocationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiLocationServerResponseModel>.CreateResponse(null as ApiLocationServerResponseModel);

			mockResponse.SetRecord(new ApiLocationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLocationServerResponseModel>>(mockResponse));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiLocationServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiLocationServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiLocationServerResponseModel>>(null as ApiLocationServerResponseModel);
			var mockRecord = new ApiLocationServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiLocationServerResponseModel>>(mockResponse.Object));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiLocationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiLocationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()))
			.Callback<short, ApiLocationServerRequestModel>(
				(id, model) => model.Availability.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiLocationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiLocationServerResponseModel>(new ApiLocationServerResponseModel()));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLocationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiLocationServerRequestModel>();
			patch.Replace(x => x.Availability, 1);

			IActionResult response = await controller.Patch(default(short), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiLocationServerResponseModel>(null));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiLocationServerRequestModel>();
			patch.Replace(x => x.Availability, 1);

			IActionResult response = await controller.Patch(default(short), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiLocationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLocationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ApiLocationServerResponseModel()));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLocationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(short), new ApiLocationServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiLocationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLocationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ApiLocationServerResponseModel()));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLocationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(short), new ApiLocationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiLocationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<short>(), It.IsAny<ApiLocationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiLocationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ApiLocationServerResponseModel>(null));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiLocationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(short), new ApiLocationServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(short));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<short>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			LocationControllerMockFacade mock = new LocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			LocationController controller = new LocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(short));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<short>()));
		}
	}

	public class LocationControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<LocationController>> LoggerMock { get; set; } = new Mock<ILogger<LocationController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ILocationService> ServiceMock { get; set; } = new Mock<ILocationService>();

		public Mock<IApiLocationServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiLocationServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5d29021a65c26556f2e02ef6f4894a63</Hash>
</Codenesium>*/
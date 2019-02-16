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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Controllers")]
	public partial class IncludedColumnTestControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var record = new ApiIncludedColumnTestServerResponseModel();
			var records = new List<ApiIncludedColumnTestServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiIncludedColumnTestServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiIncludedColumnTestServerResponseModel>>(new List<ApiIncludedColumnTestServerResponseModel>()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiIncludedColumnTestServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestServerResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiIncludedColumnTestServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestServerResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.CreateResponse(null as ApiIncludedColumnTestServerResponseModel);

			mockResponse.SetRecord(new ApiIncludedColumnTestServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResponse));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiIncludedColumnTestServerRequestModel>();
			records.Add(new ApiIncludedColumnTestServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiIncludedColumnTestServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(null as ApiIncludedColumnTestServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResponse.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiIncludedColumnTestServerRequestModel>();
			records.Add(new ApiIncludedColumnTestServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.CreateResponse(null as ApiIncludedColumnTestServerResponseModel);

			mockResponse.SetRecord(new ApiIncludedColumnTestServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResponse));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiIncludedColumnTestServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiIncludedColumnTestServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(null as ApiIncludedColumnTestServerResponseModel);
			var mockRecord = new ApiIncludedColumnTestServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResponse.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiIncludedColumnTestServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()))
			.Callback<int, ApiIncludedColumnTestServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestServerResponseModel>(new ApiIncludedColumnTestServerResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiIncludedColumnTestServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestServerResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiIncludedColumnTestServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestServerResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestServerResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestServerResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class IncludedColumnTestControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<IncludedColumnTestController>> LoggerMock { get; set; } = new Mock<ILogger<IncludedColumnTestController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IIncludedColumnTestService> ServiceMock { get; set; } = new Mock<IIncludedColumnTestService>();

		public Mock<IApiIncludedColumnTestServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiIncludedColumnTestServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>fdff446b64ec7ea0350502d662ec2035</Hash>
</Codenesium>*/
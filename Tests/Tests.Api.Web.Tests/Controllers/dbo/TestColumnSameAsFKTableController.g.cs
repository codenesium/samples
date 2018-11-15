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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Controllers")]
	public partial class ColumnSameAsFKTableControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var record = new ApiColumnSameAsFKTableServerResponseModel();
			var records = new List<ApiColumnSameAsFKTableServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiColumnSameAsFKTableServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiColumnSameAsFKTableServerResponseModel>>(new List<ApiColumnSameAsFKTableServerResponseModel>()));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiColumnSameAsFKTableServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiColumnSameAsFKTableServerResponseModel()));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiColumnSameAsFKTableServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiColumnSameAsFKTableServerResponseModel>(null));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.CreateResponse(null as ApiColumnSameAsFKTableServerResponseModel);

			mockResponse.SetRecord(new ApiColumnSameAsFKTableServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResponse));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiColumnSameAsFKTableServerRequestModel>();
			records.Add(new ApiColumnSameAsFKTableServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiColumnSameAsFKTableServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(null as ApiColumnSameAsFKTableServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResponse.Object));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiColumnSameAsFKTableServerRequestModel>();
			records.Add(new ApiColumnSameAsFKTableServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.CreateResponse(null as ApiColumnSameAsFKTableServerResponseModel);

			mockResponse.SetRecord(new ApiColumnSameAsFKTableServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResponse));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiColumnSameAsFKTableServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiColumnSameAsFKTableServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(null as ApiColumnSameAsFKTableServerResponseModel);
			var mockRecord = new ApiColumnSameAsFKTableServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResponse.Object));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiColumnSameAsFKTableServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()))
			.Callback<int, ApiColumnSameAsFKTableServerRequestModel>(
				(id, model) => model.Person.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiColumnSameAsFKTableServerResponseModel>(new ApiColumnSameAsFKTableServerResponseModel()));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiColumnSameAsFKTableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel>();
			patch.Replace(x => x.Person, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiColumnSameAsFKTableServerResponseModel>(null));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel>();
			patch.Replace(x => x.Person, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiColumnSameAsFKTableServerResponseModel()));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiColumnSameAsFKTableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiColumnSameAsFKTableServerResponseModel()));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiColumnSameAsFKTableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiColumnSameAsFKTableServerResponseModel>(null));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiColumnSameAsFKTableServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiColumnSameAsFKTableServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ColumnSameAsFKTableControllerMockFacade mock = new ColumnSameAsFKTableControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ColumnSameAsFKTableController controller = new ColumnSameAsFKTableController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class ColumnSameAsFKTableControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ColumnSameAsFKTableController>> LoggerMock { get; set; } = new Mock<ILogger<ColumnSameAsFKTableController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IColumnSameAsFKTableService> ServiceMock { get; set; } = new Mock<IColumnSameAsFKTableService>();

		public Mock<IApiColumnSameAsFKTableServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiColumnSameAsFKTableServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3f407b12d657a13559dc057152b3654d</Hash>
</Codenesium>*/
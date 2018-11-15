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
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Controllers")]
	public partial class SalesOrderHeaderControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var record = new ApiSalesOrderHeaderServerResponseModel();
			var records = new List<ApiSalesOrderHeaderServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesOrderHeaderServerResponseModel>>(new List<ApiSalesOrderHeaderServerResponseModel>()));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderServerResponseModel()));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSalesOrderHeaderServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderServerResponseModel>(null));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.CreateResponse(null as ApiSalesOrderHeaderServerResponseModel);

			mockResponse.SetRecord(new ApiSalesOrderHeaderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResponse));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesOrderHeaderServerRequestModel>();
			records.Add(new ApiSalesOrderHeaderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSalesOrderHeaderServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(null as ApiSalesOrderHeaderServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResponse.Object));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesOrderHeaderServerRequestModel>();
			records.Add(new ApiSalesOrderHeaderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.CreateResponse(null as ApiSalesOrderHeaderServerResponseModel);

			mockResponse.SetRecord(new ApiSalesOrderHeaderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResponse));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesOrderHeaderServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesOrderHeaderServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(null as ApiSalesOrderHeaderServerResponseModel);
			var mockRecord = new ApiSalesOrderHeaderServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResponse.Object));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesOrderHeaderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>()))
			.Callback<int, ApiSalesOrderHeaderServerRequestModel>(
				(id, model) => model.AccountNumber.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderServerResponseModel>(new ApiSalesOrderHeaderServerResponseModel()));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel>();
			patch.Replace(x => x.AccountNumber, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderServerResponseModel>(null));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel>();
			patch.Replace(x => x.AccountNumber, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderServerResponseModel()));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderServerResponseModel()));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderServerResponseModel>(null));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesOrderHeaderControllerMockFacade mock = new SalesOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesOrderHeaderController controller = new SalesOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SalesOrderHeaderControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SalesOrderHeaderController>> LoggerMock { get; set; } = new Mock<ILogger<SalesOrderHeaderController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISalesOrderHeaderService> ServiceMock { get; set; } = new Mock<ISalesOrderHeaderService>();

		public Mock<IApiSalesOrderHeaderServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesOrderHeaderServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>816c5c235257eb42e6dc395c09c49b20</Hash>
</Codenesium>*/
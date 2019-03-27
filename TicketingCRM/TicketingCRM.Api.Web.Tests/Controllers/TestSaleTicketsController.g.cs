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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "Controllers")]
	public partial class SaleTicketsControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var record = new ApiSaleTicketsServerResponseModel();
			var records = new List<ApiSaleTicketsServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSaleTicketsServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiSaleTicketsServerResponseModel>>(new List<ApiSaleTicketsServerResponseModel>()));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSaleTicketsServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketsServerResponseModel()));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSaleTicketsServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketsServerResponseModel>(null));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSaleTicketsServerResponseModel>.CreateResponse(null as ApiSaleTicketsServerResponseModel);

			mockResponse.SetRecord(new ApiSaleTicketsServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketsServerResponseModel>>(mockResponse));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSaleTicketsServerRequestModel>();
			records.Add(new ApiSaleTicketsServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSaleTicketsServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSaleTicketsServerResponseModel>>(null as ApiSaleTicketsServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketsServerResponseModel>>(mockResponse.Object));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSaleTicketsServerRequestModel>();
			records.Add(new ApiSaleTicketsServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSaleTicketsServerResponseModel>.CreateResponse(null as ApiSaleTicketsServerResponseModel);

			mockResponse.SetRecord(new ApiSaleTicketsServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketsServerResponseModel>>(mockResponse));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSaleTicketsServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSaleTicketsServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSaleTicketsServerResponseModel>>(null as ApiSaleTicketsServerResponseModel);
			var mockRecord = new ApiSaleTicketsServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketsServerResponseModel>>(mockResponse.Object));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSaleTicketsServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketsServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()))
			.Callback<int, ApiSaleTicketsServerRequestModel>(
				(id, model) => model.SaleId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSaleTicketsServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketsServerResponseModel>(new ApiSaleTicketsServerResponseModel()));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketsServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSaleTicketsServerRequestModel>();
			patch.Replace(x => x.SaleId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketsServerResponseModel>(null));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSaleTicketsServerRequestModel>();
			patch.Replace(x => x.SaleId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketsServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketsServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketsServerResponseModel()));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketsServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketsServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketsServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketsServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketsServerResponseModel()));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketsServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketsServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketsServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketsServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketsServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketsServerResponseModel>(null));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketsServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketsServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SaleTicketsControllerMockFacade mock = new SaleTicketsControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SaleTicketsController controller = new SaleTicketsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SaleTicketsControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SaleTicketsController>> LoggerMock { get; set; } = new Mock<ILogger<SaleTicketsController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISaleTicketsService> ServiceMock { get; set; } = new Mock<ISaleTicketsService>();

		public Mock<IApiSaleTicketsServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSaleTicketsServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>1f5347e5800ee7e1d3ab6e58bd51ac85</Hash>
</Codenesium>*/
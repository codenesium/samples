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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Controllers")]
	public partial class SaleTicketControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var record = new ApiSaleTicketServerResponseModel();
			var records = new List<ApiSaleTicketServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSaleTicketServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiSaleTicketServerResponseModel>>(new List<ApiSaleTicketServerResponseModel>()));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSaleTicketServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketServerResponseModel()));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSaleTicketServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketServerResponseModel>(null));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSaleTicketServerResponseModel>.CreateResponse(null as ApiSaleTicketServerResponseModel);

			mockResponse.SetRecord(new ApiSaleTicketServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketServerResponseModel>>(mockResponse));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSaleTicketServerRequestModel>();
			records.Add(new ApiSaleTicketServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSaleTicketServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSaleTicketServerResponseModel>>(null as ApiSaleTicketServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketServerResponseModel>>(mockResponse.Object));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSaleTicketServerRequestModel>();
			records.Add(new ApiSaleTicketServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSaleTicketServerResponseModel>.CreateResponse(null as ApiSaleTicketServerResponseModel);

			mockResponse.SetRecord(new ApiSaleTicketServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketServerResponseModel>>(mockResponse));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSaleTicketServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSaleTicketServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSaleTicketServerResponseModel>>(null as ApiSaleTicketServerResponseModel);
			var mockRecord = new ApiSaleTicketServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSaleTicketServerResponseModel>>(mockResponse.Object));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSaleTicketServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()))
			.Callback<int, ApiSaleTicketServerRequestModel>(
				(id, model) => model.SaleId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSaleTicketServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketServerResponseModel>(new ApiSaleTicketServerResponseModel()));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSaleTicketServerRequestModel>();
			patch.Replace(x => x.SaleId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketServerResponseModel>(null));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSaleTicketServerRequestModel>();
			patch.Replace(x => x.SaleId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketServerResponseModel()));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSaleTicketServerResponseModel()));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSaleTicketServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSaleTicketServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSaleTicketServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSaleTicketServerResponseModel>(null));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSaleTicketServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSaleTicketServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SaleTicketControllerMockFacade mock = new SaleTicketControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SaleTicketController controller = new SaleTicketController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SaleTicketControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SaleTicketController>> LoggerMock { get; set; } = new Mock<ILogger<SaleTicketController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISaleTicketService> ServiceMock { get; set; } = new Mock<ISaleTicketService>();

		public Mock<IApiSaleTicketServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSaleTicketServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5fe06bc62d87f5b725dbebd725fa0f26</Hash>
</Codenesium>*/
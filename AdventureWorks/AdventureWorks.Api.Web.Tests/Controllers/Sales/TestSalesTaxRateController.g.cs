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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Controllers")]
	public partial class SalesTaxRateControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var record = new ApiSalesTaxRateServerResponseModel();
			var records = new List<ApiSalesTaxRateServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesTaxRateServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiSalesTaxRateServerResponseModel>>(new List<ApiSalesTaxRateServerResponseModel>()));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesTaxRateServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTaxRateServerResponseModel()));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSalesTaxRateServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTaxRateServerResponseModel>(null));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesTaxRateServerResponseModel>.CreateResponse(null as ApiSalesTaxRateServerResponseModel);

			mockResponse.SetRecord(new ApiSalesTaxRateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTaxRateServerResponseModel>>(mockResponse));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesTaxRateServerRequestModel>();
			records.Add(new ApiSalesTaxRateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSalesTaxRateServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesTaxRateServerResponseModel>>(null as ApiSalesTaxRateServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTaxRateServerResponseModel>>(mockResponse.Object));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesTaxRateServerRequestModel>();
			records.Add(new ApiSalesTaxRateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesTaxRateServerResponseModel>.CreateResponse(null as ApiSalesTaxRateServerResponseModel);

			mockResponse.SetRecord(new ApiSalesTaxRateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTaxRateServerResponseModel>>(mockResponse));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesTaxRateServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesTaxRateServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesTaxRateServerResponseModel>>(null as ApiSalesTaxRateServerResponseModel);
			var mockRecord = new ApiSalesTaxRateServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTaxRateServerResponseModel>>(mockResponse.Object));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesTaxRateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTaxRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()))
			.Callback<int, ApiSalesTaxRateServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSalesTaxRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTaxRateServerResponseModel>(new ApiSalesTaxRateServerResponseModel()));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTaxRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesTaxRateServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTaxRateServerResponseModel>(null));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesTaxRateServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTaxRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTaxRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTaxRateServerResponseModel()));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTaxRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTaxRateServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTaxRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTaxRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTaxRateServerResponseModel()));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTaxRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTaxRateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTaxRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTaxRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTaxRateServerResponseModel>(null));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTaxRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTaxRateServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesTaxRateControllerMockFacade mock = new SalesTaxRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesTaxRateController controller = new SalesTaxRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SalesTaxRateControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SalesTaxRateController>> LoggerMock { get; set; } = new Mock<ILogger<SalesTaxRateController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISalesTaxRateService> ServiceMock { get; set; } = new Mock<ISalesTaxRateService>();

		public Mock<IApiSalesTaxRateServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesTaxRateServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>52e4f79c26a0f60ff192f99f70e3defe</Hash>
</Codenesium>*/
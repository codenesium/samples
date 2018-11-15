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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Controllers")]
	public partial class SalesTerritoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var record = new ApiSalesTerritoryServerResponseModel();
			var records = new List<ApiSalesTerritoryServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesTerritoryServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesTerritoryServerResponseModel>>(new List<ApiSalesTerritoryServerResponseModel>()));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesTerritoryServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTerritoryServerResponseModel()));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSalesTerritoryServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTerritoryServerResponseModel>(null));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.CreateResponse(null as ApiSalesTerritoryServerResponseModel);

			mockResponse.SetRecord(new ApiSalesTerritoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryServerResponseModel>>(mockResponse));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesTerritoryServerRequestModel>();
			records.Add(new ApiSalesTerritoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSalesTerritoryServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesTerritoryServerResponseModel>>(null as ApiSalesTerritoryServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryServerResponseModel>>(mockResponse.Object));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesTerritoryServerRequestModel>();
			records.Add(new ApiSalesTerritoryServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.CreateResponse(null as ApiSalesTerritoryServerResponseModel);

			mockResponse.SetRecord(new ApiSalesTerritoryServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryServerResponseModel>>(mockResponse));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesTerritoryServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesTerritoryServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesTerritoryServerResponseModel>>(null as ApiSalesTerritoryServerResponseModel);
			var mockRecord = new ApiSalesTerritoryServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesTerritoryServerResponseModel>>(mockResponse.Object));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesTerritoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTerritoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>()))
			.Callback<int, ApiSalesTerritoryServerRequestModel>(
				(id, model) => model.CostLastYear.Should().Be(1m)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSalesTerritoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTerritoryServerResponseModel>(new ApiSalesTerritoryServerResponseModel()));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTerritoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesTerritoryServerRequestModel>();
			patch.Replace(x => x.CostLastYear, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTerritoryServerResponseModel>(null));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesTerritoryServerRequestModel>();
			patch.Replace(x => x.CostLastYear, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTerritoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTerritoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTerritoryServerResponseModel()));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTerritoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTerritoryServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTerritoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTerritoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesTerritoryServerResponseModel()));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTerritoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTerritoryServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesTerritoryServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesTerritoryServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesTerritoryServerResponseModel>(null));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesTerritoryServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesTerritoryServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesTerritoryControllerMockFacade mock = new SalesTerritoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesTerritoryController controller = new SalesTerritoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SalesTerritoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SalesTerritoryController>> LoggerMock { get; set; } = new Mock<ILogger<SalesTerritoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISalesTerritoryService> ServiceMock { get; set; } = new Mock<ISalesTerritoryService>();

		public Mock<IApiSalesTerritoryServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesTerritoryServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5043a9f2dcf0bf7fa5ffb581be7fc31e</Hash>
</Codenesium>*/
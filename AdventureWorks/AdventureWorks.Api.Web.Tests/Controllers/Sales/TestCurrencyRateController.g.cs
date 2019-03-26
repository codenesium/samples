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
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Controllers")]
	public partial class CurrencyRateControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var record = new ApiCurrencyRateServerResponseModel();
			var records = new List<ApiCurrencyRateServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCurrencyRateServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiCurrencyRateServerResponseModel>>(new List<ApiCurrencyRateServerResponseModel>()));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCurrencyRateServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCurrencyRateServerResponseModel()));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCurrencyRateServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCurrencyRateServerResponseModel>(null));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.CreateResponse(null as ApiCurrencyRateServerResponseModel);

			mockResponse.SetRecord(new ApiCurrencyRateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyRateServerResponseModel>>(mockResponse));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCurrencyRateServerRequestModel>();
			records.Add(new ApiCurrencyRateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCurrencyRateServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCurrencyRateServerResponseModel>>(null as ApiCurrencyRateServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyRateServerResponseModel>>(mockResponse.Object));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCurrencyRateServerRequestModel>();
			records.Add(new ApiCurrencyRateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCurrencyRateServerResponseModel>.CreateResponse(null as ApiCurrencyRateServerResponseModel);

			mockResponse.SetRecord(new ApiCurrencyRateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyRateServerResponseModel>>(mockResponse));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCurrencyRateServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCurrencyRateServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCurrencyRateServerResponseModel>>(null as ApiCurrencyRateServerResponseModel);
			var mockRecord = new ApiCurrencyRateServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyRateServerResponseModel>>(mockResponse.Object));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCurrencyRateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()))
			.Callback<int, ApiCurrencyRateServerRequestModel>(
				(id, model) => model.AverageRate.Should().Be(1m)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCurrencyRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCurrencyRateServerResponseModel>(new ApiCurrencyRateServerResponseModel()));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCurrencyRateServerRequestModel>();
			patch.Replace(x => x.AverageRate, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCurrencyRateServerResponseModel>(null));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCurrencyRateServerRequestModel>();
			patch.Replace(x => x.AverageRate, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCurrencyRateServerResponseModel()));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCurrencyRateServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCurrencyRateServerResponseModel()));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCurrencyRateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyRateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyRateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCurrencyRateServerResponseModel>(null));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyRateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCurrencyRateServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CurrencyRateControllerMockFacade mock = new CurrencyRateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CurrencyRateController controller = new CurrencyRateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class CurrencyRateControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CurrencyRateController>> LoggerMock { get; set; } = new Mock<ILogger<CurrencyRateController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICurrencyRateService> ServiceMock { get; set; } = new Mock<ICurrencyRateService>();

		public Mock<IApiCurrencyRateServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCurrencyRateServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>d7b78769bebeb0c5f5277c2b15456b85</Hash>
</Codenesium>*/
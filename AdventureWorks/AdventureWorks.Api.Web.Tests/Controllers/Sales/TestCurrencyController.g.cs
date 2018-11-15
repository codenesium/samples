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
	[Trait("Table", "Currency")]
	[Trait("Area", "Controllers")]
	public partial class CurrencyControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var record = new ApiCurrencyServerResponseModel();
			var records = new List<ApiCurrencyServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCurrencyServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiCurrencyServerResponseModel>>(new List<ApiCurrencyServerResponseModel>()));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCurrencyServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCurrencyServerResponseModel()));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCurrencyServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCurrencyServerResponseModel>(null));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCurrencyServerResponseModel>.CreateResponse(null as ApiCurrencyServerResponseModel);

			mockResponse.SetRecord(new ApiCurrencyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyServerResponseModel>>(mockResponse));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCurrencyServerRequestModel>();
			records.Add(new ApiCurrencyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCurrencyServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCurrencyServerResponseModel>>(null as ApiCurrencyServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyServerResponseModel>>(mockResponse.Object));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCurrencyServerRequestModel>();
			records.Add(new ApiCurrencyServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCurrencyServerResponseModel>.CreateResponse(null as ApiCurrencyServerResponseModel);

			mockResponse.SetRecord(new ApiCurrencyServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyServerResponseModel>>(mockResponse));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCurrencyServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCurrencyServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCurrencyServerResponseModel>>(null as ApiCurrencyServerResponseModel);
			var mockRecord = new ApiCurrencyServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCurrencyServerResponseModel>>(mockResponse.Object));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCurrencyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>()))
			.Callback<string, ApiCurrencyServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCurrencyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCurrencyServerResponseModel>(new ApiCurrencyServerResponseModel()));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCurrencyServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCurrencyServerResponseModel>(null));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCurrencyServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCurrencyServerResponseModel()));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCurrencyServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCurrencyServerResponseModel()));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCurrencyServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCurrencyServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCurrencyServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCurrencyServerResponseModel>(null));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCurrencyServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCurrencyServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			CurrencyControllerMockFacade mock = new CurrencyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CurrencyController controller = new CurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class CurrencyControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CurrencyController>> LoggerMock { get; set; } = new Mock<ILogger<CurrencyController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICurrencyService> ServiceMock { get; set; } = new Mock<ICurrencyService>();

		public Mock<IApiCurrencyServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCurrencyServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b3895dc3baff35f9d393bd01918faed4</Hash>
</Codenesium>*/
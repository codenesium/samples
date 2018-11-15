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
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "Controllers")]
	public partial class CountryRegionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var record = new ApiCountryRegionServerResponseModel();
			var records = new List<ApiCountryRegionServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCountryRegionServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiCountryRegionServerResponseModel>>(new List<ApiCountryRegionServerResponseModel>()));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCountryRegionServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCountryRegionServerResponseModel()));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCountryRegionServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionServerResponseModel>(null));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCountryRegionServerResponseModel>.CreateResponse(null as ApiCountryRegionServerResponseModel);

			mockResponse.SetRecord(new ApiCountryRegionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionServerResponseModel>>(mockResponse));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCountryRegionServerRequestModel>();
			records.Add(new ApiCountryRegionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCountryRegionServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCountryRegionServerResponseModel>>(null as ApiCountryRegionServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionServerResponseModel>>(mockResponse.Object));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCountryRegionServerRequestModel>();
			records.Add(new ApiCountryRegionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCountryRegionServerResponseModel>.CreateResponse(null as ApiCountryRegionServerResponseModel);

			mockResponse.SetRecord(new ApiCountryRegionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionServerResponseModel>>(mockResponse));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCountryRegionServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCountryRegionServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCountryRegionServerResponseModel>>(null as ApiCountryRegionServerResponseModel);
			var mockRecord = new ApiCountryRegionServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionServerResponseModel>>(mockResponse.Object));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCountryRegionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRegionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>()))
			.Callback<string, ApiCountryRegionServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCountryRegionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionServerResponseModel>(new ApiCountryRegionServerResponseModel()));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRegionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCountryRegionServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionServerResponseModel>(null));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCountryRegionServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRegionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRegionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCountryRegionServerResponseModel()));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRegionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCountryRegionServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRegionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRegionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCountryRegionServerResponseModel()));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRegionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCountryRegionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRegionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRegionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionServerResponseModel>(null));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRegionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiCountryRegionServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CountryRegionControllerMockFacade mock = new CountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CountryRegionController controller = new CountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class CountryRegionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CountryRegionController>> LoggerMock { get; set; } = new Mock<ILogger<CountryRegionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICountryRegionService> ServiceMock { get; set; } = new Mock<ICountryRegionService>();

		public Mock<IApiCountryRegionServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCountryRegionServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>ce74441e1f95bf93ce566e861cde988a</Hash>
</Codenesium>*/
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
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Controllers")]
	public partial class StateProvinceControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var record = new ApiStateProvinceServerResponseModel();
			var records = new List<ApiStateProvinceServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiStateProvinceServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiStateProvinceServerResponseModel>>(new List<ApiStateProvinceServerResponseModel>()));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiStateProvinceServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStateProvinceServerResponseModel()));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiStateProvinceServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStateProvinceServerResponseModel>(null));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiStateProvinceServerResponseModel>.CreateResponse(null as ApiStateProvinceServerResponseModel);

			mockResponse.SetRecord(new ApiStateProvinceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStateProvinceServerResponseModel>>(mockResponse));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiStateProvinceServerRequestModel>();
			records.Add(new ApiStateProvinceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiStateProvinceServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiStateProvinceServerResponseModel>>(null as ApiStateProvinceServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStateProvinceServerResponseModel>>(mockResponse.Object));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiStateProvinceServerRequestModel>();
			records.Add(new ApiStateProvinceServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiStateProvinceServerResponseModel>.CreateResponse(null as ApiStateProvinceServerResponseModel);

			mockResponse.SetRecord(new ApiStateProvinceServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStateProvinceServerResponseModel>>(mockResponse));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiStateProvinceServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiStateProvinceServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiStateProvinceServerResponseModel>>(null as ApiStateProvinceServerResponseModel);
			var mockRecord = new ApiStateProvinceServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStateProvinceServerResponseModel>>(mockResponse.Object));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiStateProvinceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStateProvinceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()))
			.Callback<int, ApiStateProvinceServerRequestModel>(
				(id, model) => model.CountryRegionCode.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiStateProvinceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStateProvinceServerResponseModel>(new ApiStateProvinceServerResponseModel()));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStateProvinceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiStateProvinceServerRequestModel>();
			patch.Replace(x => x.CountryRegionCode, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStateProvinceServerResponseModel>(null));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiStateProvinceServerRequestModel>();
			patch.Replace(x => x.CountryRegionCode, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStateProvinceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStateProvinceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStateProvinceServerResponseModel()));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStateProvinceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStateProvinceServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStateProvinceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStateProvinceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStateProvinceServerResponseModel()));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStateProvinceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStateProvinceServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStateProvinceServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStateProvinceServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStateProvinceServerResponseModel>(null));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStateProvinceServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStateProvinceServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			StateProvinceControllerMockFacade mock = new StateProvinceControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			StateProvinceController controller = new StateProvinceController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class StateProvinceControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<StateProvinceController>> LoggerMock { get; set; } = new Mock<ILogger<StateProvinceController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IStateProvinceService> ServiceMock { get; set; } = new Mock<IStateProvinceService>();

		public Mock<IApiStateProvinceServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiStateProvinceServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>910b1eb8c288918dc46cc54f2eea41ac</Hash>
</Codenesium>*/
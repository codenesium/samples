using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "Controllers")]
	public partial class UnitDispositionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var record = new ApiUnitDispositionServerResponseModel();
			var records = new List<ApiUnitDispositionServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitDispositionServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiUnitDispositionServerResponseModel>>(new List<ApiUnitDispositionServerResponseModel>()));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitDispositionServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitDispositionServerResponseModel()));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiUnitDispositionServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitDispositionServerResponseModel>(null));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitDispositionServerResponseModel>.CreateResponse(null as ApiUnitDispositionServerResponseModel);

			mockResponse.SetRecord(new ApiUnitDispositionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitDispositionServerResponseModel>>(mockResponse));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitDispositionServerRequestModel>();
			records.Add(new ApiUnitDispositionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiUnitDispositionServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitDispositionServerResponseModel>>(null as ApiUnitDispositionServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitDispositionServerResponseModel>>(mockResponse.Object));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitDispositionServerRequestModel>();
			records.Add(new ApiUnitDispositionServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitDispositionServerResponseModel>.CreateResponse(null as ApiUnitDispositionServerResponseModel);

			mockResponse.SetRecord(new ApiUnitDispositionServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitDispositionServerResponseModel>>(mockResponse));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitDispositionServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiUnitDispositionServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitDispositionServerResponseModel>>(null as ApiUnitDispositionServerResponseModel);
			var mockRecord = new ApiUnitDispositionServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitDispositionServerResponseModel>>(mockResponse.Object));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitDispositionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitDispositionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()))
			.Callback<int, ApiUnitDispositionServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiUnitDispositionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitDispositionServerResponseModel>(new ApiUnitDispositionServerResponseModel()));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitDispositionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitDispositionServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitDispositionServerResponseModel>(null));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitDispositionServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitDispositionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitDispositionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitDispositionServerResponseModel()));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitDispositionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitDispositionServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitDispositionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitDispositionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitDispositionServerResponseModel()));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitDispositionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitDispositionServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitDispositionServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitDispositionServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitDispositionServerResponseModel>(null));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitDispositionServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitDispositionServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitDispositionControllerMockFacade mock = new UnitDispositionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitDispositionController controller = new UnitDispositionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class UnitDispositionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<UnitDispositionController>> LoggerMock { get; set; } = new Mock<ILogger<UnitDispositionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IUnitDispositionService> ServiceMock { get; set; } = new Mock<IUnitDispositionService>();

		public Mock<IApiUnitDispositionServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiUnitDispositionServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>a0edbc7df2ea15b911a81c8844857848</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Controllers")]
	public partial class UnitMeasureControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var record = new ApiUnitMeasureServerResponseModel();
			var records = new List<ApiUnitMeasureServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitMeasureServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiUnitMeasureServerResponseModel>>(new List<ApiUnitMeasureServerResponseModel>()));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitMeasureServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiUnitMeasureServerResponseModel()));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiUnitMeasureServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiUnitMeasureServerResponseModel>(null));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.CreateResponse(null as ApiUnitMeasureServerResponseModel);

			mockResponse.SetRecord(new ApiUnitMeasureServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitMeasureServerResponseModel>>(mockResponse));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitMeasureServerRequestModel>();
			records.Add(new ApiUnitMeasureServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiUnitMeasureServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitMeasureServerResponseModel>>(null as ApiUnitMeasureServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitMeasureServerResponseModel>>(mockResponse.Object));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitMeasureServerRequestModel>();
			records.Add(new ApiUnitMeasureServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.CreateResponse(null as ApiUnitMeasureServerResponseModel);

			mockResponse.SetRecord(new ApiUnitMeasureServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitMeasureServerResponseModel>>(mockResponse));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitMeasureServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiUnitMeasureServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitMeasureServerResponseModel>>(null as ApiUnitMeasureServerResponseModel);
			var mockRecord = new ApiUnitMeasureServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitMeasureServerResponseModel>>(mockResponse.Object));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitMeasureServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitMeasureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>()))
			.Callback<string, ApiUnitMeasureServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiUnitMeasureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiUnitMeasureServerResponseModel>(new ApiUnitMeasureServerResponseModel()));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitMeasureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitMeasureServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiUnitMeasureServerResponseModel>(null));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitMeasureServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitMeasureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitMeasureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiUnitMeasureServerResponseModel()));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitMeasureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiUnitMeasureServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitMeasureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitMeasureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiUnitMeasureServerResponseModel()));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitMeasureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiUnitMeasureServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitMeasureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiUnitMeasureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitMeasureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiUnitMeasureServerResponseModel>(null));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitMeasureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiUnitMeasureServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitMeasureControllerMockFacade mock = new UnitMeasureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitMeasureController controller = new UnitMeasureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class UnitMeasureControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<UnitMeasureController>> LoggerMock { get; set; } = new Mock<ILogger<UnitMeasureController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IUnitMeasureService> ServiceMock { get; set; } = new Mock<IUnitMeasureService>();

		public Mock<IApiUnitMeasureServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiUnitMeasureServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>03467038d5a5287a891140fb2aa7232c</Hash>
</Codenesium>*/
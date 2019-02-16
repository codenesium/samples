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
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "Controllers")]
	public partial class BillOfMaterialControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var record = new ApiBillOfMaterialServerResponseModel();
			var records = new List<ApiBillOfMaterialServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiBillOfMaterialServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiBillOfMaterialServerResponseModel>>(new List<ApiBillOfMaterialServerResponseModel>()));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiBillOfMaterialServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBillOfMaterialServerResponseModel()));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiBillOfMaterialServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBillOfMaterialServerResponseModel>(null));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.CreateResponse(null as ApiBillOfMaterialServerResponseModel);

			mockResponse.SetRecord(new ApiBillOfMaterialServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBillOfMaterialServerResponseModel>>(mockResponse));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiBillOfMaterialServerRequestModel>();
			records.Add(new ApiBillOfMaterialServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiBillOfMaterialServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiBillOfMaterialServerResponseModel>>(null as ApiBillOfMaterialServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBillOfMaterialServerResponseModel>>(mockResponse.Object));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiBillOfMaterialServerRequestModel>();
			records.Add(new ApiBillOfMaterialServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.CreateResponse(null as ApiBillOfMaterialServerResponseModel);

			mockResponse.SetRecord(new ApiBillOfMaterialServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBillOfMaterialServerResponseModel>>(mockResponse));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiBillOfMaterialServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiBillOfMaterialServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiBillOfMaterialServerResponseModel>>(null as ApiBillOfMaterialServerResponseModel);
			var mockRecord = new ApiBillOfMaterialServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBillOfMaterialServerResponseModel>>(mockResponse.Object));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiBillOfMaterialServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBillOfMaterialServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()))
			.Callback<int, ApiBillOfMaterialServerRequestModel>(
				(id, model) => model.BOMLevel.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiBillOfMaterialServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBillOfMaterialServerResponseModel>(new ApiBillOfMaterialServerResponseModel()));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBillOfMaterialServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiBillOfMaterialServerRequestModel>();
			patch.Replace(x => x.BOMLevel, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBillOfMaterialServerResponseModel>(null));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiBillOfMaterialServerRequestModel>();
			patch.Replace(x => x.BOMLevel, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBillOfMaterialServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBillOfMaterialServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBillOfMaterialServerResponseModel()));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBillOfMaterialServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBillOfMaterialServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBillOfMaterialServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBillOfMaterialServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBillOfMaterialServerResponseModel()));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBillOfMaterialServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBillOfMaterialServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBillOfMaterialServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBillOfMaterialServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBillOfMaterialServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBillOfMaterialServerResponseModel>(null));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBillOfMaterialServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBillOfMaterialServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			BillOfMaterialControllerMockFacade mock = new BillOfMaterialControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			BillOfMaterialController controller = new BillOfMaterialController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class BillOfMaterialControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<BillOfMaterialController>> LoggerMock { get; set; } = new Mock<ILogger<BillOfMaterialController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IBillOfMaterialService> ServiceMock { get; set; } = new Mock<IBillOfMaterialService>();

		public Mock<IApiBillOfMaterialServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiBillOfMaterialServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>89ba706a6ea709189f5067a9ba4ca929</Hash>
</Codenesium>*/
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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Controllers")]
	public partial class PurchaseOrderHeaderControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var record = new ApiPurchaseOrderHeaderServerResponseModel();
			var records = new List<ApiPurchaseOrderHeaderServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderHeaderServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPurchaseOrderHeaderServerResponseModel>>(new List<ApiPurchaseOrderHeaderServerResponseModel>()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderHeaderServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderServerResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPurchaseOrderHeaderServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderServerResponseModel>(null));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPurchaseOrderHeaderServerResponseModel>.CreateResponse(null as ApiPurchaseOrderHeaderServerResponseModel);

			mockResponse.SetRecord(new ApiPurchaseOrderHeaderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResponse));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPurchaseOrderHeaderServerRequestModel>();
			records.Add(new ApiPurchaseOrderHeaderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPurchaseOrderHeaderServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(null as ApiPurchaseOrderHeaderServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResponse.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPurchaseOrderHeaderServerRequestModel>();
			records.Add(new ApiPurchaseOrderHeaderServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPurchaseOrderHeaderServerResponseModel>.CreateResponse(null as ApiPurchaseOrderHeaderServerResponseModel);

			mockResponse.SetRecord(new ApiPurchaseOrderHeaderServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResponse));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPurchaseOrderHeaderServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(null as ApiPurchaseOrderHeaderServerResponseModel);
			var mockRecord = new ApiPurchaseOrderHeaderServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResponse.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPurchaseOrderHeaderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()))
			.Callback<int, ApiPurchaseOrderHeaderServerRequestModel>(
				(id, model) => model.EmployeeID.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderServerResponseModel>(new ApiPurchaseOrderHeaderServerResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel>();
			patch.Replace(x => x.EmployeeID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderServerResponseModel>(null));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel>();
			patch.Replace(x => x.EmployeeID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderServerResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderServerResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderServerResponseModel>(null));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PurchaseOrderHeaderControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PurchaseOrderHeaderController>> LoggerMock { get; set; } = new Mock<ILogger<PurchaseOrderHeaderController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPurchaseOrderHeaderService> ServiceMock { get; set; } = new Mock<IPurchaseOrderHeaderService>();

		public Mock<IApiPurchaseOrderHeaderServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPurchaseOrderHeaderServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>c678d909332e3ec2a865054fcd2f2896</Hash>
</Codenesium>*/
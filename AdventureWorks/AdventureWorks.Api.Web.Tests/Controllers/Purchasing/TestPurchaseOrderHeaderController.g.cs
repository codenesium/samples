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
			var record = new ApiPurchaseOrderHeaderResponseModel();
			var records = new List<ApiPurchaseOrderHeaderResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderHeaderResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPurchaseOrderHeaderResponseModel>>(new List<ApiPurchaseOrderHeaderResponseModel>()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPurchaseOrderHeaderResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPurchaseOrderHeaderResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPurchaseOrderHeaderResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResponse));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPurchaseOrderHeaderRequestModel>();
			records.Add(new ApiPurchaseOrderHeaderRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiPurchaseOrderHeaderResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResponse.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPurchaseOrderHeaderRequestModel>();
			records.Add(new ApiPurchaseOrderHeaderRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPurchaseOrderHeaderResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResponse));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPurchaseOrderHeaderRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPurchaseOrderHeaderResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiPurchaseOrderHeaderResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResponse.Object));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPurchaseOrderHeaderRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>()))
			.Callback<int, ApiPurchaseOrderHeaderRequestModel>(
				(id, model) => model.EmployeeID.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderResponseModel>(new ApiPurchaseOrderHeaderResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel>();
			patch.Replace(x => x.EmployeeID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderResponseModel>(null));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPurchaseOrderHeaderResponseModel()));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PurchaseOrderHeaderControllerMockFacade mock = new PurchaseOrderHeaderControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPurchaseOrderHeaderRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPurchaseOrderHeaderResponseModel>(null));
			PurchaseOrderHeaderController controller = new PurchaseOrderHeaderController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPurchaseOrderHeaderModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPurchaseOrderHeaderRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiPurchaseOrderHeaderModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPurchaseOrderHeaderModelMapper>();
	}
}

/*<Codenesium>
    <Hash>a2996f0bf3b9675c5b8aac2b700818fc</Hash>
</Codenesium>*/
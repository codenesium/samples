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
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "Controllers")]
	public partial class SalesPersonQuotaHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var record = new ApiSalesPersonQuotaHistoryResponseModel();
			var records = new List<ApiSalesPersonQuotaHistoryResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesPersonQuotaHistoryResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesPersonQuotaHistoryResponseModel>>(new List<ApiSalesPersonQuotaHistoryResponseModel>()));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesPersonQuotaHistoryResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesPersonQuotaHistoryResponseModel()));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSalesPersonQuotaHistoryResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesPersonQuotaHistoryResponseModel>(null));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSalesPersonQuotaHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResponse));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesPersonQuotaHistoryRequestModel>();
			records.Add(new ApiSalesPersonQuotaHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSalesPersonQuotaHistoryResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResponse.Object));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesPersonQuotaHistoryRequestModel>();
			records.Add(new ApiSalesPersonQuotaHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSalesPersonQuotaHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResponse));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesPersonQuotaHistoryRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSalesPersonQuotaHistoryResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResponse.Object));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesPersonQuotaHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()))
			.Callback<int, ApiSalesPersonQuotaHistoryRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesPersonQuotaHistoryResponseModel>(new ApiSalesPersonQuotaHistoryResponseModel()));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesPersonQuotaHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesPersonQuotaHistoryResponseModel>(null));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesPersonQuotaHistoryResponseModel()));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesPersonQuotaHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesPersonQuotaHistoryRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesPersonQuotaHistoryResponseModel()));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesPersonQuotaHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesPersonQuotaHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesPersonQuotaHistoryResponseModel>(null));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesPersonQuotaHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesPersonQuotaHistoryRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesPersonQuotaHistoryControllerMockFacade mock = new SalesPersonQuotaHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesPersonQuotaHistoryController controller = new SalesPersonQuotaHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SalesPersonQuotaHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SalesPersonQuotaHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<SalesPersonQuotaHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISalesPersonQuotaHistoryService> ServiceMock { get; set; } = new Mock<ISalesPersonQuotaHistoryService>();

		public Mock<IApiSalesPersonQuotaHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesPersonQuotaHistoryModelMapper>();
	}
}

/*<Codenesium>
    <Hash>2d1e2a02591e3d0d0ccbc66527c67050</Hash>
</Codenesium>*/
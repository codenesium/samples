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
	[Trait("Table", "SalesOrderHeaderSalesReason")]
	[Trait("Area", "Controllers")]
	public partial class SalesOrderHeaderSalesReasonControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var record = new ApiSalesOrderHeaderSalesReasonResponseModel();
			var records = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderSalesReasonResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSalesOrderHeaderSalesReasonResponseModel>>(new List<ApiSalesOrderHeaderSalesReasonResponseModel>()));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderSalesReasonResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderSalesReasonResponseModel()));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSalesOrderHeaderSalesReasonResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderSalesReasonResponseModel>(null));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSalesOrderHeaderSalesReasonResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResponse));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesOrderHeaderSalesReasonRequestModel>();
			records.Add(new ApiSalesOrderHeaderSalesReasonRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSalesOrderHeaderSalesReasonResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResponse.Object));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSalesOrderHeaderSalesReasonRequestModel>();
			records.Add(new ApiSalesOrderHeaderSalesReasonRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSalesOrderHeaderSalesReasonResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResponse));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesOrderHeaderSalesReasonRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSalesOrderHeaderSalesReasonResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResponse.Object));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSalesOrderHeaderSalesReasonRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()))
			.Callback<int, ApiSalesOrderHeaderSalesReasonRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderSalesReasonResponseModel>(new ApiSalesOrderHeaderSalesReasonResponseModel()));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderSalesReasonModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderSalesReasonResponseModel>(null));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderSalesReasonResponseModel()));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderSalesReasonModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderSalesReasonRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSalesOrderHeaderSalesReasonResponseModel()));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderSalesReasonModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderSalesReasonRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSalesOrderHeaderSalesReasonResponseModel>(null));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSalesOrderHeaderSalesReasonModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSalesOrderHeaderSalesReasonRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SalesOrderHeaderSalesReasonControllerMockFacade mock = new SalesOrderHeaderSalesReasonControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SalesOrderHeaderSalesReasonController controller = new SalesOrderHeaderSalesReasonController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SalesOrderHeaderSalesReasonControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SalesOrderHeaderSalesReasonController>> LoggerMock { get; set; } = new Mock<ILogger<SalesOrderHeaderSalesReasonController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISalesOrderHeaderSalesReasonService> ServiceMock { get; set; } = new Mock<ISalesOrderHeaderSalesReasonService>();

		public Mock<IApiSalesOrderHeaderSalesReasonModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSalesOrderHeaderSalesReasonModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3cce222d916a047e5fcc15c1f12ebe67</Hash>
</Codenesium>*/
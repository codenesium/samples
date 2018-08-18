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
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Controllers")]
	public partial class TransactionHistoryArchiveControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var record = new ApiTransactionHistoryArchiveResponseModel();
			var records = new List<ApiTransactionHistoryArchiveResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryArchiveResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTransactionHistoryArchiveResponseModel>>(new List<ApiTransactionHistoryArchiveResponseModel>()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTransactionHistoryArchiveResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTransactionHistoryArchiveResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTransactionHistoryArchiveResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResponse));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryArchiveRequestModel>();
			records.Add(new ApiTransactionHistoryArchiveRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTransactionHistoryArchiveResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResponse.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTransactionHistoryArchiveRequestModel>();
			records.Add(new ApiTransactionHistoryArchiveRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTransactionHistoryArchiveResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTransactionHistoryArchiveResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResponse));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryArchiveRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTransactionHistoryArchiveResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTransactionHistoryArchiveResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResponse.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTransactionHistoryArchiveRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>()))
			.Callback<int, ApiTransactionHistoryArchiveRequestModel>(
				(id, model) => model.ActualCost.Should().Be(1m)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveResponseModel>(new ApiTransactionHistoryArchiveResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel>();
			patch.Replace(x => x.ActualCost, 1m);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTransactionHistoryArchiveResponseModel()));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTransactionHistoryArchiveResponseModel>(null));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTransactionHistoryArchiveModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTransactionHistoryArchiveRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TransactionHistoryArchiveControllerMockFacade mock = new TransactionHistoryArchiveControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TransactionHistoryArchiveController controller = new TransactionHistoryArchiveController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TransactionHistoryArchiveControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TransactionHistoryArchiveController>> LoggerMock { get; set; } = new Mock<ILogger<TransactionHistoryArchiveController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITransactionHistoryArchiveService> ServiceMock { get; set; } = new Mock<ITransactionHistoryArchiveService>();

		public Mock<IApiTransactionHistoryArchiveModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTransactionHistoryArchiveModelMapper>();
	}
}

/*<Codenesium>
    <Hash>7e667c226a99ba75613d863b1b443afa</Hash>
</Codenesium>*/
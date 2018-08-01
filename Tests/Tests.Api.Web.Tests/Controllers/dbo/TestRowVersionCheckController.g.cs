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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Controllers")]
	public partial class RowVersionCheckControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var record = new ApiRowVersionCheckResponseModel();
			var records = new List<ApiRowVersionCheckResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiRowVersionCheckResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiRowVersionCheckResponseModel>>(new List<ApiRowVersionCheckResponseModel>()));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiRowVersionCheckResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiRowVersionCheckResponseModel()));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiRowVersionCheckResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiRowVersionCheckResponseModel>(null));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();

			var mockResponse = new CreateResponse<ApiRowVersionCheckResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiRowVersionCheckResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiRowVersionCheckResponseModel>>(mockResponse));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiRowVersionCheckRequestModel>();
			records.Add(new ApiRowVersionCheckRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiRowVersionCheckResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiRowVersionCheckResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiRowVersionCheckResponseModel>>(mockResponse.Object));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiRowVersionCheckRequestModel>();
			records.Add(new ApiRowVersionCheckRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();

			var mockResponse = new CreateResponse<ApiRowVersionCheckResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiRowVersionCheckResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiRowVersionCheckResponseModel>>(mockResponse));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiRowVersionCheckRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiRowVersionCheckResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiRowVersionCheckResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiRowVersionCheckResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiRowVersionCheckResponseModel>>(mockResponse.Object));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiRowVersionCheckRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiRowVersionCheckResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>()))
			.Callback<int, ApiRowVersionCheckRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiRowVersionCheckResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiRowVersionCheckResponseModel>(new ApiRowVersionCheckResponseModel()));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiRowVersionCheckModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiRowVersionCheckRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiRowVersionCheckResponseModel>(null));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiRowVersionCheckRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiRowVersionCheckResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiRowVersionCheckResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiRowVersionCheckResponseModel()));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiRowVersionCheckModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiRowVersionCheckRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiRowVersionCheckResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiRowVersionCheckResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiRowVersionCheckResponseModel()));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiRowVersionCheckModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiRowVersionCheckRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiRowVersionCheckResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiRowVersionCheckRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiRowVersionCheckResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiRowVersionCheckResponseModel>(null));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiRowVersionCheckModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiRowVersionCheckRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			RowVersionCheckControllerMockFacade mock = new RowVersionCheckControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			RowVersionCheckController controller = new RowVersionCheckController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class RowVersionCheckControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<RowVersionCheckController>> LoggerMock { get; set; } = new Mock<ILogger<RowVersionCheckController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IRowVersionCheckService> ServiceMock { get; set; } = new Mock<IRowVersionCheckService>();

		public Mock<IApiRowVersionCheckModelMapper> ModelMapperMock { get; set; } = new Mock<IApiRowVersionCheckModelMapper>();
	}
}

/*<Codenesium>
    <Hash>0a1e968f4f7782f1b122b872c6b5db37</Hash>
</Codenesium>*/
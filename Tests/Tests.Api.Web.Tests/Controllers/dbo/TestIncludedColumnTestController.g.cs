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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "Controllers")]
	public partial class IncludedColumnTestControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var record = new ApiIncludedColumnTestResponseModel();
			var records = new List<ApiIncludedColumnTestResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiIncludedColumnTestResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiIncludedColumnTestResponseModel>>(new List<ApiIncludedColumnTestResponseModel>()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiIncludedColumnTestResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiIncludedColumnTestResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new CreateResponse<ApiIncludedColumnTestResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiIncludedColumnTestResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestResponseModel>>(mockResponse));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiIncludedColumnTestRequestModel>();
			records.Add(new ApiIncludedColumnTestRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiIncludedColumnTestResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiIncludedColumnTestResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestResponseModel>>(mockResponse.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiIncludedColumnTestRequestModel>();
			records.Add(new ApiIncludedColumnTestRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new CreateResponse<ApiIncludedColumnTestResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiIncludedColumnTestResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestResponseModel>>(mockResponse));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiIncludedColumnTestRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiIncludedColumnTestResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiIncludedColumnTestResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiIncludedColumnTestResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiIncludedColumnTestResponseModel>>(mockResponse.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiIncludedColumnTestRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>()))
			.Callback<int, ApiIncludedColumnTestRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestResponseModel>(new ApiIncludedColumnTestResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiIncludedColumnTestRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiIncludedColumnTestRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiIncludedColumnTestResponseModel()));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiIncludedColumnTestResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiIncludedColumnTestRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiIncludedColumnTestResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiIncludedColumnTestResponseModel>(null));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiIncludedColumnTestModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiIncludedColumnTestRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			IncludedColumnTestControllerMockFacade mock = new IncludedColumnTestControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			IncludedColumnTestController controller = new IncludedColumnTestController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class IncludedColumnTestControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<IncludedColumnTestController>> LoggerMock { get; set; } = new Mock<ILogger<IncludedColumnTestController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IIncludedColumnTestService> ServiceMock { get; set; } = new Mock<IIncludedColumnTestService>();

		public Mock<IApiIncludedColumnTestModelMapper> ModelMapperMock { get; set; } = new Mock<IApiIncludedColumnTestModelMapper>();
	}
}

/*<Codenesium>
    <Hash>5ae8f9a5a53ec4eab08d2983f8cf1e75</Hash>
</Codenesium>*/
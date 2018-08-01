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
	[Trait("Table", "EmployeeDepartmentHistory")]
	[Trait("Area", "Controllers")]
	public partial class EmployeeDepartmentHistoryControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var record = new ApiEmployeeDepartmentHistoryResponseModel();
			var records = new List<ApiEmployeeDepartmentHistoryResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEmployeeDepartmentHistoryResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiEmployeeDepartmentHistoryResponseModel>>(new List<ApiEmployeeDepartmentHistoryResponseModel>()));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEmployeeDepartmentHistoryResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeeDepartmentHistoryResponseModel()));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiEmployeeDepartmentHistoryResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeeDepartmentHistoryResponseModel>(null));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEmployeeDepartmentHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResponse));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEmployeeDepartmentHistoryRequestModel>();
			records.Add(new ApiEmployeeDepartmentHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiEmployeeDepartmentHistoryResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResponse.Object));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEmployeeDepartmentHistoryRequestModel>();
			records.Add(new ApiEmployeeDepartmentHistoryRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEmployeeDepartmentHistoryResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResponse));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEmployeeDepartmentHistoryRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiEmployeeDepartmentHistoryResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResponse.Object));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEmployeeDepartmentHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()))
			.Callback<int, ApiEmployeeDepartmentHistoryRequestModel>(
				(id, model) => model.DepartmentID.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeeDepartmentHistoryResponseModel>(new ApiEmployeeDepartmentHistoryResponseModel()));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeeDepartmentHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel>();
			patch.Replace(x => x.DepartmentID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeeDepartmentHistoryResponseModel>(null));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel>();
			patch.Replace(x => x.DepartmentID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeeDepartmentHistoryResponseModel()));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeeDepartmentHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmployeeDepartmentHistoryRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmployeeDepartmentHistoryResponseModel()));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeeDepartmentHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmployeeDepartmentHistoryRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmployeeDepartmentHistoryResponseModel>(null));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmployeeDepartmentHistoryModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmployeeDepartmentHistoryRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EmployeeDepartmentHistoryControllerMockFacade mock = new EmployeeDepartmentHistoryControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EmployeeDepartmentHistoryController controller = new EmployeeDepartmentHistoryController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class EmployeeDepartmentHistoryControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<EmployeeDepartmentHistoryController>> LoggerMock { get; set; } = new Mock<ILogger<EmployeeDepartmentHistoryController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IEmployeeDepartmentHistoryService> ServiceMock { get; set; } = new Mock<IEmployeeDepartmentHistoryService>();

		public Mock<IApiEmployeeDepartmentHistoryModelMapper> ModelMapperMock { get; set; } = new Mock<IApiEmployeeDepartmentHistoryModelMapper>();
	}
}

/*<Codenesium>
    <Hash>143db5443f1775e8ddd637d11bc06fe1</Hash>
</Codenesium>*/
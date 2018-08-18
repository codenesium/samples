using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventRelatedDocument")]
	[Trait("Area", "Controllers")]
	public partial class EventRelatedDocumentControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var record = new ApiEventRelatedDocumentResponseModel();
			var records = new List<ApiEventRelatedDocumentResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEventRelatedDocumentResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiEventRelatedDocumentResponseModel>>(new List<ApiEventRelatedDocumentResponseModel>()));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEventRelatedDocumentResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEventRelatedDocumentResponseModel()));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiEventRelatedDocumentResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEventRelatedDocumentResponseModel>(null));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEventRelatedDocumentResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEventRelatedDocumentResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEventRelatedDocumentResponseModel>>(mockResponse));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEventRelatedDocumentRequestModel>();
			records.Add(new ApiEventRelatedDocumentRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiEventRelatedDocumentResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEventRelatedDocumentResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEventRelatedDocumentResponseModel>>(mockResponse.Object));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEventRelatedDocumentRequestModel>();
			records.Add(new ApiEventRelatedDocumentRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEventRelatedDocumentResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEventRelatedDocumentResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEventRelatedDocumentResponseModel>>(mockResponse));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEventRelatedDocumentRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiEventRelatedDocumentResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEventRelatedDocumentResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiEventRelatedDocumentResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEventRelatedDocumentResponseModel>>(mockResponse.Object));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEventRelatedDocumentRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEventRelatedDocumentResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>()))
			.Callback<int, ApiEventRelatedDocumentRequestModel>(
				(id, model) => model.EventId.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiEventRelatedDocumentResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEventRelatedDocumentResponseModel>(new ApiEventRelatedDocumentResponseModel()));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEventRelatedDocumentModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEventRelatedDocumentRequestModel>();
			patch.Replace(x => x.EventId, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEventRelatedDocumentResponseModel>(null));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEventRelatedDocumentRequestModel>();
			patch.Replace(x => x.EventId, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEventRelatedDocumentResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEventRelatedDocumentResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEventRelatedDocumentResponseModel()));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEventRelatedDocumentModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEventRelatedDocumentRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEventRelatedDocumentResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEventRelatedDocumentResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEventRelatedDocumentResponseModel()));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEventRelatedDocumentModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEventRelatedDocumentRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEventRelatedDocumentResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEventRelatedDocumentResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEventRelatedDocumentResponseModel>(null));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEventRelatedDocumentModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEventRelatedDocumentRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EventRelatedDocumentControllerMockFacade mock = new EventRelatedDocumentControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EventRelatedDocumentController controller = new EventRelatedDocumentController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class EventRelatedDocumentControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<EventRelatedDocumentController>> LoggerMock { get; set; } = new Mock<ILogger<EventRelatedDocumentController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IEventRelatedDocumentService> ServiceMock { get; set; } = new Mock<IEventRelatedDocumentService>();

		public Mock<IApiEventRelatedDocumentModelMapper> ModelMapperMock { get; set; } = new Mock<IApiEventRelatedDocumentModelMapper>();
	}
}

/*<Codenesium>
    <Hash>7be48df441cd5e48ee59bbeef60240e0</Hash>
</Codenesium>*/
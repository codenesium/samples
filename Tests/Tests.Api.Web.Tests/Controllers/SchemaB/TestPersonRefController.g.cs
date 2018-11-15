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
	[Trait("Table", "PersonRef")]
	[Trait("Area", "Controllers")]
	public partial class PersonRefControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var record = new ApiPersonRefServerResponseModel();
			var records = new List<ApiPersonRefServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPersonRefServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPersonRefServerResponseModel>>(new List<ApiPersonRefServerResponseModel>()));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPersonRefServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonRefServerResponseModel()));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPersonRefServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonRefServerResponseModel>(null));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPersonRefServerResponseModel>.CreateResponse(null as ApiPersonRefServerResponseModel);

			mockResponse.SetRecord(new ApiPersonRefServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonRefServerResponseModel>>(mockResponse));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPersonRefServerRequestModel>();
			records.Add(new ApiPersonRefServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPersonRefServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPersonRefServerResponseModel>>(null as ApiPersonRefServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonRefServerResponseModel>>(mockResponse.Object));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPersonRefServerRequestModel>();
			records.Add(new ApiPersonRefServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPersonRefServerResponseModel>.CreateResponse(null as ApiPersonRefServerResponseModel);

			mockResponse.SetRecord(new ApiPersonRefServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonRefServerResponseModel>>(mockResponse));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPersonRefServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPersonRefServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPersonRefServerResponseModel>>(null as ApiPersonRefServerResponseModel);
			var mockRecord = new ApiPersonRefServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonRefServerResponseModel>>(mockResponse.Object));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPersonRefServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonRefServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()))
			.Callback<int, ApiPersonRefServerRequestModel>(
				(id, model) => model.PersonAId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPersonRefServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonRefServerResponseModel>(new ApiPersonRefServerResponseModel()));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonRefServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPersonRefServerRequestModel>();
			patch.Replace(x => x.PersonAId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonRefServerResponseModel>(null));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPersonRefServerRequestModel>();
			patch.Replace(x => x.PersonAId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonRefServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonRefServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonRefServerResponseModel()));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonRefServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonRefServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonRefServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonRefServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonRefServerResponseModel()));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonRefServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonRefServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonRefServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonRefServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonRefServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonRefServerResponseModel>(null));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonRefServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonRefServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PersonRefControllerMockFacade mock = new PersonRefControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PersonRefController controller = new PersonRefController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PersonRefControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PersonRefController>> LoggerMock { get; set; } = new Mock<ILogger<PersonRefController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPersonRefService> ServiceMock { get; set; } = new Mock<IPersonRefService>();

		public Mock<IApiPersonRefServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPersonRefServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>e9cae7a399538acc375b251a10296694</Hash>
</Codenesium>*/
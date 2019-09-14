using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonType")]
	[Trait("Area", "Controllers")]
	public partial class PersonTypeControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var record = new ApiPersonTypeServerResponseModel();
			var records = new List<ApiPersonTypeServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPersonTypeServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiPersonTypeServerResponseModel>>(new List<ApiPersonTypeServerResponseModel>()));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPersonTypeServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonTypeServerResponseModel()));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPersonTypeServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonTypeServerResponseModel>(null));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPersonTypeServerResponseModel>.CreateResponse(null as ApiPersonTypeServerResponseModel);

			mockResponse.SetRecord(new ApiPersonTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonTypeServerResponseModel>>(mockResponse));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPersonTypeServerRequestModel>();
			records.Add(new ApiPersonTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPersonTypeServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPersonTypeServerResponseModel>>(null as ApiPersonTypeServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonTypeServerResponseModel>>(mockResponse.Object));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPersonTypeServerRequestModel>();
			records.Add(new ApiPersonTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPersonTypeServerResponseModel>.CreateResponse(null as ApiPersonTypeServerResponseModel);

			mockResponse.SetRecord(new ApiPersonTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonTypeServerResponseModel>>(mockResponse));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPersonTypeServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPersonTypeServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPersonTypeServerResponseModel>>(null as ApiPersonTypeServerResponseModel);
			var mockRecord = new ApiPersonTypeServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPersonTypeServerResponseModel>>(mockResponse.Object));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPersonTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()))
			.Callback<int, ApiPersonTypeServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPersonTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonTypeServerResponseModel>(new ApiPersonTypeServerResponseModel()));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPersonTypeServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonTypeServerResponseModel>(null));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPersonTypeServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonTypeServerResponseModel()));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonTypeServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPersonTypeServerResponseModel()));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPersonTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPersonTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPersonTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPersonTypeServerResponseModel>(null));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPersonTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPersonTypeServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PersonTypeControllerMockFacade mock = new PersonTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PersonTypeController controller = new PersonTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PersonTypeControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PersonTypeController>> LoggerMock { get; set; } = new Mock<ILogger<PersonTypeController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPersonTypeService> ServiceMock { get; set; } = new Mock<IPersonTypeService>();

		public Mock<IApiPersonTypeServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPersonTypeServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b1fe778cfccd7443ca87176ec1621e6b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "Controllers")]
	public partial class MachineRefTeamControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var record = new ApiMachineRefTeamServerResponseModel();
			var records = new List<ApiMachineRefTeamServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachineRefTeamServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiMachineRefTeamServerResponseModel>>(new List<ApiMachineRefTeamServerResponseModel>()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachineRefTeamServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamServerResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiMachineRefTeamServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamServerResponseModel>(null));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiMachineRefTeamServerResponseModel>.CreateResponse(null as ApiMachineRefTeamServerResponseModel);

			mockResponse.SetRecord(new ApiMachineRefTeamServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamServerResponseModel>>(mockResponse));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachineRefTeamServerRequestModel>();
			records.Add(new ApiMachineRefTeamServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiMachineRefTeamServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachineRefTeamServerResponseModel>>(null as ApiMachineRefTeamServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamServerResponseModel>>(mockResponse.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachineRefTeamServerRequestModel>();
			records.Add(new ApiMachineRefTeamServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiMachineRefTeamServerResponseModel>.CreateResponse(null as ApiMachineRefTeamServerResponseModel);

			mockResponse.SetRecord(new ApiMachineRefTeamServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamServerResponseModel>>(mockResponse));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachineRefTeamServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiMachineRefTeamServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachineRefTeamServerResponseModel>>(null as ApiMachineRefTeamServerResponseModel);
			var mockRecord = new ApiMachineRefTeamServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamServerResponseModel>>(mockResponse.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachineRefTeamServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()))
			.Callback<int, ApiMachineRefTeamServerRequestModel>(
				(id, model) => model.MachineId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamServerResponseModel>(new ApiMachineRefTeamServerResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachineRefTeamServerRequestModel>();
			patch.Replace(x => x.MachineId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamServerResponseModel>(null));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachineRefTeamServerRequestModel>();
			patch.Replace(x => x.MachineId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamServerResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamServerResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamServerResponseModel>(null));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class MachineRefTeamControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<MachineRefTeamController>> LoggerMock { get; set; } = new Mock<ILogger<MachineRefTeamController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IMachineRefTeamService> ServiceMock { get; set; } = new Mock<IMachineRefTeamService>();

		public Mock<IApiMachineRefTeamServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiMachineRefTeamServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>bcb4cb0b4f473066e1df62d3fa9bde19</Hash>
</Codenesium>*/
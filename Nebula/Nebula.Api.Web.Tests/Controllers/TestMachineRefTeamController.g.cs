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
			var record = new ApiMachineRefTeamResponseModel();
			var records = new List<ApiMachineRefTeamResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachineRefTeamResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiMachineRefTeamResponseModel>>(new List<ApiMachineRefTeamResponseModel>()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachineRefTeamResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiMachineRefTeamResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiMachineRefTeamResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiMachineRefTeamResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamResponseModel>>(mockResponse));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachineRefTeamRequestModel>();
			records.Add(new ApiMachineRefTeamRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiMachineRefTeamResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachineRefTeamResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamResponseModel>>(mockResponse.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachineRefTeamRequestModel>();
			records.Add(new ApiMachineRefTeamRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = new CreateResponse<ApiMachineRefTeamResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiMachineRefTeamResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamResponseModel>>(mockResponse));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachineRefTeamRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiMachineRefTeamResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachineRefTeamResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiMachineRefTeamResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachineRefTeamResponseModel>>(mockResponse.Object));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachineRefTeamRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>()))
			.Callback<int, ApiMachineRefTeamRequestModel>(
				(id, model) => model.MachineId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamResponseModel>(new ApiMachineRefTeamResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachineRefTeamRequestModel>();
			patch.Replace(x => x.MachineId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamResponseModel>(null));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachineRefTeamRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiMachineRefTeamResponseModel()));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			MachineRefTeamControllerMockFacade mock = new MachineRefTeamControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachineRefTeamResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachineRefTeamResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiMachineRefTeamResponseModel>(null));
			MachineRefTeamController controller = new MachineRefTeamController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachineRefTeamModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiMachineRefTeamRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiMachineRefTeamModelMapper> ModelMapperMock { get; set; } = new Mock<IApiMachineRefTeamModelMapper>();
	}
}

/*<Codenesium>
    <Hash>55388690ab5f4c5d57d1eaf764469849</Hash>
</Codenesium>*/
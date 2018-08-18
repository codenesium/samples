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
	[Trait("Table", "DeploymentRelatedMachine")]
	[Trait("Area", "Controllers")]
	public partial class DeploymentRelatedMachineControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var record = new ApiDeploymentRelatedMachineResponseModel();
			var records = new List<ApiDeploymentRelatedMachineResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeploymentRelatedMachineResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiDeploymentRelatedMachineResponseModel>>(new List<ApiDeploymentRelatedMachineResponseModel>()));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiDeploymentRelatedMachineResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeploymentRelatedMachineResponseModel()));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiDeploymentRelatedMachineResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeploymentRelatedMachineResponseModel>(null));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();

			var mockResponse = new CreateResponse<ApiDeploymentRelatedMachineResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiDeploymentRelatedMachineResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResponse));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeploymentRelatedMachineRequestModel>();
			records.Add(new ApiDeploymentRelatedMachineRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiDeploymentRelatedMachineResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResponse.Object));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiDeploymentRelatedMachineRequestModel>();
			records.Add(new ApiDeploymentRelatedMachineRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();

			var mockResponse = new CreateResponse<ApiDeploymentRelatedMachineResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiDeploymentRelatedMachineResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResponse));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeploymentRelatedMachineRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiDeploymentRelatedMachineResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiDeploymentRelatedMachineResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResponse.Object));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiDeploymentRelatedMachineRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>()))
			.Callback<int, ApiDeploymentRelatedMachineRequestModel>(
				(id, model) => model.DeploymentId.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeploymentRelatedMachineResponseModel>(new ApiDeploymentRelatedMachineResponseModel()));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentRelatedMachineModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel>();
			patch.Replace(x => x.DeploymentId, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeploymentRelatedMachineResponseModel>(null));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel>();
			patch.Replace(x => x.DeploymentId, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeploymentRelatedMachineResponseModel()));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentRelatedMachineModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeploymentRelatedMachineRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiDeploymentRelatedMachineResponseModel()));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentRelatedMachineModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeploymentRelatedMachineRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiDeploymentRelatedMachineResponseModel>(null));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiDeploymentRelatedMachineModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiDeploymentRelatedMachineRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			DeploymentRelatedMachineControllerMockFacade mock = new DeploymentRelatedMachineControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			DeploymentRelatedMachineController controller = new DeploymentRelatedMachineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class DeploymentRelatedMachineControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<DeploymentRelatedMachineController>> LoggerMock { get; set; } = new Mock<ILogger<DeploymentRelatedMachineController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IDeploymentRelatedMachineService> ServiceMock { get; set; } = new Mock<IDeploymentRelatedMachineService>();

		public Mock<IApiDeploymentRelatedMachineModelMapper> ModelMapperMock { get; set; } = new Mock<IApiDeploymentRelatedMachineModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b985686c16cf0f57e805380e76e0b0de</Hash>
</Codenesium>*/
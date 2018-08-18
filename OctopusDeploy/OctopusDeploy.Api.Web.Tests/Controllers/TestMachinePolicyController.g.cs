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
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "Controllers")]
	public partial class MachinePolicyControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var record = new ApiMachinePolicyResponseModel();
			var records = new List<ApiMachinePolicyResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachinePolicyResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiMachinePolicyResponseModel>>(new List<ApiMachinePolicyResponseModel>()));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiMachinePolicyResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachinePolicyResponseModel()));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiMachinePolicyResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachinePolicyResponseModel>(null));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();

			var mockResponse = new CreateResponse<ApiMachinePolicyResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiMachinePolicyResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachinePolicyResponseModel>>(mockResponse));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachinePolicyRequestModel>();
			records.Add(new ApiMachinePolicyRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiMachinePolicyResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachinePolicyResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachinePolicyResponseModel>>(mockResponse.Object));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiMachinePolicyRequestModel>();
			records.Add(new ApiMachinePolicyRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();

			var mockResponse = new CreateResponse<ApiMachinePolicyResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiMachinePolicyResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachinePolicyResponseModel>>(mockResponse));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachinePolicyRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiMachinePolicyResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiMachinePolicyResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiMachinePolicyResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiMachinePolicyResponseModel>>(mockResponse.Object));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiMachinePolicyRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachinePolicyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>()))
			.Callback<string, ApiMachinePolicyRequestModel>(
				(id, model) => model.IsDefault.Should().Be(true)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiMachinePolicyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachinePolicyResponseModel>(new ApiMachinePolicyResponseModel()));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachinePolicyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachinePolicyRequestModel>();
			patch.Replace(x => x.IsDefault, true);

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachinePolicyResponseModel>(null));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiMachinePolicyRequestModel>();
			patch.Replace(x => x.IsDefault, true);

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachinePolicyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachinePolicyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachinePolicyResponseModel()));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachinePolicyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiMachinePolicyRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachinePolicyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachinePolicyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiMachinePolicyResponseModel()));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachinePolicyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiMachinePolicyRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiMachinePolicyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiMachinePolicyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiMachinePolicyResponseModel>(null));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiMachinePolicyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiMachinePolicyRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			MachinePolicyControllerMockFacade mock = new MachinePolicyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			MachinePolicyController controller = new MachinePolicyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class MachinePolicyControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<MachinePolicyController>> LoggerMock { get; set; } = new Mock<ILogger<MachinePolicyController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IMachinePolicyService> ServiceMock { get; set; } = new Mock<IMachinePolicyService>();

		public Mock<IApiMachinePolicyModelMapper> ModelMapperMock { get; set; } = new Mock<IApiMachinePolicyModelMapper>();
	}
}

/*<Codenesium>
    <Hash>677da084b89750d6c94aa0f3e1ee65ec</Hash>
</Codenesium>*/
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
	[Trait("Table", "ActionTemplateVersion")]
	[Trait("Area", "Controllers")]
	public partial class ActionTemplateVersionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var record = new ApiActionTemplateVersionResponseModel();
			var records = new List<ApiActionTemplateVersionResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiActionTemplateVersionResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiActionTemplateVersionResponseModel>>(new List<ApiActionTemplateVersionResponseModel>()));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiActionTemplateVersionResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiActionTemplateVersionResponseModel()));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiActionTemplateVersionResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiActionTemplateVersionResponseModel>(null));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiActionTemplateVersionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiActionTemplateVersionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiActionTemplateVersionResponseModel>>(mockResponse));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiActionTemplateVersionRequestModel>();
			records.Add(new ApiActionTemplateVersionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiActionTemplateVersionResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiActionTemplateVersionResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiActionTemplateVersionResponseModel>>(mockResponse.Object));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiActionTemplateVersionRequestModel>();
			records.Add(new ApiActionTemplateVersionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiActionTemplateVersionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiActionTemplateVersionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiActionTemplateVersionResponseModel>>(mockResponse));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiActionTemplateVersionRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiActionTemplateVersionResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiActionTemplateVersionResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiActionTemplateVersionResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiActionTemplateVersionResponseModel>>(mockResponse.Object));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiActionTemplateVersionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiActionTemplateVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>()))
			.Callback<string, ApiActionTemplateVersionRequestModel>(
				(id, model) => model.ActionType.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiActionTemplateVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiActionTemplateVersionResponseModel>(new ApiActionTemplateVersionResponseModel()));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiActionTemplateVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiActionTemplateVersionRequestModel>();
			patch.Replace(x => x.ActionType, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiActionTemplateVersionResponseModel>(null));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiActionTemplateVersionRequestModel>();
			patch.Replace(x => x.ActionType, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiActionTemplateVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiActionTemplateVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiActionTemplateVersionResponseModel()));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiActionTemplateVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiActionTemplateVersionRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiActionTemplateVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiActionTemplateVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiActionTemplateVersionResponseModel()));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiActionTemplateVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiActionTemplateVersionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiActionTemplateVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiActionTemplateVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiActionTemplateVersionResponseModel>(null));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiActionTemplateVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiActionTemplateVersionRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			ActionTemplateVersionControllerMockFacade mock = new ActionTemplateVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			ActionTemplateVersionController controller = new ActionTemplateVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class ActionTemplateVersionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<ActionTemplateVersionController>> LoggerMock { get; set; } = new Mock<ILogger<ActionTemplateVersionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IActionTemplateVersionService> ServiceMock { get; set; } = new Mock<IActionTemplateVersionService>();

		public Mock<IApiActionTemplateVersionModelMapper> ModelMapperMock { get; set; } = new Mock<IApiActionTemplateVersionModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9612be3090835f560415875c1cbe2656</Hash>
</Codenesium>*/
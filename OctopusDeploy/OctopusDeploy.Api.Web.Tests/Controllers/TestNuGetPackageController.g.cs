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
	[Trait("Table", "NuGetPackage")]
	[Trait("Area", "Controllers")]
	public partial class NuGetPackageControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var record = new ApiNuGetPackageResponseModel();
			var records = new List<ApiNuGetPackageResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiNuGetPackageResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiNuGetPackageResponseModel>>(new List<ApiNuGetPackageResponseModel>()));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiNuGetPackageResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiNuGetPackageResponseModel()));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiNuGetPackageResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiNuGetPackageResponseModel>(null));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();

			var mockResponse = new CreateResponse<ApiNuGetPackageResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiNuGetPackageResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiNuGetPackageResponseModel>>(mockResponse));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiNuGetPackageRequestModel>();
			records.Add(new ApiNuGetPackageRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiNuGetPackageResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiNuGetPackageResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiNuGetPackageResponseModel>>(mockResponse.Object));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiNuGetPackageRequestModel>();
			records.Add(new ApiNuGetPackageRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();

			var mockResponse = new CreateResponse<ApiNuGetPackageResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiNuGetPackageResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiNuGetPackageResponseModel>>(mockResponse));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiNuGetPackageRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiNuGetPackageResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiNuGetPackageResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiNuGetPackageResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiNuGetPackageResponseModel>>(mockResponse.Object));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiNuGetPackageRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiNuGetPackageResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>()))
			.Callback<string, ApiNuGetPackageRequestModel>(
				(id, model) => model.JSON.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiNuGetPackageResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiNuGetPackageResponseModel>(new ApiNuGetPackageResponseModel()));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiNuGetPackageModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiNuGetPackageRequestModel>();
			patch.Replace(x => x.JSON, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiNuGetPackageResponseModel>(null));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiNuGetPackageRequestModel>();
			patch.Replace(x => x.JSON, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiNuGetPackageResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiNuGetPackageResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiNuGetPackageResponseModel()));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiNuGetPackageModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiNuGetPackageRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiNuGetPackageResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiNuGetPackageResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiNuGetPackageResponseModel()));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiNuGetPackageModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiNuGetPackageRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiNuGetPackageResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiNuGetPackageResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiNuGetPackageResponseModel>(null));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiNuGetPackageModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiNuGetPackageRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			NuGetPackageControllerMockFacade mock = new NuGetPackageControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			NuGetPackageController controller = new NuGetPackageController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class NuGetPackageControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<NuGetPackageController>> LoggerMock { get; set; } = new Mock<ILogger<NuGetPackageController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<INuGetPackageService> ServiceMock { get; set; } = new Mock<INuGetPackageService>();

		public Mock<IApiNuGetPackageModelMapper> ModelMapperMock { get; set; } = new Mock<IApiNuGetPackageModelMapper>();
	}
}

/*<Codenesium>
    <Hash>3e2a9abe75b8bed7379228e25fd0f431</Hash>
</Codenesium>*/
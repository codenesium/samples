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
	[Trait("Table", "KeyAllocation")]
	[Trait("Area", "Controllers")]
	public partial class KeyAllocationControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var record = new ApiKeyAllocationResponseModel();
			var records = new List<ApiKeyAllocationResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiKeyAllocationResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiKeyAllocationResponseModel>>(new List<ApiKeyAllocationResponseModel>()));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiKeyAllocationResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKeyAllocationResponseModel()));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiKeyAllocationResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiKeyAllocationResponseModel>(null));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();

			var mockResponse = new CreateResponse<ApiKeyAllocationResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiKeyAllocationResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiKeyAllocationResponseModel>>(mockResponse));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiKeyAllocationRequestModel>();
			records.Add(new ApiKeyAllocationRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiKeyAllocationResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiKeyAllocationResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiKeyAllocationResponseModel>>(mockResponse.Object));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiKeyAllocationRequestModel>();
			records.Add(new ApiKeyAllocationRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();

			var mockResponse = new CreateResponse<ApiKeyAllocationResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiKeyAllocationResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiKeyAllocationResponseModel>>(mockResponse));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiKeyAllocationRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiKeyAllocationResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiKeyAllocationResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiKeyAllocationResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiKeyAllocationResponseModel>>(mockResponse.Object));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiKeyAllocationRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiKeyAllocationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>()))
			.Callback<string, ApiKeyAllocationRequestModel>(
				(id, model) => model.Allocated.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiKeyAllocationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiKeyAllocationResponseModel>(new ApiKeyAllocationResponseModel()));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiKeyAllocationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiKeyAllocationRequestModel>();
			patch.Replace(x => x.Allocated, 1);

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiKeyAllocationResponseModel>(null));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiKeyAllocationRequestModel>();
			patch.Replace(x => x.Allocated, 1);

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiKeyAllocationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiKeyAllocationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKeyAllocationResponseModel()));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiKeyAllocationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiKeyAllocationRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiKeyAllocationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiKeyAllocationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKeyAllocationResponseModel()));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiKeyAllocationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiKeyAllocationRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiKeyAllocationResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiKeyAllocationResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiKeyAllocationResponseModel>(null));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiKeyAllocationModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiKeyAllocationRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			KeyAllocationControllerMockFacade mock = new KeyAllocationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			KeyAllocationController controller = new KeyAllocationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class KeyAllocationControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<KeyAllocationController>> LoggerMock { get; set; } = new Mock<ILogger<KeyAllocationController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IKeyAllocationService> ServiceMock { get; set; } = new Mock<IKeyAllocationService>();

		public Mock<IApiKeyAllocationModelMapper> ModelMapperMock { get; set; } = new Mock<IApiKeyAllocationModelMapper>();
	}
}

/*<Codenesium>
    <Hash>dd8cc46190dcebfd51695b5bb1224d83</Hash>
</Codenesium>*/
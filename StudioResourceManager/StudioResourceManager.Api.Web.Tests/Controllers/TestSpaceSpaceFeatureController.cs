using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Controllers")]
	public partial class SpaceSpaceFeatureControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var record = new ApiSpaceSpaceFeatureServerResponseModel();
			var records = new List<ApiSpaceSpaceFeatureServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceSpaceFeatureServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiSpaceSpaceFeatureServerResponseModel>>(new List<ApiSpaceSpaceFeatureServerResponseModel>()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceSpaceFeatureServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureServerResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSpaceSpaceFeatureServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureServerResponseModel>(null));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSpaceSpaceFeatureServerResponseModel>.CreateResponse(null as ApiSpaceSpaceFeatureServerResponseModel);

			mockResponse.SetRecord(new ApiSpaceSpaceFeatureServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResponse));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceSpaceFeatureServerRequestModel>();
			records.Add(new ApiSpaceSpaceFeatureServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiSpaceSpaceFeatureServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(null as ApiSpaceSpaceFeatureServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResponse.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceSpaceFeatureServerRequestModel>();
			records.Add(new ApiSpaceSpaceFeatureServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiSpaceSpaceFeatureServerResponseModel>.CreateResponse(null as ApiSpaceSpaceFeatureServerResponseModel);

			mockResponse.SetRecord(new ApiSpaceSpaceFeatureServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResponse));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceSpaceFeatureServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(null as ApiSpaceSpaceFeatureServerResponseModel);
			var mockRecord = new ApiSpaceSpaceFeatureServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResponse.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceSpaceFeatureServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()))
			.Callback<int, ApiSpaceSpaceFeatureServerRequestModel>(
				(id, model) => model.SpaceFeatureId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureServerResponseModel>(new ApiSpaceSpaceFeatureServerResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureServerResponseModel>(null));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureServerResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureServerResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureServerResponseModel>(null));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SpaceSpaceFeatureControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SpaceSpaceFeatureController>> LoggerMock { get; set; } = new Mock<ILogger<SpaceSpaceFeatureController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISpaceSpaceFeatureService> ServiceMock { get; set; } = new Mock<ISpaceSpaceFeatureService>();

		public Mock<IApiSpaceSpaceFeatureServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSpaceSpaceFeatureServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>6c2e445c2836390376b36446ee9a00d1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
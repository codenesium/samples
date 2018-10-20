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
			var record = new ApiSpaceSpaceFeatureResponseModel();
			var records = new List<ApiSpaceSpaceFeatureResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceSpaceFeatureResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSpaceSpaceFeatureResponseModel>>(new List<ApiSpaceSpaceFeatureResponseModel>()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceSpaceFeatureResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSpaceSpaceFeatureResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiSpaceSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResponse));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSpaceSpaceFeatureResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpaceSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResponse));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceSpaceFeatureRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSpaceSpaceFeatureResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSpaceSpaceFeatureResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>()))
			.Callback<int, ApiSpaceSpaceFeatureRequestModel>(
				(id, model) => model.SpaceFeatureId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureResponseModel>(new ApiSpaceSpaceFeatureResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureResponseModel>(null));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceSpaceFeatureResponseModel()));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SpaceSpaceFeatureControllerMockFacade mock = new SpaceSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceSpaceFeatureResponseModel>(null));
			SpaceSpaceFeatureController controller = new SpaceSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceSpaceFeatureRequestModel());

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

		public Mock<IApiSpaceSpaceFeatureModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSpaceSpaceFeatureModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b6794263411348ae02671d1b07c29e25</Hash>
</Codenesium>*/
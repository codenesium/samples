using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
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

namespace FermataFishNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceXSpaceFeature")]
	[Trait("Area", "Controllers")]
	public partial class SpaceXSpaceFeatureControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var record = new ApiSpaceXSpaceFeatureResponseModel();
			var records = new List<ApiSpaceXSpaceFeatureResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceXSpaceFeatureResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSpaceXSpaceFeatureResponseModel>>(new List<ApiSpaceXSpaceFeatureResponseModel>()));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpaceXSpaceFeatureResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceXSpaceFeatureResponseModel()));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSpaceXSpaceFeatureResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceXSpaceFeatureResponseModel>(null));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceXSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResponse));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceXSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceXSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSpaceXSpaceFeatureResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpaceXSpaceFeatureRequestModel>();
			records.Add(new ApiSpaceXSpaceFeatureRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpaceXSpaceFeatureResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResponse));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceXSpaceFeatureRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSpaceXSpaceFeatureResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSpaceXSpaceFeatureResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResponse.Object));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpaceXSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()))
			.Callback<int, ApiSpaceXSpaceFeatureRequestModel>(
				(id, model) => model.SpaceFeatureId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceXSpaceFeatureResponseModel>(new ApiSpaceXSpaceFeatureResponseModel()));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceXSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceXSpaceFeatureResponseModel>(null));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel>();
			patch.Replace(x => x.SpaceFeatureId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceXSpaceFeatureResponseModel()));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceXSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpaceXSpaceFeatureResponseModel()));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceXSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpaceXSpaceFeatureResponseModel>(null));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpaceXSpaceFeatureModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpaceXSpaceFeatureRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpaceXSpaceFeatureControllerMockFacade mock = new SpaceXSpaceFeatureControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpaceXSpaceFeatureController controller = new SpaceXSpaceFeatureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SpaceXSpaceFeatureControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SpaceXSpaceFeatureController>> LoggerMock { get; set; } = new Mock<ILogger<SpaceXSpaceFeatureController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISpaceXSpaceFeatureService> ServiceMock { get; set; } = new Mock<ISpaceXSpaceFeatureService>();

		public Mock<IApiSpaceXSpaceFeatureModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSpaceXSpaceFeatureModelMapper>();
	}
}

/*<Codenesium>
    <Hash>983b3a38b9bf63124fa50776f9601ea8</Hash>
</Codenesium>*/
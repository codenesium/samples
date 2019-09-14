using CADNS.Api.Contracts;
using CADNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace CADNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "Controllers")]
	public partial class UnitOfficerControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var record = new ApiUnitOfficerServerResponseModel();
			var records = new List<ApiUnitOfficerServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitOfficerServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiUnitOfficerServerResponseModel>>(new List<ApiUnitOfficerServerResponseModel>()));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiUnitOfficerServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitOfficerServerResponseModel()));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiUnitOfficerServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitOfficerServerResponseModel>(null));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitOfficerServerResponseModel>.CreateResponse(null as ApiUnitOfficerServerResponseModel);

			mockResponse.SetRecord(new ApiUnitOfficerServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitOfficerServerResponseModel>>(mockResponse));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitOfficerServerRequestModel>();
			records.Add(new ApiUnitOfficerServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiUnitOfficerServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitOfficerServerResponseModel>>(null as ApiUnitOfficerServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitOfficerServerResponseModel>>(mockResponse.Object));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiUnitOfficerServerRequestModel>();
			records.Add(new ApiUnitOfficerServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiUnitOfficerServerResponseModel>.CreateResponse(null as ApiUnitOfficerServerResponseModel);

			mockResponse.SetRecord(new ApiUnitOfficerServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitOfficerServerResponseModel>>(mockResponse));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitOfficerServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiUnitOfficerServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiUnitOfficerServerResponseModel>>(null as ApiUnitOfficerServerResponseModel);
			var mockRecord = new ApiUnitOfficerServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiUnitOfficerServerResponseModel>>(mockResponse.Object));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiUnitOfficerServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()))
			.Callback<int, ApiUnitOfficerServerRequestModel>(
				(id, model) => model.OfficerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiUnitOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitOfficerServerResponseModel>(new ApiUnitOfficerServerResponseModel()));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitOfficerServerResponseModel>(null));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiUnitOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitOfficerServerResponseModel()));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitOfficerServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiUnitOfficerServerResponseModel()));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitOfficerServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiUnitOfficerServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiUnitOfficerServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiUnitOfficerServerResponseModel>(null));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiUnitOfficerServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiUnitOfficerServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			UnitOfficerControllerMockFacade mock = new UnitOfficerControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			UnitOfficerController controller = new UnitOfficerController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class UnitOfficerControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<UnitOfficerController>> LoggerMock { get; set; } = new Mock<ILogger<UnitOfficerController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IUnitOfficerService> ServiceMock { get; set; } = new Mock<IUnitOfficerService>();

		public Mock<IApiUnitOfficerServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiUnitOfficerServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>324a44dd42a055291290b7bf3042d8c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
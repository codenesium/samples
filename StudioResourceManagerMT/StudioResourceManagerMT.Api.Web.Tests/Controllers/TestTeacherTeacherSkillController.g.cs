using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Controllers")]
	public partial class TeacherTeacherSkillControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var record = new ApiTeacherTeacherSkillServerResponseModel();
			var records = new List<ApiTeacherTeacherSkillServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherTeacherSkillServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiTeacherTeacherSkillServerResponseModel>>(new List<ApiTeacherTeacherSkillServerResponseModel>()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherTeacherSkillServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillServerResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTeacherTeacherSkillServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillServerResponseModel>(null));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTeacherTeacherSkillServerResponseModel>.CreateResponse(null as ApiTeacherTeacherSkillServerResponseModel);

			mockResponse.SetRecord(new ApiTeacherTeacherSkillServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResponse));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherTeacherSkillServerRequestModel>();
			records.Add(new ApiTeacherTeacherSkillServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiTeacherTeacherSkillServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(null as ApiTeacherTeacherSkillServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResponse.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherTeacherSkillServerRequestModel>();
			records.Add(new ApiTeacherTeacherSkillServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiTeacherTeacherSkillServerResponseModel>.CreateResponse(null as ApiTeacherTeacherSkillServerResponseModel);

			mockResponse.SetRecord(new ApiTeacherTeacherSkillServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResponse));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherTeacherSkillServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTeacherTeacherSkillServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(null as ApiTeacherTeacherSkillServerResponseModel);
			var mockRecord = new ApiTeacherTeacherSkillServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResponse.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherTeacherSkillServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()))
			.Callback<int, ApiTeacherTeacherSkillServerRequestModel>(
				(id, model) => model.TeacherSkillId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillServerResponseModel>(new ApiTeacherTeacherSkillServerResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel>();
			patch.Replace(x => x.TeacherSkillId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillServerResponseModel>(null));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel>();
			patch.Replace(x => x.TeacherSkillId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillServerResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillServerResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillServerResponseModel>(null));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class TeacherTeacherSkillControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<TeacherTeacherSkillController>> LoggerMock { get; set; } = new Mock<ILogger<TeacherTeacherSkillController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ITeacherTeacherSkillService> ServiceMock { get; set; } = new Mock<ITeacherTeacherSkillService>();

		public Mock<IApiTeacherTeacherSkillServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTeacherTeacherSkillServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>99371469c19cc0276164fa530f3a7008</Hash>
</Codenesium>*/
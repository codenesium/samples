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
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "Controllers")]
	public partial class TeacherTeacherSkillControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var record = new ApiTeacherTeacherSkillResponseModel();
			var records = new List<ApiTeacherTeacherSkillResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherTeacherSkillResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTeacherTeacherSkillResponseModel>>(new List<ApiTeacherTeacherSkillResponseModel>()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiTeacherTeacherSkillResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiTeacherTeacherSkillResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiTeacherTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTeacherTeacherSkillResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResponse));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherTeacherSkillRequestModel>();
			records.Add(new ApiTeacherTeacherSkillRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiTeacherTeacherSkillResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResponse.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiTeacherTeacherSkillRequestModel>();
			records.Add(new ApiTeacherTeacherSkillRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = new CreateResponse<ApiTeacherTeacherSkillResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiTeacherTeacherSkillResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResponse));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherTeacherSkillRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiTeacherTeacherSkillResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiTeacherTeacherSkillResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResponse.Object));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiTeacherTeacherSkillRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>()))
			.Callback<int, ApiTeacherTeacherSkillRequestModel>(
				(id, model) => model.TeacherSkillId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillResponseModel>(new ApiTeacherTeacherSkillResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherSkillId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillResponseModel>(null));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTeacherTeacherSkillResponseModel()));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			TeacherTeacherSkillControllerMockFacade mock = new TeacherTeacherSkillControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTeacherTeacherSkillRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiTeacherTeacherSkillResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTeacherTeacherSkillResponseModel>(null));
			TeacherTeacherSkillController controller = new TeacherTeacherSkillController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTeacherTeacherSkillModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiTeacherTeacherSkillRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiTeacherTeacherSkillModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTeacherTeacherSkillModelMapper>();
	}
}

/*<Codenesium>
    <Hash>922274b52c06046baeaf6aefb3d90eb5</Hash>
</Codenesium>*/
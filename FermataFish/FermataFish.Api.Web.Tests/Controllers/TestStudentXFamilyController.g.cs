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
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "Controllers")]
	public partial class StudentXFamilyControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var record = new ApiStudentXFamilyResponseModel();
			var records = new List<ApiStudentXFamilyResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiStudentXFamilyResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiStudentXFamilyResponseModel>>(new List<ApiStudentXFamilyResponseModel>()));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiStudentXFamilyResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStudentXFamilyResponseModel()));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiStudentXFamilyResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStudentXFamilyResponseModel>(null));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();

			var mockResponse = new CreateResponse<ApiStudentXFamilyResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiStudentXFamilyResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStudentXFamilyResponseModel>>(mockResponse));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiStudentXFamilyRequestModel>();
			records.Add(new ApiStudentXFamilyRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiStudentXFamilyResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiStudentXFamilyResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStudentXFamilyResponseModel>>(mockResponse.Object));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiStudentXFamilyRequestModel>();
			records.Add(new ApiStudentXFamilyRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();

			var mockResponse = new CreateResponse<ApiStudentXFamilyResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiStudentXFamilyResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStudentXFamilyResponseModel>>(mockResponse));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiStudentXFamilyRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiStudentXFamilyResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiStudentXFamilyResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiStudentXFamilyResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiStudentXFamilyResponseModel>>(mockResponse.Object));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiStudentXFamilyRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStudentXFamilyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>()))
			.Callback<int, ApiStudentXFamilyRequestModel>(
				(id, model) => model.FamilyId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiStudentXFamilyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStudentXFamilyResponseModel>(new ApiStudentXFamilyResponseModel()));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStudentXFamilyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiStudentXFamilyRequestModel>();
			patch.Replace(x => x.FamilyId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStudentXFamilyResponseModel>(null));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiStudentXFamilyRequestModel>();
			patch.Replace(x => x.FamilyId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStudentXFamilyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStudentXFamilyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStudentXFamilyResponseModel()));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStudentXFamilyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStudentXFamilyRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStudentXFamilyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStudentXFamilyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiStudentXFamilyResponseModel()));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStudentXFamilyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStudentXFamilyRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiStudentXFamilyResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiStudentXFamilyResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiStudentXFamilyResponseModel>(null));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiStudentXFamilyModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiStudentXFamilyRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			StudentXFamilyControllerMockFacade mock = new StudentXFamilyControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			StudentXFamilyController controller = new StudentXFamilyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class StudentXFamilyControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<StudentXFamilyController>> LoggerMock { get; set; } = new Mock<ILogger<StudentXFamilyController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IStudentXFamilyService> ServiceMock { get; set; } = new Mock<IStudentXFamilyService>();

		public Mock<IApiStudentXFamilyModelMapper> ModelMapperMock { get; set; } = new Mock<IApiStudentXFamilyModelMapper>();
	}
}

/*<Codenesium>
    <Hash>e7f8bdbfc79acf1bd8277e8a28617255</Hash>
</Codenesium>*/
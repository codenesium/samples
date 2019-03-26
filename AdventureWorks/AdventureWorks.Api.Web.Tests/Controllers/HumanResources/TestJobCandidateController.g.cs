using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "Controllers")]
	public partial class JobCandidateControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var record = new ApiJobCandidateServerResponseModel();
			var records = new List<ApiJobCandidateServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiJobCandidateServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiJobCandidateServerResponseModel>>(new List<ApiJobCandidateServerResponseModel>()));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiJobCandidateServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiJobCandidateServerResponseModel()));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiJobCandidateServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiJobCandidateServerResponseModel>(null));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiJobCandidateServerResponseModel>.CreateResponse(null as ApiJobCandidateServerResponseModel);

			mockResponse.SetRecord(new ApiJobCandidateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiJobCandidateServerResponseModel>>(mockResponse));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiJobCandidateServerRequestModel>();
			records.Add(new ApiJobCandidateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiJobCandidateServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiJobCandidateServerResponseModel>>(null as ApiJobCandidateServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiJobCandidateServerResponseModel>>(mockResponse.Object));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiJobCandidateServerRequestModel>();
			records.Add(new ApiJobCandidateServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiJobCandidateServerResponseModel>.CreateResponse(null as ApiJobCandidateServerResponseModel);

			mockResponse.SetRecord(new ApiJobCandidateServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiJobCandidateServerResponseModel>>(mockResponse));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiJobCandidateServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiJobCandidateServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiJobCandidateServerResponseModel>>(null as ApiJobCandidateServerResponseModel);
			var mockRecord = new ApiJobCandidateServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiJobCandidateServerResponseModel>>(mockResponse.Object));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiJobCandidateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiJobCandidateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>()))
			.Callback<int, ApiJobCandidateServerRequestModel>(
				(id, model) => model.BusinessEntityID.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiJobCandidateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiJobCandidateServerResponseModel>(new ApiJobCandidateServerResponseModel()));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiJobCandidateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiJobCandidateServerRequestModel>();
			patch.Replace(x => x.BusinessEntityID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiJobCandidateServerResponseModel>(null));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiJobCandidateServerRequestModel>();
			patch.Replace(x => x.BusinessEntityID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiJobCandidateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiJobCandidateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiJobCandidateServerResponseModel()));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiJobCandidateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiJobCandidateServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiJobCandidateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiJobCandidateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiJobCandidateServerResponseModel()));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiJobCandidateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiJobCandidateServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiJobCandidateServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiJobCandidateServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiJobCandidateServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiJobCandidateServerResponseModel>(null));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiJobCandidateServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiJobCandidateServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			JobCandidateControllerMockFacade mock = new JobCandidateControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			JobCandidateController controller = new JobCandidateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class JobCandidateControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<JobCandidateController>> LoggerMock { get; set; } = new Mock<ILogger<JobCandidateController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IJobCandidateService> ServiceMock { get; set; } = new Mock<IJobCandidateService>();

		public Mock<IApiJobCandidateServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiJobCandidateServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>f31ed142c5c19e34f891341e9e1aef28</Hash>
</Codenesium>*/
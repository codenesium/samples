using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "Controllers")]
	public partial class VoteTypeControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var record = new ApiVoteTypeServerResponseModel();
			var records = new List<ApiVoteTypeServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVoteTypeServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVoteTypeServerResponseModel>>(new List<ApiVoteTypeServerResponseModel>()));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVoteTypeServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteTypeServerResponseModel()));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVoteTypeServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteTypeServerResponseModel>(null));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVoteTypeServerResponseModel>.CreateResponse(null as ApiVoteTypeServerResponseModel);

			mockResponse.SetRecord(new ApiVoteTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteTypeServerResponseModel>>(mockResponse));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVoteTypeServerRequestModel>();
			records.Add(new ApiVoteTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVoteTypeServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVoteTypeServerResponseModel>>(null as ApiVoteTypeServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteTypeServerResponseModel>>(mockResponse.Object));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVoteTypeServerRequestModel>();
			records.Add(new ApiVoteTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVoteTypeServerResponseModel>.CreateResponse(null as ApiVoteTypeServerResponseModel);

			mockResponse.SetRecord(new ApiVoteTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteTypeServerResponseModel>>(mockResponse));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVoteTypeServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVoteTypeServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVoteTypeServerResponseModel>>(null as ApiVoteTypeServerResponseModel);
			var mockRecord = new ApiVoteTypeServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteTypeServerResponseModel>>(mockResponse.Object));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVoteTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()))
			.Callback<int, ApiVoteTypeServerRequestModel>(
				(id, model) => model.Name.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVoteTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteTypeServerResponseModel>(new ApiVoteTypeServerResponseModel()));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVoteTypeServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteTypeServerResponseModel>(null));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVoteTypeServerRequestModel>();
			patch.Replace(x => x.Name, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteTypeServerResponseModel()));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteTypeServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteTypeServerResponseModel()));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteTypeServerResponseModel>(null));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteTypeServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VoteTypeControllerMockFacade mock = new VoteTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VoteTypeController controller = new VoteTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VoteTypeControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VoteTypeController>> LoggerMock { get; set; } = new Mock<ILogger<VoteTypeController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVoteTypeService> ServiceMock { get; set; } = new Mock<IVoteTypeService>();

		public Mock<IApiVoteTypeServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVoteTypeServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>daef90fcdddc17a6ca15f3c573096ff6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
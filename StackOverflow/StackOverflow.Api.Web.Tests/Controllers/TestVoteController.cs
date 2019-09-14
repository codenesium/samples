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
	[Trait("Table", "Vote")]
	[Trait("Area", "Controllers")]
	public partial class VoteControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var record = new ApiVoteServerResponseModel();
			var records = new List<ApiVoteServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVoteServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiVoteServerResponseModel>>(new List<ApiVoteServerResponseModel>()));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVoteServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteServerResponseModel()));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVoteServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteServerResponseModel>(null));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VoteControllerMockFacade mock = new VoteControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVoteServerResponseModel>.CreateResponse(null as ApiVoteServerResponseModel);

			mockResponse.SetRecord(new ApiVoteServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteServerResponseModel>>(mockResponse));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVoteServerRequestModel>();
			records.Add(new ApiVoteServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiVoteServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVoteServerResponseModel>>(null as ApiVoteServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteServerResponseModel>>(mockResponse.Object));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVoteServerRequestModel>();
			records.Add(new ApiVoteServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiVoteServerResponseModel>.CreateResponse(null as ApiVoteServerResponseModel);

			mockResponse.SetRecord(new ApiVoteServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteServerResponseModel>>(mockResponse));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVoteServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVoteServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVoteServerResponseModel>>(null as ApiVoteServerResponseModel);
			var mockRecord = new ApiVoteServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVoteServerResponseModel>>(mockResponse.Object));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVoteServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()))
			.Callback<int, ApiVoteServerRequestModel>(
				(id, model) => model.BountyAmount.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteServerResponseModel>(new ApiVoteServerResponseModel()));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVoteServerRequestModel>();
			patch.Replace(x => x.BountyAmount, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteServerResponseModel>(null));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVoteServerRequestModel>();
			patch.Replace(x => x.BountyAmount, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteServerResponseModel()));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVoteServerResponseModel()));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVoteServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVoteServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVoteServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVoteServerResponseModel>(null));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVoteServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVoteServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VoteControllerMockFacade mock = new VoteControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VoteController controller = new VoteController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VoteControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VoteController>> LoggerMock { get; set; } = new Mock<ILogger<VoteController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVoteService> ServiceMock { get; set; } = new Mock<IVoteService>();

		public Mock<IApiVoteServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVoteServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9bd5f2d85de344896687114c4e493219</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
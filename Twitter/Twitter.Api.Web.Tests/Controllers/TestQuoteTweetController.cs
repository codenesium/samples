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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Controllers")]
	public partial class QuoteTweetControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var record = new ApiQuoteTweetServerResponseModel();
			var records = new List<ApiQuoteTweetServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiQuoteTweetServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiQuoteTweetServerResponseModel>>(new List<ApiQuoteTweetServerResponseModel>()));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiQuoteTweetServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiQuoteTweetServerResponseModel()));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiQuoteTweetServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiQuoteTweetServerResponseModel>(null));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.CreateResponse(null as ApiQuoteTweetServerResponseModel);

			mockResponse.SetRecord(new ApiQuoteTweetServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiQuoteTweetServerResponseModel>>(mockResponse));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiQuoteTweetServerRequestModel>();
			records.Add(new ApiQuoteTweetServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiQuoteTweetServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiQuoteTweetServerResponseModel>>(null as ApiQuoteTweetServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiQuoteTweetServerResponseModel>>(mockResponse.Object));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiQuoteTweetServerRequestModel>();
			records.Add(new ApiQuoteTweetServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.CreateResponse(null as ApiQuoteTweetServerResponseModel);

			mockResponse.SetRecord(new ApiQuoteTweetServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiQuoteTweetServerResponseModel>>(mockResponse));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiQuoteTweetServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiQuoteTweetServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiQuoteTweetServerResponseModel>>(null as ApiQuoteTweetServerResponseModel);
			var mockRecord = new ApiQuoteTweetServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiQuoteTweetServerResponseModel>>(mockResponse.Object));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiQuoteTweetServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiQuoteTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()))
			.Callback<int, ApiQuoteTweetServerRequestModel>(
				(id, model) => model.Content.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiQuoteTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiQuoteTweetServerResponseModel>(new ApiQuoteTweetServerResponseModel()));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiQuoteTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiQuoteTweetServerRequestModel>();
			patch.Replace(x => x.Content, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiQuoteTweetServerResponseModel>(null));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiQuoteTweetServerRequestModel>();
			patch.Replace(x => x.Content, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiQuoteTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiQuoteTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiQuoteTweetServerResponseModel()));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiQuoteTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiQuoteTweetServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiQuoteTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiQuoteTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiQuoteTweetServerResponseModel()));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiQuoteTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiQuoteTweetServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiQuoteTweetServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiQuoteTweetServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiQuoteTweetServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiQuoteTweetServerResponseModel>(null));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiQuoteTweetServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiQuoteTweetServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			QuoteTweetControllerMockFacade mock = new QuoteTweetControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			QuoteTweetController controller = new QuoteTweetController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class QuoteTweetControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<QuoteTweetController>> LoggerMock { get; set; } = new Mock<ILogger<QuoteTweetController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IQuoteTweetService> ServiceMock { get; set; } = new Mock<IQuoteTweetService>();

		public Mock<IApiQuoteTweetServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiQuoteTweetServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b250b2c1d38b659840c2abe756343e77</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
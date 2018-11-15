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
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Controllers")]
	public partial class PhoneNumberTypeControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var record = new ApiPhoneNumberTypeServerResponseModel();
			var records = new List<ApiPhoneNumberTypeServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPhoneNumberTypeServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPhoneNumberTypeServerResponseModel>>(new List<ApiPhoneNumberTypeServerResponseModel>()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPhoneNumberTypeServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeServerResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPhoneNumberTypeServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeServerResponseModel>(null));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.CreateResponse(null as ApiPhoneNumberTypeServerResponseModel);

			mockResponse.SetRecord(new ApiPhoneNumberTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResponse));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPhoneNumberTypeServerRequestModel>();
			records.Add(new ApiPhoneNumberTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiPhoneNumberTypeServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(null as ApiPhoneNumberTypeServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResponse.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPhoneNumberTypeServerRequestModel>();
			records.Add(new ApiPhoneNumberTypeServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiPhoneNumberTypeServerResponseModel>.CreateResponse(null as ApiPhoneNumberTypeServerResponseModel);

			mockResponse.SetRecord(new ApiPhoneNumberTypeServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResponse));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPhoneNumberTypeServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPhoneNumberTypeServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(null as ApiPhoneNumberTypeServerResponseModel);
			var mockRecord = new ApiPhoneNumberTypeServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResponse.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPhoneNumberTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>()))
			.Callback<int, ApiPhoneNumberTypeServerRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeServerResponseModel>(new ApiPhoneNumberTypeServerResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeServerResponseModel>(null));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeServerResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeServerResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeServerResponseModel>(null));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class PhoneNumberTypeControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<PhoneNumberTypeController>> LoggerMock { get; set; } = new Mock<ILogger<PhoneNumberTypeController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IPhoneNumberTypeService> ServiceMock { get; set; } = new Mock<IPhoneNumberTypeService>();

		public Mock<IApiPhoneNumberTypeServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPhoneNumberTypeServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>ff7ca4f5075d0c9eaba3adc13d197cbd</Hash>
</Codenesium>*/
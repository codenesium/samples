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
			var record = new ApiPhoneNumberTypeResponseModel();
			var records = new List<ApiPhoneNumberTypeResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPhoneNumberTypeResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPhoneNumberTypeResponseModel>>(new List<ApiPhoneNumberTypeResponseModel>()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiPhoneNumberTypeResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiPhoneNumberTypeResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeResponseModel>(null));
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

			var mockResponse = new CreateResponse<ApiPhoneNumberTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPhoneNumberTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeResponseModel>>(mockResponse));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPhoneNumberTypeRequestModel>();
			records.Add(new ApiPhoneNumberTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiPhoneNumberTypeResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPhoneNumberTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeResponseModel>>(mockResponse.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiPhoneNumberTypeRequestModel>();
			records.Add(new ApiPhoneNumberTypeRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = new CreateResponse<ApiPhoneNumberTypeResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiPhoneNumberTypeResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeResponseModel>>(mockResponse));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPhoneNumberTypeRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPhoneNumberTypeResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiPhoneNumberTypeResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiPhoneNumberTypeResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPhoneNumberTypeResponseModel>>(mockResponse.Object));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiPhoneNumberTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>()))
			.Callback<int, ApiPhoneNumberTypeRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeResponseModel>(new ApiPhoneNumberTypeResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPhoneNumberTypeRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeResponseModel>(null));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiPhoneNumberTypeRequestModel>();
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
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPhoneNumberTypeResponseModel()));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			PhoneNumberTypeControllerMockFacade mock = new PhoneNumberTypeControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiPhoneNumberTypeResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPhoneNumberTypeRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPhoneNumberTypeResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPhoneNumberTypeResponseModel>(null));
			PhoneNumberTypeController controller = new PhoneNumberTypeController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPhoneNumberTypeModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiPhoneNumberTypeRequestModel());

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

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
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

		public Mock<IApiPhoneNumberTypeModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPhoneNumberTypeModelMapper>();
	}
}

/*<Codenesium>
    <Hash>1dd93919a8ae960637c4563e0c1671b6</Hash>
</Codenesium>*/
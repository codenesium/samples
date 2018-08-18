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
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "Controllers")]
	public partial class EmailAddressControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var record = new ApiEmailAddressResponseModel();
			var records = new List<ApiEmailAddressResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEmailAddressResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiEmailAddressResponseModel>>(new List<ApiEmailAddressResponseModel>()));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiEmailAddressResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmailAddressResponseModel()));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiEmailAddressResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmailAddressResponseModel>(null));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEmailAddressResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEmailAddressResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmailAddressResponseModel>>(mockResponse));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEmailAddressRequestModel>();
			records.Add(new ApiEmailAddressRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiEmailAddressResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEmailAddressResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmailAddressResponseModel>>(mockResponse.Object));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiEmailAddressRequestModel>();
			records.Add(new ApiEmailAddressRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();

			var mockResponse = new CreateResponse<ApiEmailAddressResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiEmailAddressResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmailAddressResponseModel>>(mockResponse));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEmailAddressRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiEmailAddressResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiEmailAddressResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiEmailAddressResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiEmailAddressResponseModel>>(mockResponse.Object));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiEmailAddressRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmailAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>()))
			.Callback<int, ApiEmailAddressRequestModel>(
				(id, model) => model.EmailAddress1.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiEmailAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmailAddressResponseModel>(new ApiEmailAddressResponseModel()));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmailAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEmailAddressRequestModel>();
			patch.Replace(x => x.EmailAddress1, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmailAddressResponseModel>(null));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiEmailAddressRequestModel>();
			patch.Replace(x => x.EmailAddress1, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmailAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmailAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmailAddressResponseModel()));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmailAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmailAddressRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmailAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmailAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiEmailAddressResponseModel()));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmailAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmailAddressRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiEmailAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiEmailAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiEmailAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiEmailAddressResponseModel>(null));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiEmailAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiEmailAddressRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			EmailAddressControllerMockFacade mock = new EmailAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			EmailAddressController controller = new EmailAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class EmailAddressControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<EmailAddressController>> LoggerMock { get; set; } = new Mock<ILogger<EmailAddressController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IEmailAddressService> ServiceMock { get; set; } = new Mock<IEmailAddressService>();

		public Mock<IApiEmailAddressModelMapper> ModelMapperMock { get; set; } = new Mock<IApiEmailAddressModelMapper>();
	}
}

/*<Codenesium>
    <Hash>b7778e8a056ebfa524855a266898d667</Hash>
</Codenesium>*/
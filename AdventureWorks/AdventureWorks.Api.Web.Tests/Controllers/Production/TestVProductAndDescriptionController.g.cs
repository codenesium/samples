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
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Controllers")]
	public partial class VProductAndDescriptionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var record = new ApiVProductAndDescriptionResponseModel();
			var records = new List<ApiVProductAndDescriptionResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVProductAndDescriptionResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiVProductAndDescriptionResponseModel>>(new List<ApiVProductAndDescriptionResponseModel>()));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVProductAndDescriptionResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiVProductAndDescriptionResponseModel()));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVProductAndDescriptionResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiVProductAndDescriptionResponseModel>(null));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(string));

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void BulkInsert_No_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiVProductAndDescriptionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiVProductAndDescriptionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVProductAndDescriptionResponseModel>>(mockResponse));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVProductAndDescriptionRequestModel>();
			records.Add(new ApiVProductAndDescriptionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiVProductAndDescriptionResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVProductAndDescriptionResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVProductAndDescriptionResponseModel>>(mockResponse.Object));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVProductAndDescriptionRequestModel>();
			records.Add(new ApiVProductAndDescriptionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiVProductAndDescriptionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiVProductAndDescriptionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVProductAndDescriptionResponseModel>>(mockResponse));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVProductAndDescriptionRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVProductAndDescriptionResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVProductAndDescriptionResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiVProductAndDescriptionResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVProductAndDescriptionResponseModel>>(mockResponse.Object));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVProductAndDescriptionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVProductAndDescriptionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>()))
			.Callback<string, ApiVProductAndDescriptionRequestModel>(
				(id, model) => model.Description.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVProductAndDescriptionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiVProductAndDescriptionResponseModel>(new ApiVProductAndDescriptionResponseModel()));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVProductAndDescriptionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVProductAndDescriptionRequestModel>();
			patch.Replace(x => x.Description, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiVProductAndDescriptionResponseModel>(null));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVProductAndDescriptionRequestModel>();
			patch.Replace(x => x.Description, "A");

			IActionResult response = await controller.Patch(default(string), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVProductAndDescriptionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVProductAndDescriptionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiVProductAndDescriptionResponseModel()));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVProductAndDescriptionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiVProductAndDescriptionRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVProductAndDescriptionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVProductAndDescriptionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiVProductAndDescriptionResponseModel()));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVProductAndDescriptionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiVProductAndDescriptionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVProductAndDescriptionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiVProductAndDescriptionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVProductAndDescriptionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiVProductAndDescriptionResponseModel>(null));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVProductAndDescriptionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(string), new ApiVProductAndDescriptionRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<NoContentResult>();
			(response as NoContentResult).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			VProductAndDescriptionControllerMockFacade mock = new VProductAndDescriptionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VProductAndDescriptionController controller = new VProductAndDescriptionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(string));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
		}
	}

	public class VProductAndDescriptionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VProductAndDescriptionController>> LoggerMock { get; set; } = new Mock<ILogger<VProductAndDescriptionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVProductAndDescriptionService> ServiceMock { get; set; } = new Mock<IVProductAndDescriptionService>();

		public Mock<IApiVProductAndDescriptionModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVProductAndDescriptionModelMapper>();
	}
}

/*<Codenesium>
    <Hash>d43010ff750eba0969430e39db3b4287</Hash>
</Codenesium>*/
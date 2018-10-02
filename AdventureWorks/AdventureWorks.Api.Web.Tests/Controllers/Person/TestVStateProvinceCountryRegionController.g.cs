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
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "Controllers")]
	public partial class VStateProvinceCountryRegionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var record = new ApiVStateProvinceCountryRegionResponseModel();
			var records = new List<ApiVStateProvinceCountryRegionResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVStateProvinceCountryRegionResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiVStateProvinceCountryRegionResponseModel>>(new List<ApiVStateProvinceCountryRegionResponseModel>()));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiVStateProvinceCountryRegionResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVStateProvinceCountryRegionResponseModel()));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiVStateProvinceCountryRegionResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVStateProvinceCountryRegionResponseModel>(null));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiVStateProvinceCountryRegionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiVStateProvinceCountryRegionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResponse));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVStateProvinceCountryRegionRequestModel>();
			records.Add(new ApiVStateProvinceCountryRegionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiVStateProvinceCountryRegionResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResponse.Object));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiVStateProvinceCountryRegionRequestModel>();
			records.Add(new ApiVStateProvinceCountryRegionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiVStateProvinceCountryRegionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiVStateProvinceCountryRegionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResponse));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVStateProvinceCountryRegionRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiVStateProvinceCountryRegionResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiVStateProvinceCountryRegionResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResponse.Object));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiVStateProvinceCountryRegionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()))
			.Callback<int, ApiVStateProvinceCountryRegionRequestModel>(
				(id, model) => model.CountryRegionCode.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVStateProvinceCountryRegionResponseModel>(new ApiVStateProvinceCountryRegionResponseModel()));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVStateProvinceCountryRegionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel>();
			patch.Replace(x => x.CountryRegionCode, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVStateProvinceCountryRegionResponseModel>(null));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel>();
			patch.Replace(x => x.CountryRegionCode, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVStateProvinceCountryRegionResponseModel()));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVStateProvinceCountryRegionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVStateProvinceCountryRegionResponseModel()));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVStateProvinceCountryRegionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVStateProvinceCountryRegionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVStateProvinceCountryRegionResponseModel>(null));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVStateProvinceCountryRegionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiVStateProvinceCountryRegionRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			VStateProvinceCountryRegionControllerMockFacade mock = new VStateProvinceCountryRegionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			VStateProvinceCountryRegionController controller = new VStateProvinceCountryRegionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class VStateProvinceCountryRegionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<VStateProvinceCountryRegionController>> LoggerMock { get; set; } = new Mock<ILogger<VStateProvinceCountryRegionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IVStateProvinceCountryRegionService> ServiceMock { get; set; } = new Mock<IVStateProvinceCountryRegionService>();

		public Mock<IApiVStateProvinceCountryRegionModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVStateProvinceCountryRegionModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4e7554570a4a9b62697a0284ea05a8f9</Hash>
</Codenesium>*/
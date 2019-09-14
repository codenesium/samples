using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "Controllers")]
	public partial class CountryRequirementControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var record = new ApiCountryRequirementServerResponseModel();
			var records = new List<ApiCountryRequirementServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCountryRequirementServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiCountryRequirementServerResponseModel>>(new List<ApiCountryRequirementServerResponseModel>()));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCountryRequirementServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCountryRequirementServerResponseModel()));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCountryRequirementServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCountryRequirementServerResponseModel>(null));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.CreateResponse(null as ApiCountryRequirementServerResponseModel);

			mockResponse.SetRecord(new ApiCountryRequirementServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRequirementServerResponseModel>>(mockResponse));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCountryRequirementServerRequestModel>();
			records.Add(new ApiCountryRequirementServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCountryRequirementServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCountryRequirementServerResponseModel>>(null as ApiCountryRequirementServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRequirementServerResponseModel>>(mockResponse.Object));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCountryRequirementServerRequestModel>();
			records.Add(new ApiCountryRequirementServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCountryRequirementServerResponseModel>.CreateResponse(null as ApiCountryRequirementServerResponseModel);

			mockResponse.SetRecord(new ApiCountryRequirementServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRequirementServerResponseModel>>(mockResponse));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCountryRequirementServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCountryRequirementServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCountryRequirementServerResponseModel>>(null as ApiCountryRequirementServerResponseModel);
			var mockRecord = new ApiCountryRequirementServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRequirementServerResponseModel>>(mockResponse.Object));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCountryRequirementServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()))
			.Callback<int, ApiCountryRequirementServerRequestModel>(
				(id, model) => model.CountryId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCountryRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCountryRequirementServerResponseModel>(new ApiCountryRequirementServerResponseModel()));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCountryRequirementServerRequestModel>();
			patch.Replace(x => x.CountryId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCountryRequirementServerResponseModel>(null));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCountryRequirementServerRequestModel>();
			patch.Replace(x => x.CountryId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCountryRequirementServerResponseModel()));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCountryRequirementServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCountryRequirementServerResponseModel()));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCountryRequirementServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCountryRequirementServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCountryRequirementServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCountryRequirementServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCountryRequirementServerResponseModel>(null));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCountryRequirementServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCountryRequirementServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CountryRequirementControllerMockFacade mock = new CountryRequirementControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CountryRequirementController controller = new CountryRequirementController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class CountryRequirementControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CountryRequirementController>> LoggerMock { get; set; } = new Mock<ILogger<CountryRequirementController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICountryRequirementService> ServiceMock { get; set; } = new Mock<ICountryRequirementService>();

		public Mock<IApiCountryRequirementServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCountryRequirementServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>1f9fc10d5671e93a6e37030cfbb0fab4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
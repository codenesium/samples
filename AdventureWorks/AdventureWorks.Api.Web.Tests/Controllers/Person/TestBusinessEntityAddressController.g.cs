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
	[Trait("Table", "BusinessEntityAddress")]
	[Trait("Area", "Controllers")]
	public partial class BusinessEntityAddressControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var record = new ApiBusinessEntityAddressResponseModel();
			var records = new List<ApiBusinessEntityAddressResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiBusinessEntityAddressResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiBusinessEntityAddressResponseModel>>(new List<ApiBusinessEntityAddressResponseModel>()));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiBusinessEntityAddressResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityAddressResponseModel()));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiBusinessEntityAddressResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityAddressResponseModel>(null));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();

			var mockResponse = new CreateResponse<ApiBusinessEntityAddressResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiBusinessEntityAddressResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityAddressResponseModel>>(mockResponse));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiBusinessEntityAddressRequestModel>();
			records.Add(new ApiBusinessEntityAddressRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiBusinessEntityAddressResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiBusinessEntityAddressResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityAddressResponseModel>>(mockResponse.Object));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiBusinessEntityAddressRequestModel>();
			records.Add(new ApiBusinessEntityAddressRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();

			var mockResponse = new CreateResponse<ApiBusinessEntityAddressResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiBusinessEntityAddressResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityAddressResponseModel>>(mockResponse));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiBusinessEntityAddressRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiBusinessEntityAddressResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiBusinessEntityAddressResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiBusinessEntityAddressResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityAddressResponseModel>>(mockResponse.Object));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiBusinessEntityAddressRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBusinessEntityAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>()))
			.Callback<int, ApiBusinessEntityAddressRequestModel>(
				(id, model) => model.AddressID.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityAddressResponseModel>(new ApiBusinessEntityAddressResponseModel()));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiBusinessEntityAddressRequestModel>();
			patch.Replace(x => x.AddressID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityAddressResponseModel>(null));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiBusinessEntityAddressRequestModel>();
			patch.Replace(x => x.AddressID, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBusinessEntityAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityAddressResponseModel()));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBusinessEntityAddressRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBusinessEntityAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityAddressResponseModel()));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBusinessEntityAddressRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiBusinessEntityAddressResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityAddressResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityAddressResponseModel>(null));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityAddressModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiBusinessEntityAddressRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			BusinessEntityAddressControllerMockFacade mock = new BusinessEntityAddressControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			BusinessEntityAddressController controller = new BusinessEntityAddressController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class BusinessEntityAddressControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<BusinessEntityAddressController>> LoggerMock { get; set; } = new Mock<ILogger<BusinessEntityAddressController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IBusinessEntityAddressService> ServiceMock { get; set; } = new Mock<IBusinessEntityAddressService>();

		public Mock<IApiBusinessEntityAddressModelMapper> ModelMapperMock { get; set; } = new Mock<IApiBusinessEntityAddressModelMapper>();
	}
}

/*<Codenesium>
    <Hash>4c11b889daa0eba7234770bcec31d916</Hash>
</Codenesium>*/
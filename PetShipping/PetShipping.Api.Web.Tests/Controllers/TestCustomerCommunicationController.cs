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
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "Controllers")]
	public partial class CustomerCommunicationControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var record = new ApiCustomerCommunicationServerResponseModel();
			var records = new List<ApiCustomerCommunicationServerResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCustomerCommunicationServerResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<List<ApiCustomerCommunicationServerResponseModel>>(new List<ApiCustomerCommunicationServerResponseModel>()));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0, string.Empty);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiCustomerCommunicationServerResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCustomerCommunicationServerResponseModel()));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiCustomerCommunicationServerResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCustomerCommunicationServerResponseModel>(null));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.CreateResponse(null as ApiCustomerCommunicationServerResponseModel);

			mockResponse.SetRecord(new ApiCustomerCommunicationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResponse));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCustomerCommunicationServerRequestModel>();
			records.Add(new ApiCustomerCommunicationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as CreateResponse<List<ApiCustomerCommunicationServerResponseModel>>;
			result.Success.Should().BeTrue();
			result.Record.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(null as ApiCustomerCommunicationServerResponseModel);
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResponse.Object));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiCustomerCommunicationServerRequestModel>();
			records.Add(new ApiCustomerCommunicationServerRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();

			var mockResponse = ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.CreateResponse(null as ApiCustomerCommunicationServerResponseModel);

			mockResponse.SetRecord(new ApiCustomerCommunicationServerResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResponse));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCustomerCommunicationServerRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCustomerCommunicationServerResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(null as ApiCustomerCommunicationServerResponseModel);
			var mockRecord = new ApiCustomerCommunicationServerResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResponse.Object));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiCustomerCommunicationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()))
			.Callback<int, ApiCustomerCommunicationServerRequestModel>(
				(id, model) => model.CustomerId.Should().Be(1)
				)
			.Returns(Task.FromResult<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCustomerCommunicationServerResponseModel>(new ApiCustomerCommunicationServerResponseModel()));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCustomerCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCustomerCommunicationServerRequestModel>();
			patch.Replace(x => x.CustomerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCustomerCommunicationServerResponseModel>(null));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiCustomerCommunicationServerRequestModel>();
			patch.Replace(x => x.CustomerId, 1);

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCustomerCommunicationServerResponseModel()));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCustomerCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCustomerCommunicationServerRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiCustomerCommunicationServerResponseModel()));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCustomerCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCustomerCommunicationServerRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCustomerCommunicationServerResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiCustomerCommunicationServerResponseModel>(null));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCustomerCommunicationServerModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiCustomerCommunicationServerRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			CustomerCommunicationControllerMockFacade mock = new CustomerCommunicationControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			CustomerCommunicationController controller = new CustomerCommunicationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class CustomerCommunicationControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<CustomerCommunicationController>> LoggerMock { get; set; } = new Mock<ILogger<CustomerCommunicationController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ICustomerCommunicationService> ServiceMock { get; set; } = new Mock<ICustomerCommunicationService>();

		public Mock<IApiCustomerCommunicationServerModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCustomerCommunicationServerModelMapper>();
	}
}

/*<Codenesium>
    <Hash>2da7d92876d5477dda29628385621f40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
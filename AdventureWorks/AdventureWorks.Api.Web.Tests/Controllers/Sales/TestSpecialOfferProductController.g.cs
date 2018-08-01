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
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "Controllers")]
	public partial class SpecialOfferProductControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var record = new ApiSpecialOfferProductResponseModel();
			var records = new List<ApiSpecialOfferProductResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpecialOfferProductResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiSpecialOfferProductResponseModel>>(new List<ApiSpecialOfferProductResponseModel>()));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiSpecialOfferProductResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpecialOfferProductResponseModel()));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiSpecialOfferProductResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpecialOfferProductResponseModel>(null));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpecialOfferProductResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpecialOfferProductResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpecialOfferProductResponseModel>>(mockResponse));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpecialOfferProductRequestModel>();
			records.Add(new ApiSpecialOfferProductRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiSpecialOfferProductResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpecialOfferProductResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpecialOfferProductResponseModel>>(mockResponse.Object));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiSpecialOfferProductRequestModel>();
			records.Add(new ApiSpecialOfferProductRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();

			var mockResponse = new CreateResponse<ApiSpecialOfferProductResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiSpecialOfferProductResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpecialOfferProductResponseModel>>(mockResponse));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpecialOfferProductRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiSpecialOfferProductResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiSpecialOfferProductResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiSpecialOfferProductResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiSpecialOfferProductResponseModel>>(mockResponse.Object));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiSpecialOfferProductRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpecialOfferProductResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()))
			.Callback<int, ApiSpecialOfferProductRequestModel>(
				(id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
				)
			.Returns(Task.FromResult<UpdateResponse<ApiSpecialOfferProductResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpecialOfferProductResponseModel>(new ApiSpecialOfferProductResponseModel()));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpecialOfferProductModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpecialOfferProductRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpecialOfferProductResponseModel>(null));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiSpecialOfferProductRequestModel>();
			patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpecialOfferProductResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpecialOfferProductResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpecialOfferProductResponseModel()));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpecialOfferProductModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpecialOfferProductRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpecialOfferProductResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpecialOfferProductResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiSpecialOfferProductResponseModel()));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpecialOfferProductModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpecialOfferProductRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiSpecialOfferProductResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiSpecialOfferProductResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiSpecialOfferProductResponseModel>(null));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiSpecialOfferProductModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiSpecialOfferProductRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			SpecialOfferProductControllerMockFacade mock = new SpecialOfferProductControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			SpecialOfferProductController controller = new SpecialOfferProductController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class SpecialOfferProductControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<SpecialOfferProductController>> LoggerMock { get; set; } = new Mock<ILogger<SpecialOfferProductController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<ISpecialOfferProductService> ServiceMock { get; set; } = new Mock<ISpecialOfferProductService>();

		public Mock<IApiSpecialOfferProductModelMapper> ModelMapperMock { get; set; } = new Mock<IApiSpecialOfferProductModelMapper>();
	}
}

/*<Codenesium>
    <Hash>1dc5ab239b7a9c2993eab27f904e8bfa</Hash>
</Codenesium>*/
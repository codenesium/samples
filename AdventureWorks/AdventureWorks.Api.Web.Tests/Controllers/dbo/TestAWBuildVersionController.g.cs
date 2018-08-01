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
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "Controllers")]
	public partial class AWBuildVersionControllerTests
	{
		[Fact]
		public async void All_Exists()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var record = new ApiAWBuildVersionResponseModel();
			var records = new List<ApiAWBuildVersionResponseModel>();
			records.Add(record);
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiAWBuildVersionResponseModel>;
			items.Count.Should().Be(1);
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void All_Not_Exists()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiAWBuildVersionResponseModel>>(new List<ApiAWBuildVersionResponseModel>()));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.All(1000, 0);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var items = (response as OkObjectResult).Value as List<ApiAWBuildVersionResponseModel>;
			items.Should().BeEmpty();
			mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Exists()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiAWBuildVersionResponseModel()));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Get(default(int));

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var record = (response as OkObjectResult).Value as ApiAWBuildVersionResponseModel;
			record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_Not_Exists()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiAWBuildVersionResponseModel>(null));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiAWBuildVersionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiAWBuildVersionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiAWBuildVersionResponseModel>>(mockResponse));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiAWBuildVersionRequestModel>();
			records.Add(new ApiAWBuildVersionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			var result = (response as OkObjectResult).Value as List<ApiAWBuildVersionResponseModel>;
			result.Should().NotBeEmpty();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void BulkInsert_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiAWBuildVersionResponseModel>>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiAWBuildVersionResponseModel>>(mockResponse.Object));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var records = new List<ApiAWBuildVersionRequestModel>();
			records.Add(new ApiAWBuildVersionRequestModel());
			IActionResult response = await controller.BulkInsert(records);

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Create_No_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();

			var mockResponse = new CreateResponse<ApiAWBuildVersionResponseModel>(new FluentValidation.Results.ValidationResult());
			mockResponse.SetRecord(new ApiAWBuildVersionResponseModel());
			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiAWBuildVersionResponseModel>>(mockResponse));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiAWBuildVersionRequestModel());

			response.Should().BeOfType<CreatedResult>();
			(response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
			var createResponse = (response as CreatedResult).Value as CreateResponse<ApiAWBuildVersionResponseModel>;
			createResponse.Record.Should().NotBeNull();
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();

			var mockResponse = new Mock<CreateResponse<ApiAWBuildVersionResponseModel>>(new FluentValidation.Results.ValidationResult());
			var mockRecord = new ApiAWBuildVersionResponseModel();

			mockResponse.SetupGet(x => x.Success).Returns(false);

			mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiAWBuildVersionResponseModel>>(mockResponse.Object));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Create(new ApiAWBuildVersionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Patch_No_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiAWBuildVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>()))
			.Callback<int, ApiAWBuildVersionRequestModel>(
				(id, model) => model.Database_Version.Should().Be("A")
				)
			.Returns(Task.FromResult<UpdateResponse<ApiAWBuildVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiAWBuildVersionResponseModel>(new ApiAWBuildVersionResponseModel()));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiAWBuildVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiAWBuildVersionRequestModel>();
			patch.Replace(x => x.Database_Version, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Patch_Record_Not_Found()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiAWBuildVersionResponseModel>(null));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			var patch = new JsonPatchDocument<ApiAWBuildVersionRequestModel>();
			patch.Replace(x => x.Database_Version, "A");

			IActionResult response = await controller.Patch(default(int), patch);

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Update_No_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiAWBuildVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiAWBuildVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiAWBuildVersionResponseModel()));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiAWBuildVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiAWBuildVersionRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiAWBuildVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiAWBuildVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiAWBuildVersionResponseModel()));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiAWBuildVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiAWBuildVersionRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>()));
		}

		[Fact]
		public async void Update_NotFound()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<UpdateResponse<ApiAWBuildVersionResponseModel>>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiAWBuildVersionRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiAWBuildVersionResponseModel>>(mockResult.Object));
			mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiAWBuildVersionResponseModel>(null));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiAWBuildVersionModelMapper());
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Update(default(int), new ApiAWBuildVersionRequestModel());

			response.Should().BeOfType<StatusCodeResult>();
			(response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
			mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_No_Errors()
		{
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(true);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
			AWBuildVersionControllerMockFacade mock = new AWBuildVersionControllerMockFacade();
			var mockResult = new Mock<ActionResponse>();
			mockResult.SetupGet(x => x.Success).Returns(false);
			mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
			AWBuildVersionController controller = new AWBuildVersionController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();

			IActionResult response = await controller.Delete(default(int));

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
			mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
		}
	}

	public class AWBuildVersionControllerMockFacade
	{
		public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

		public Mock<ILogger<AWBuildVersionController>> LoggerMock { get; set; } = new Mock<ILogger<AWBuildVersionController>>();

		public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

		public Mock<IAWBuildVersionService> ServiceMock { get; set; } = new Mock<IAWBuildVersionService>();

		public Mock<IApiAWBuildVersionModelMapper> ModelMapperMock { get; set; } = new Mock<IApiAWBuildVersionModelMapper>();
	}
}

/*<Codenesium>
    <Hash>9dc00e37e950a1747371bd80d5ca09ea</Hash>
</Codenesium>*/
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
    <Hash>9dabed5052fdda0d242edc0869e057dc</Hash>
</Codenesium>*/
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
    <Hash>c9c8a58e4ec30235703bbf5e6317d9d5</Hash>
</Codenesium>*/
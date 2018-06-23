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
        [Trait("Table", "CountryRegionCurrency")]
        [Trait("Area", "Controllers")]
        public partial class CountryRegionCurrencyControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var record = new ApiCountryRegionCurrencyResponseModel();
                        var records = new List<ApiCountryRegionCurrencyResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiCountryRegionCurrencyResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiCountryRegionCurrencyResponseModel>>(new List<ApiCountryRegionCurrencyResponseModel>()));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiCountryRegionCurrencyResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCountryRegionCurrencyResponseModel()));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiCountryRegionCurrencyResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionCurrencyResponseModel>(null));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiCountryRegionCurrencyResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiCountryRegionCurrencyResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(mockResponse));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiCountryRegionCurrencyRequestModel>();
                        records.Add(new ApiCountryRegionCurrencyRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiCountryRegionCurrencyResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(mockResponse.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiCountryRegionCurrencyRequestModel>();
                        records.Add(new ApiCountryRegionCurrencyRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiCountryRegionCurrencyResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiCountryRegionCurrencyResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(mockResponse));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiCountryRegionCurrencyRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiCountryRegionCurrencyResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiCountryRegionCurrencyResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCountryRegionCurrencyResponseModel>>(mockResponse.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiCountryRegionCurrencyRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>()))
                        .Callback<string, ApiCountryRegionCurrencyRequestModel>(
                                (id, model) => model.CurrencyCode.Should().Be("A")
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionCurrencyResponseModel>(new ApiCountryRegionCurrencyResponseModel()));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiCountryRegionCurrencyRequestModel>();
                        patch.Replace(x => x.CurrencyCode, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCountryRegionCurrencyResponseModel>(null));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiCountryRegionCurrencyRequestModel>();
                        patch.Replace(x => x.CurrencyCode, "A");

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiCountryRegionCurrencyRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiCountryRegionCurrencyRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        CountryRegionCurrencyControllerMockFacade mock = new CountryRegionCurrencyControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CountryRegionCurrencyController controller = new CountryRegionCurrencyController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class CountryRegionCurrencyControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<CountryRegionCurrencyController>> LoggerMock { get; set; } = new Mock<ILogger<CountryRegionCurrencyController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ICountryRegionCurrencyService> ServiceMock { get; set; } = new Mock<ICountryRegionCurrencyService>();
        }
}

/*<Codenesium>
    <Hash>e0ebf30fe5439f0e2d80a4c4d3586cbb</Hash>
</Codenesium>*/
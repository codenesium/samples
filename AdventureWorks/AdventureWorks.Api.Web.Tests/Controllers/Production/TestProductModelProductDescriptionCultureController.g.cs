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
        [Trait("Table", "ProductModelProductDescriptionCulture")]
        [Trait("Area", "Controllers")]
        public partial class ProductModelProductDescriptionCultureControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var record = new ApiProductModelProductDescriptionCultureResponseModel();
                        var records = new List<ApiProductModelProductDescriptionCultureResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProductModelProductDescriptionCultureResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductModelProductDescriptionCultureResponseModel>>(new List<ApiProductModelProductDescriptionCultureResponseModel>()));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProductModelProductDescriptionCultureResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductModelProductDescriptionCultureResponseModel()));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiProductModelProductDescriptionCultureResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelProductDescriptionCultureResponseModel>(null));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProductModelProductDescriptionCultureResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(mockResponse));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProductModelProductDescriptionCultureRequestModel>();
                        records.Add(new ApiProductModelProductDescriptionCultureRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiProductModelProductDescriptionCultureResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(mockResponse.Object));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProductModelProductDescriptionCultureRequestModel>();
                        records.Add(new ApiProductModelProductDescriptionCultureRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProductModelProductDescriptionCultureResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(mockResponse));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProductModelProductDescriptionCultureRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiProductModelProductDescriptionCultureResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiProductModelProductDescriptionCultureResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>>(mockResponse.Object));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProductModelProductDescriptionCultureRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()))
                        .Callback<int, ApiProductModelProductDescriptionCultureRequestModel>(
                                (id, model) => model.CultureID.Should().Be("A")
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelProductDescriptionCultureResponseModel>(new ApiProductModelProductDescriptionCultureResponseModel()));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductModelProductDescriptionCultureModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel>();
                        patch.Replace(x => x.CultureID, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelProductDescriptionCultureResponseModel>(null));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel>();
                        patch.Replace(x => x.CultureID, "A");

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductModelProductDescriptionCultureResponseModel()));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductModelProductDescriptionCultureModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiProductModelProductDescriptionCultureRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductModelProductDescriptionCultureResponseModel()));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductModelProductDescriptionCultureModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiProductModelProductDescriptionCultureRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelProductDescriptionCultureRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelProductDescriptionCultureResponseModel>(null));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiProductModelProductDescriptionCultureModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiProductModelProductDescriptionCultureRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ProductModelProductDescriptionCultureControllerMockFacade mock = new ProductModelProductDescriptionCultureControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelProductDescriptionCultureController controller = new ProductModelProductDescriptionCultureController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class ProductModelProductDescriptionCultureControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ProductModelProductDescriptionCultureController>> LoggerMock { get; set; } = new Mock<ILogger<ProductModelProductDescriptionCultureController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IProductModelProductDescriptionCultureService> ServiceMock { get; set; } = new Mock<IProductModelProductDescriptionCultureService>();

                public Mock<IApiProductModelProductDescriptionCultureModelMapper> ModelMapperMock { get; set; } = new Mock<IApiProductModelProductDescriptionCultureModelMapper>();
        }
}

/*<Codenesium>
    <Hash>61dc07554444d846955463dd562695bc</Hash>
</Codenesium>*/
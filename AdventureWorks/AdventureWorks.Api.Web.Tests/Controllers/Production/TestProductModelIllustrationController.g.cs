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
        [Trait("Table", "ProductModelIllustration")]
        [Trait("Area", "Controllers")]
        public partial class ProductModelIllustrationControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var record = new ApiProductModelIllustrationResponseModel();
                        var records = new List<ApiProductModelIllustrationResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProductModelIllustrationResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiProductModelIllustrationResponseModel>>(new List<ApiProductModelIllustrationResponseModel>()));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiProductModelIllustrationResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiProductModelIllustrationResponseModel()));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiProductModelIllustrationResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelIllustrationResponseModel>(null));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProductModelIllustrationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProductModelIllustrationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelIllustrationResponseModel>>(mockResponse));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProductModelIllustrationRequestModel>();
                        records.Add(new ApiProductModelIllustrationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiProductModelIllustrationResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProductModelIllustrationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelIllustrationResponseModel>>(mockResponse.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiProductModelIllustrationRequestModel>();
                        records.Add(new ApiProductModelIllustrationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiProductModelIllustrationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiProductModelIllustrationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelIllustrationResponseModel>>(mockResponse));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProductModelIllustrationRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiProductModelIllustrationResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiProductModelIllustrationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiProductModelIllustrationResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiProductModelIllustrationResponseModel>>(mockResponse.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiProductModelIllustrationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>()))
                        .Callback<int, ApiProductModelIllustrationRequestModel>(
                                (id, model) => model.IllustrationID.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelIllustrationResponseModel>(new ApiProductModelIllustrationResponseModel()));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProductModelIllustrationRequestModel>();
                        patch.Replace(x => x.IllustrationID, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiProductModelIllustrationResponseModel>(null));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiProductModelIllustrationRequestModel>();
                        patch.Replace(x => x.IllustrationID, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiProductModelIllustrationRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiProductModelIllustrationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        ProductModelIllustrationControllerMockFacade mock = new ProductModelIllustrationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ProductModelIllustrationController controller = new ProductModelIllustrationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class ProductModelIllustrationControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ProductModelIllustrationController>> LoggerMock { get; set; } = new Mock<ILogger<ProductModelIllustrationController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IProductModelIllustrationService> ServiceMock { get; set; } = new Mock<IProductModelIllustrationService>();
        }
}

/*<Codenesium>
    <Hash>de229dc9f96c695a2586bb7c923eee14</Hash>
</Codenesium>*/
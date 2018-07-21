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
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "Controllers")]
        public partial class ShoppingCartItemControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var record = new ApiShoppingCartItemResponseModel();
                        var records = new List<ApiShoppingCartItemResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiShoppingCartItemResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiShoppingCartItemResponseModel>>(new List<ApiShoppingCartItemResponseModel>()));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiShoppingCartItemResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemResponseModel()));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiShoppingCartItemResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemResponseModel>(null));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiShoppingCartItemResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiShoppingCartItemResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemResponseModel>>(mockResponse));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiShoppingCartItemRequestModel>();
                        records.Add(new ApiShoppingCartItemRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiShoppingCartItemResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiShoppingCartItemResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemResponseModel>>(mockResponse.Object));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiShoppingCartItemRequestModel>();
                        records.Add(new ApiShoppingCartItemRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiShoppingCartItemResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiShoppingCartItemResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemResponseModel>>(mockResponse));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiShoppingCartItemRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiShoppingCartItemResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiShoppingCartItemResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiShoppingCartItemResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiShoppingCartItemResponseModel>>(mockResponse.Object));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiShoppingCartItemRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>()))
                        .Callback<int, ApiShoppingCartItemRequestModel>(
                                (id, model) => model.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemResponseModel>(new ApiShoppingCartItemResponseModel()));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiShoppingCartItemRequestModel>();
                        patch.Replace(x => x.DateCreated, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemResponseModel>(null));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiShoppingCartItemRequestModel>();
                        patch.Replace(x => x.DateCreated, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemResponseModel()));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiShoppingCartItemResponseModel()));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiShoppingCartItemResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiShoppingCartItemRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiShoppingCartItemResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiShoppingCartItemResponseModel>(null));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiShoppingCartItemModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiShoppingCartItemRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ShoppingCartItemControllerMockFacade mock = new ShoppingCartItemControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ShoppingCartItemController controller = new ShoppingCartItemController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class ShoppingCartItemControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ShoppingCartItemController>> LoggerMock { get; set; } = new Mock<ILogger<ShoppingCartItemController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IShoppingCartItemService> ServiceMock { get; set; } = new Mock<IShoppingCartItemService>();

                public Mock<IApiShoppingCartItemModelMapper> ModelMapperMock { get; set; } = new Mock<IApiShoppingCartItemModelMapper>();
        }
}

/*<Codenesium>
    <Hash>a765e7442a408e6c9e904a4e79cab732</Hash>
</Codenesium>*/
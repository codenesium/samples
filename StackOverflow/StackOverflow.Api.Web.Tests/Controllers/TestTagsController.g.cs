using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Tags")]
        [Trait("Area", "Controllers")]
        public partial class TagsControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var record = new ApiTagsResponseModel();
                        var records = new List<ApiTagsResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTagsResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiTagsResponseModel>>(new List<ApiTagsResponseModel>()));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiTagsResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTagsResponseModel()));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiTagsResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTagsResponseModel>(null));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTagsResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTagsResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTagsResponseModel>>(mockResponse));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTagsRequestModel>();
                        records.Add(new ApiTagsRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiTagsResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTagsResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTagsResponseModel>>(mockResponse.Object));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiTagsRequestModel>();
                        records.Add(new ApiTagsRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiTagsResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiTagsResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTagsResponseModel>>(mockResponse));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTagsRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiTagsResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiTagsResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiTagsResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiTagsResponseModel>>(mockResponse.Object));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiTagsRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>()))
                        .Callback<int, ApiTagsRequestModel>(
                                (id, model) => model.Count.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTagsResponseModel>(new ApiTagsResponseModel()));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTagsModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTagsRequestModel>();
                        patch.Replace(x => x.Count, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTagsResponseModel>(null));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiTagsRequestModel>();
                        patch.Replace(x => x.Count, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTagsResponseModel()));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTagsModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTagsRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiTagsResponseModel()));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTagsModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTagsRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiTagsRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiTagsResponseModel>(null));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiTagsModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiTagsRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        TagsControllerMockFacade mock = new TagsControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        TagsController controller = new TagsController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class TagsControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<TagsController>> LoggerMock { get; set; } = new Mock<ILogger<TagsController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ITagsService> ServiceMock { get; set; } = new Mock<ITagsService>();

                public Mock<IApiTagsModelMapper> ModelMapperMock { get; set; } = new Mock<IApiTagsModelMapper>();
        }
}

/*<Codenesium>
    <Hash>8457a31f29d9fb262b86ea5847f10dcd</Hash>
</Codenesium>*/
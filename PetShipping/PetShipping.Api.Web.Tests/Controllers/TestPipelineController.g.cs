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
        [Trait("Table", "Pipeline")]
        [Trait("Area", "Controllers")]
        public partial class PipelineControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var record = new ApiPipelineResponseModel();
                        var records = new List<ApiPipelineResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPipelineResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPipelineResponseModel>>(new List<ApiPipelineResponseModel>()));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPipelineResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineResponseModel()));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiPipelineResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineResponseModel>(null));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPipelineResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPipelineResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineResponseModel>>(mockResponse));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPipelineRequestModel>();
                        records.Add(new ApiPipelineRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiPipelineResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPipelineResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineResponseModel>>(mockResponse.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPipelineRequestModel>();
                        records.Add(new ApiPipelineRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPipelineResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPipelineResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineResponseModel>>(mockResponse));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPipelineRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiPipelineResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPipelineResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiPipelineResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineResponseModel>>(mockResponse.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPipelineRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>()))
                        .Callback<int, ApiPipelineRequestModel>(
                                (id, model) => model.PipelineStatusId.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineResponseModel>(new ApiPipelineResponseModel()));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiPipelineRequestModel>();
                        patch.Replace(x => x.PipelineStatusId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineResponseModel>(null));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiPipelineRequestModel>();
                        patch.Replace(x => x.PipelineStatusId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPipelineRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPipelineRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        PipelineControllerMockFacade mock = new PipelineControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineController controller = new PipelineController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class PipelineControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<PipelineController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IPipelineService> ServiceMock { get; set; } = new Mock<IPipelineService>();
        }
}

/*<Codenesium>
    <Hash>470037400032605150ec885981e987e0</Hash>
</Codenesium>*/
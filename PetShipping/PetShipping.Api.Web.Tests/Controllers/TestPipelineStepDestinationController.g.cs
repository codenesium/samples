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
        [Trait("Table", "PipelineStepDestination")]
        [Trait("Area", "Controllers")]
        public partial class PipelineStepDestinationControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var record = new ApiPipelineStepDestinationResponseModel();
                        var records = new List<ApiPipelineStepDestinationResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPipelineStepDestinationResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiPipelineStepDestinationResponseModel>>(new List<ApiPipelineStepDestinationResponseModel>()));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiPipelineStepDestinationResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepDestinationResponseModel()));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiPipelineStepDestinationResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepDestinationResponseModel>(null));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPipelineStepDestinationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPipelineStepDestinationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepDestinationResponseModel>>(mockResponse));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPipelineStepDestinationRequestModel>();
                        records.Add(new ApiPipelineStepDestinationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiPipelineStepDestinationResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPipelineStepDestinationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepDestinationResponseModel>>(mockResponse.Object));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiPipelineStepDestinationRequestModel>();
                        records.Add(new ApiPipelineStepDestinationRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiPipelineStepDestinationResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiPipelineStepDestinationResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepDestinationResponseModel>>(mockResponse));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPipelineStepDestinationRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiPipelineStepDestinationResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiPipelineStepDestinationResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiPipelineStepDestinationResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiPipelineStepDestinationResponseModel>>(mockResponse.Object));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiPipelineStepDestinationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiPipelineStepDestinationResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>()))
                        .Callback<int, ApiPipelineStepDestinationRequestModel>(
                                (id, model) => model.DestinationId.Should().Be(1)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiPipelineStepDestinationResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepDestinationResponseModel>(new ApiPipelineStepDestinationResponseModel()));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepDestinationModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiPipelineStepDestinationRequestModel>();
                        patch.Replace(x => x.DestinationId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepDestinationResponseModel>(null));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiPipelineStepDestinationRequestModel>();
                        patch.Replace(x => x.DestinationId, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiPipelineStepDestinationResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepDestinationResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepDestinationResponseModel()));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepDestinationModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPipelineStepDestinationRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiPipelineStepDestinationResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepDestinationResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiPipelineStepDestinationResponseModel()));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepDestinationModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPipelineStepDestinationRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiPipelineStepDestinationResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiPipelineStepDestinationResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiPipelineStepDestinationResponseModel>(null));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiPipelineStepDestinationModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiPipelineStepDestinationRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        PipelineStepDestinationControllerMockFacade mock = new PipelineStepDestinationControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        PipelineStepDestinationController controller = new PipelineStepDestinationController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class PipelineStepDestinationControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<PipelineStepDestinationController>> LoggerMock { get; set; } = new Mock<ILogger<PipelineStepDestinationController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IPipelineStepDestinationService> ServiceMock { get; set; } = new Mock<IPipelineStepDestinationService>();

                public Mock<IApiPipelineStepDestinationModelMapper> ModelMapperMock { get; set; } = new Mock<IApiPipelineStepDestinationModelMapper>();
        }
}

/*<Codenesium>
    <Hash>edb9e1c437a7c6dc442ea993e74e048b</Hash>
</Codenesium>*/
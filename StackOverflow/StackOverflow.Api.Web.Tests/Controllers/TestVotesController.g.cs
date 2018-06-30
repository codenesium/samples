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
        [Trait("Table", "Votes")]
        [Trait("Area", "Controllers")]
        public partial class VotesControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var record = new ApiVotesResponseModel();
                        var records = new List<ApiVotesResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiVotesResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiVotesResponseModel>>(new List<ApiVotesResponseModel>()));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiVotesResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVotesResponseModel()));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiVotesResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVotesResponseModel>(null));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiVotesResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiVotesResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVotesResponseModel>>(mockResponse));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiVotesRequestModel>();
                        records.Add(new ApiVotesRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiVotesResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiVotesResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVotesResponseModel>>(mockResponse.Object));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiVotesRequestModel>();
                        records.Add(new ApiVotesRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiVotesResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiVotesResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVotesResponseModel>>(mockResponse));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiVotesRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiVotesResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiVotesResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiVotesResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiVotesResponseModel>>(mockResponse.Object));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiVotesRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>()))
                        .Callback<int, ApiVotesRequestModel>(
                                (id, model) => model.BountyAmount.Should().Be(1)
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVotesResponseModel>(new ApiVotesResponseModel()));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVotesModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiVotesRequestModel>();
                        patch.Replace(x => x.BountyAmount, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVotesResponseModel>(null));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiVotesRequestModel>();
                        patch.Replace(x => x.BountyAmount, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVotesResponseModel()));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVotesModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiVotesRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiVotesResponseModel()));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVotesModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiVotesRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiVotesRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiVotesResponseModel>(null));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiVotesModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiVotesRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        VotesControllerMockFacade mock = new VotesControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        VotesController controller = new VotesController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class VotesControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<VotesController>> LoggerMock { get; set; } = new Mock<ILogger<VotesController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IVotesService> ServiceMock { get; set; } = new Mock<IVotesService>();

                public Mock<IApiVotesModelMapper> ModelMapperMock { get; set; } = new Mock<IApiVotesModelMapper>();
        }
}

/*<Codenesium>
    <Hash>df8f3c1a216bb12302871f4809aea6d8</Hash>
</Codenesium>*/
using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Artifact")]
        [Trait("Area", "Controllers")]
        public partial class ArtifactControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var record = new ApiArtifactResponseModel();
                        var records = new List<ApiArtifactResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiArtifactResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiArtifactResponseModel>>(new List<ApiArtifactResponseModel>()));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiArtifactResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiArtifactResponseModel()));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiArtifactResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiArtifactResponseModel>(null));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiArtifactResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiArtifactResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiArtifactResponseModel>>(mockResponse));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiArtifactRequestModel>();
                        records.Add(new ApiArtifactRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiArtifactResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiArtifactResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiArtifactResponseModel>>(mockResponse.Object));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiArtifactRequestModel>();
                        records.Add(new ApiArtifactRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiArtifactResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiArtifactResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiArtifactResponseModel>>(mockResponse));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiArtifactRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiArtifactResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiArtifactResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiArtifactResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiArtifactResponseModel>>(mockResponse.Object));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiArtifactRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>()))
                        .Callback<string, ApiArtifactRequestModel>(
                                (id, model) => model.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiArtifactResponseModel>(new ApiArtifactResponseModel()));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiArtifactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiArtifactRequestModel>();
                        patch.Replace(x => x.Created, DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiArtifactResponseModel>(null));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiArtifactRequestModel>();
                        patch.Replace(x => x.Created, DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiArtifactResponseModel()));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiArtifactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiArtifactRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiArtifactResponseModel()));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiArtifactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiArtifactRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiArtifactResponseModel>(null));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiArtifactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiArtifactRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        ArtifactControllerMockFacade mock = new ArtifactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        ArtifactController controller = new ArtifactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class ArtifactControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<ArtifactController>> LoggerMock { get; set; } = new Mock<ILogger<ArtifactController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IArtifactService> ServiceMock { get; set; } = new Mock<IArtifactService>();

                public Mock<IApiArtifactModelMapper> ModelMapperMock { get; set; } = new Mock<IApiArtifactModelMapper>();
        }
}

/*<Codenesium>
    <Hash>a3b67a12e8eed64f1e5980741729ffb1</Hash>
</Codenesium>*/
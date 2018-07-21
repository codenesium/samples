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
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "Controllers")]
        public partial class CommunityActionTemplateControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var record = new ApiCommunityActionTemplateResponseModel();
                        var records = new List<ApiCommunityActionTemplateResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiCommunityActionTemplateResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiCommunityActionTemplateResponseModel>>(new List<ApiCommunityActionTemplateResponseModel>()));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiCommunityActionTemplateResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCommunityActionTemplateResponseModel()));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(string));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiCommunityActionTemplateResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCommunityActionTemplateResponseModel>(null));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiCommunityActionTemplateResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiCommunityActionTemplateResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCommunityActionTemplateResponseModel>>(mockResponse));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiCommunityActionTemplateRequestModel>();
                        records.Add(new ApiCommunityActionTemplateRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiCommunityActionTemplateResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiCommunityActionTemplateResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCommunityActionTemplateResponseModel>>(mockResponse.Object));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiCommunityActionTemplateRequestModel>();
                        records.Add(new ApiCommunityActionTemplateRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiCommunityActionTemplateResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiCommunityActionTemplateResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCommunityActionTemplateResponseModel>>(mockResponse));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiCommunityActionTemplateRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiCommunityActionTemplateResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiCommunityActionTemplateResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiCommunityActionTemplateResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiCommunityActionTemplateResponseModel>>(mockResponse.Object));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiCommunityActionTemplateRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiCommunityActionTemplateResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>()))
                        .Callback<string, ApiCommunityActionTemplateRequestModel>(
                                (id, model) => model.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"))
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiCommunityActionTemplateResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCommunityActionTemplateResponseModel>(new ApiCommunityActionTemplateResponseModel()));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCommunityActionTemplateModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiCommunityActionTemplateRequestModel>();
                        patch.Replace(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCommunityActionTemplateResponseModel>(null));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiCommunityActionTemplateRequestModel>();
                        patch.Replace(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        IActionResult response = await controller.Patch(default(string), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiCommunityActionTemplateResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCommunityActionTemplateResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCommunityActionTemplateResponseModel()));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCommunityActionTemplateModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiCommunityActionTemplateRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiCommunityActionTemplateResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCommunityActionTemplateResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiCommunityActionTemplateResponseModel()));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCommunityActionTemplateModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiCommunityActionTemplateRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiCommunityActionTemplateResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiCommunityActionTemplateResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiCommunityActionTemplateResponseModel>(null));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiCommunityActionTemplateModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(string), new ApiCommunityActionTemplateRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        CommunityActionTemplateControllerMockFacade mock = new CommunityActionTemplateControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        CommunityActionTemplateController controller = new CommunityActionTemplateController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(string));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<string>()));
                }
        }

        public class CommunityActionTemplateControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<CommunityActionTemplateController>> LoggerMock { get; set; } = new Mock<ILogger<CommunityActionTemplateController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<ICommunityActionTemplateService> ServiceMock { get; set; } = new Mock<ICommunityActionTemplateService>();

                public Mock<IApiCommunityActionTemplateModelMapper> ModelMapperMock { get; set; } = new Mock<IApiCommunityActionTemplateModelMapper>();
        }
}

/*<Codenesium>
    <Hash>40b0e5eab512464d69ad35f7804809e5</Hash>
</Codenesium>*/
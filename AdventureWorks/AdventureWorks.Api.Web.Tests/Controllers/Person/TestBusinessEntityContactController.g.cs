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
        [Trait("Table", "BusinessEntityContact")]
        [Trait("Area", "Controllers")]
        public partial class BusinessEntityContactControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var record = new ApiBusinessEntityContactResponseModel();
                        var records = new List<ApiBusinessEntityContactResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiBusinessEntityContactResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiBusinessEntityContactResponseModel>>(new List<ApiBusinessEntityContactResponseModel>()));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiBusinessEntityContactResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityContactResponseModel()));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiBusinessEntityContactResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityContactResponseModel>(null));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiBusinessEntityContactResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiBusinessEntityContactResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityContactResponseModel>>(mockResponse));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiBusinessEntityContactRequestModel>();
                        records.Add(new ApiBusinessEntityContactRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiBusinessEntityContactResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiBusinessEntityContactResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityContactResponseModel>>(mockResponse.Object));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiBusinessEntityContactRequestModel>();
                        records.Add(new ApiBusinessEntityContactRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiBusinessEntityContactResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiBusinessEntityContactResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityContactResponseModel>>(mockResponse));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiBusinessEntityContactRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var createResponse = (response as CreatedResult).Value as CreateResponse<ApiBusinessEntityContactResponseModel>;
                        createResponse.Record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiBusinessEntityContactResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiBusinessEntityContactResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityContactResponseModel>>(mockResponse.Object));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiBusinessEntityContactRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiBusinessEntityContactResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>()))
                        .Callback<int, ApiBusinessEntityContactRequestModel>(
                                (id, model) => model.ContactTypeID.Should().Be(1)
                                )
                        .Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityContactResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityContactResponseModel>(new ApiBusinessEntityContactResponseModel()));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityContactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiBusinessEntityContactRequestModel>();
                        patch.Replace(x => x.ContactTypeID, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityContactResponseModel>(null));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiBusinessEntityContactRequestModel>();
                        patch.Replace(x => x.ContactTypeID, 1);

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiBusinessEntityContactResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityContactResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityContactResponseModel()));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityContactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiBusinessEntityContactRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiBusinessEntityContactResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityContactResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityContactResponseModel()));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityContactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiBusinessEntityContactRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>()));
                }

                [Fact]
                public async void Update_NotFound()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<UpdateResponse<ApiBusinessEntityContactResponseModel>>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityContactRequestModel>())).Returns(Task.FromResult<UpdateResponse<ApiBusinessEntityContactResponseModel>>(mockResult.Object));
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityContactResponseModel>(null));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, new ApiBusinessEntityContactModelMapper());
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiBusinessEntityContactRequestModel());

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
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
                        BusinessEntityContactControllerMockFacade mock = new BusinessEntityContactControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityContactController controller = new BusinessEntityContactController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object, mock.ModelMapperMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class BusinessEntityContactControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<BusinessEntityContactController>> LoggerMock { get; set; } = new Mock<ILogger<BusinessEntityContactController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IBusinessEntityContactService> ServiceMock { get; set; } = new Mock<IBusinessEntityContactService>();

                public Mock<IApiBusinessEntityContactModelMapper> ModelMapperMock { get; set; } = new Mock<IApiBusinessEntityContactModelMapper>();
        }
}

/*<Codenesium>
    <Hash>ff16209d3f08098be6ed263c4aa4ef48</Hash>
</Codenesium>*/
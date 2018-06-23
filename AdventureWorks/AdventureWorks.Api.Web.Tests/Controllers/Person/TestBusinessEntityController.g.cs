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
        [Trait("Table", "BusinessEntity")]
        [Trait("Area", "Controllers")]
        public partial class BusinessEntityControllerTests
        {
                [Fact]
                public async void All_Exists()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var record = new ApiBusinessEntityResponseModel();
                        var records = new List<ApiBusinessEntityResponseModel>();
                        records.Add(record);
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiBusinessEntityResponseModel>;
                        items.Count.Should().Be(1);
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void All_Not_Exists()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ApiBusinessEntityResponseModel>>(new List<ApiBusinessEntityResponseModel>()));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.All(1000, 0);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var items = (response as OkObjectResult).Value as List<ApiBusinessEntityResponseModel>;
                        items.Should().BeEmpty();
                        mock.ServiceMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Exists()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ApiBusinessEntityResponseModel()));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Get(default(int));

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var record = (response as OkObjectResult).Value as ApiBusinessEntityResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_Not_Exists()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityResponseModel>(null));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiBusinessEntityResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiBusinessEntityResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityResponseModel>>(mockResponse));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiBusinessEntityRequestModel>();
                        records.Add(new ApiBusinessEntityRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        var result = (response as OkObjectResult).Value as List<ApiBusinessEntityResponseModel>;
                        result.Should().NotBeEmpty();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void BulkInsert_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiBusinessEntityResponseModel>>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityResponseModel>>(mockResponse.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var records = new List<ApiBusinessEntityRequestModel>();
                        records.Add(new ApiBusinessEntityRequestModel());
                        IActionResult response = await controller.BulkInsert(records);

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Create_No_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();

                        var mockResponse = new CreateResponse<ApiBusinessEntityResponseModel>(new FluentValidation.Results.ValidationResult());
                        mockResponse.SetRecord(new ApiBusinessEntityResponseModel());
                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityResponseModel>>(mockResponse));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiBusinessEntityRequestModel());

                        response.Should().BeOfType<CreatedResult>();
                        (response as CreatedResult).StatusCode.Should().Be((int)HttpStatusCode.Created);
                        var record = (response as CreatedResult).Value as ApiBusinessEntityResponseModel;
                        record.Should().NotBeNull();
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Create_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();

                        var mockResponse = new Mock<CreateResponse<ApiBusinessEntityResponseModel>>(new FluentValidation.Results.ValidationResult());
                        var mockRecord = new ApiBusinessEntityResponseModel();

                        mockResponse.SetupGet(x => x.Success).Returns(false);

                        mock.ServiceMock.Setup(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<CreateResponse<ApiBusinessEntityResponseModel>>(mockResponse.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);

                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Create(new ApiBusinessEntityRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Create(It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Patch_No_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>()))
                        .Callback<int, ApiBusinessEntityRequestModel>(
                                (id, model) => model.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"))
                                )
                        .Returns(Task.FromResult<ActionResponse>(mockResult.Object));

                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityResponseModel>(new ApiBusinessEntityResponseModel()));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiBusinessEntityRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Patch_Record_Not_Found()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mock.ServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ApiBusinessEntityResponseModel>(null));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        var patch = new JsonPatchDocument<ApiBusinessEntityRequestModel>();
                        patch.Replace(x => x.ModifiedDate, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        IActionResult response = await controller.Patch(default(int), patch);

                        response.Should().BeOfType<StatusCodeResult>();
                        (response as StatusCodeResult).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
                        mock.ServiceMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Update_No_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiBusinessEntityRequestModel());

                        response.Should().BeOfType<OkObjectResult>();
                        (response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Update_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Update(default(int), new ApiBusinessEntityRequestModel());

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>()));
                }

                [Fact]
                public async void Delete_No_Errors()
                {
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(true);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
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
                        BusinessEntityControllerMockFacade mock = new BusinessEntityControllerMockFacade();
                        var mockResult = new Mock<ActionResponse>();
                        mockResult.SetupGet(x => x.Success).Returns(false);
                        mock.ServiceMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.FromResult<ActionResponse>(mockResult.Object));
                        BusinessEntityController controller = new BusinessEntityController(mock.ApiSettingsMoc.Object, mock.LoggerMock.Object, mock.TransactionCoordinatorMock.Object, mock.ServiceMock.Object);
                        controller.ControllerContext = new ControllerContext();
                        controller.ControllerContext.HttpContext = new DefaultHttpContext();

                        IActionResult response = await controller.Delete(default(int));

                        response.Should().BeOfType<ObjectResult>();
                        (response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
                        mock.ServiceMock.Verify(x => x.Delete(It.IsAny<int>()));
                }
        }

        public class BusinessEntityControllerMockFacade
        {
                public Mock<ApiSettings> ApiSettingsMoc { get; set; } = new Mock<ApiSettings>();

                public Mock<ILogger<BusinessEntityController>> LoggerMock { get; set; } = new Mock<ILogger<BusinessEntityController>>();

                public Mock<ITransactionCoordinator> TransactionCoordinatorMock { get; set; } = new Mock<ITransactionCoordinator>();

                public Mock<IBusinessEntityService> ServiceMock { get; set; } = new Mock<IBusinessEntityService>();
        }
}

/*<Codenesium>
    <Hash>f3478608f11c9ecd8228151ee7f8a164</Hash>
</Codenesium>*/
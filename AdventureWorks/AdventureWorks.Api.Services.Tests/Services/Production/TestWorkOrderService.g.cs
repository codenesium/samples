using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrder")]
        [Trait("Area", "Services")]
        public partial class WorkOrderServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var records = new List<WorkOrder>();
                        records.Add(new WorkOrder());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var record = new WorkOrder();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiWorkOrderResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<WorkOrder>(null));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiWorkOrderResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var model = new ApiWorkOrderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrder>())).Returns(Task.FromResult(new WorkOrder()));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        CreateResponse<ApiWorkOrderResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<WorkOrder>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var model = new ApiWorkOrderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrder>())).Returns(Task.FromResult(new WorkOrder()));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<WorkOrder>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var model = new ApiWorkOrderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var records = new List<WorkOrder>();
                        records.Add(new WorkOrder());
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderResponseModel> response = await service.ByProductID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderResponseModel> response = await service.ByProductID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByScrapReasonID_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var records = new List<WorkOrder>();
                        records.Add(new WorkOrder());
                        mock.RepositoryMock.Setup(x => x.ByScrapReasonID(It.IsAny<Nullable<short>>())).Returns(Task.FromResult(records));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderResponseModel> response = await service.ByScrapReasonID(default(Nullable<short>));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByScrapReasonID(It.IsAny<Nullable<short>>()));
                }

                [Fact]
                public async void ByScrapReasonID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        mock.RepositoryMock.Setup(x => x.ByScrapReasonID(It.IsAny<Nullable<short>>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderResponseModel> response = await service.ByScrapReasonID(default(Nullable<short>));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByScrapReasonID(It.IsAny<Nullable<short>>()));
                }

                [Fact]
                public async void WorkOrderRoutings_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        var records = new List<WorkOrderRouting>();
                        records.Add(new WorkOrderRouting());
                        mock.RepositoryMock.Setup(x => x.WorkOrderRoutings(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderRoutingResponseModel> response = await service.WorkOrderRoutings(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.WorkOrderRoutings(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void WorkOrderRoutings_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IWorkOrderRepository>();
                        mock.RepositoryMock.Setup(x => x.WorkOrderRoutings(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrderRouting>>(new List<WorkOrderRouting>()));
                        var service = new WorkOrderService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderMapperMock,
                                                           mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                           mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderRoutingResponseModel> response = await service.WorkOrderRoutings(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.WorkOrderRoutings(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>2a7cce17c2510481850b367f2190c032</Hash>
</Codenesium>*/
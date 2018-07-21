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
        [Trait("Table", "Location")]
        [Trait("Area", "Services")]
        public partial class LocationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var records = new List<Location>();
                        records.Add(new Location());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiLocationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var record = new Location();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiLocationResponseModel response = await service.Get(default(short));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<Location>(null));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiLocationResponseModel response = await service.Get(default(short));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var model = new ApiLocationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        CreateResponse<ApiLocationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLocationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Location>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var model = new ApiLocationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Location>())).Returns(Task.FromResult(new Location()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        UpdateResponse<ApiLocationResponseModel> response = await service.Update(default(short), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiLocationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Location>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var model = new ApiLocationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ActionResponse response = await service.Delete(default(short));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
                        mock.ModelValidatorMockFactory.LocationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var record = new Location();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiLocationResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(null));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        ApiLocationResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ProductInventories_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var records = new List<ProductInventory>();
                        records.Add(new ProductInventory());
                        mock.RepositoryMock.Setup(x => x.ProductInventories(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiProductInventoryResponseModel> response = await service.ProductInventories(default(short));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductInventories(default(short), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void ProductInventories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        mock.RepositoryMock.Setup(x => x.ProductInventories(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductInventory>>(new List<ProductInventory>()));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiProductInventoryResponseModel> response = await service.ProductInventories(default(short));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ProductInventories(default(short), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void WorkOrderRoutings_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        var records = new List<WorkOrderRouting>();
                        records.Add(new WorkOrderRouting());
                        mock.RepositoryMock.Setup(x => x.WorkOrderRoutings(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderRoutingResponseModel> response = await service.WorkOrderRoutings(default(short));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.WorkOrderRoutings(default(short), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void WorkOrderRoutings_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILocationRepository>();
                        mock.RepositoryMock.Setup(x => x.WorkOrderRoutings(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrderRouting>>(new List<WorkOrderRouting>()));
                        var service = new LocationService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.LocationModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLLocationMapperMock,
                                                          mock.DALMapperMockFactory.DALLocationMapperMock,
                                                          mock.BOLMapperMockFactory.BOLProductInventoryMapperMock,
                                                          mock.DALMapperMockFactory.DALProductInventoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLWorkOrderRoutingMapperMock,
                                                          mock.DALMapperMockFactory.DALWorkOrderRoutingMapperMock);

                        List<ApiWorkOrderRoutingResponseModel> response = await service.WorkOrderRoutings(default(short));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.WorkOrderRoutings(default(short), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>a565b699ea0be4d8bb2f70ee79eecdf2</Hash>
</Codenesium>*/
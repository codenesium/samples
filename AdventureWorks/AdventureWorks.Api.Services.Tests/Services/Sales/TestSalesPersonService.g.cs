using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesPerson")]
        [Trait("Area", "Services")]
        public partial class SalesPersonServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var records = new List<SalesPerson>();
                        records.Add(new SalesPerson());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesPersonResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var record = new SalesPerson();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        ApiSalesPersonResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        ApiSalesPersonResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var model = new ApiSalesPersonRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPerson>())).Returns(Task.FromResult(new SalesPerson()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        CreateResponse<ApiSalesPersonResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesPerson>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var model = new ApiSalesPersonRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPerson>())).Returns(Task.FromResult(new SalesPerson()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesPerson>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var model = new ApiSalesPersonRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderHeaders_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var records = new List<SalesOrderHeader>();
                        records.Add(new SalesOrderHeader());
                        mock.RepositoryMock.Setup(x => x.SalesOrderHeaders(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeaders(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderHeaders(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderHeaders_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesOrderHeaders(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeaders(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderHeaders(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesPersonQuotaHistories_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var records = new List<SalesPersonQuotaHistory>();
                        records.Add(new SalesPersonQuotaHistory());
                        mock.RepositoryMock.Setup(x => x.SalesPersonQuotaHistories(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesPersonQuotaHistoryResponseModel> response = await service.SalesPersonQuotaHistories(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesPersonQuotaHistories(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesPersonQuotaHistories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesPersonQuotaHistories(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesPersonQuotaHistory>>(new List<SalesPersonQuotaHistory>()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesPersonQuotaHistoryResponseModel> response = await service.SalesPersonQuotaHistories(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesPersonQuotaHistories(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesTerritoryHistories_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var records = new List<SalesTerritoryHistory>();
                        records.Add(new SalesTerritoryHistory());
                        mock.RepositoryMock.Setup(x => x.SalesTerritoryHistories(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesTerritoryHistoryResponseModel> response = await service.SalesTerritoryHistories(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesTerritoryHistories(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesTerritoryHistories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesTerritoryHistories(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesTerritoryHistory>>(new List<SalesTerritoryHistory>()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiSalesTerritoryHistoryResponseModel> response = await service.SalesTerritoryHistories(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesTerritoryHistories(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Stores_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        var records = new List<Store>();
                        records.Add(new Store());
                        mock.RepositoryMock.Setup(x => x.Stores(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiStoreResponseModel> response = await service.Stores(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Stores(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Stores_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesPersonRepository>();
                        mock.RepositoryMock.Setup(x => x.Stores(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Store>>(new List<Store>()));
                        var service = new SalesPersonService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                             mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock,
                                                             mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                             mock.DALMapperMockFactory.DALStoreMapperMock);

                        List<ApiStoreResponseModel> response = await service.Stores(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Stores(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>b79a4dd9b610fae8eb2e8a1ca38cef3f</Hash>
</Codenesium>*/
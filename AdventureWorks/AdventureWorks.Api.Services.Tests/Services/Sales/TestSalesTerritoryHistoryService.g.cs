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
        [Trait("Table", "SalesTerritoryHistory")]
        [Trait("Area", "Services")]
        public partial class SalesTerritoryHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        var records = new List<SalesTerritoryHistory>();
                        records.Add(new SalesTerritoryHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        List<ApiSalesTerritoryHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        var record = new SalesTerritoryHistory();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        ApiSalesTerritoryHistoryResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritoryHistory>(null));
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        ApiSalesTerritoryHistoryResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        var model = new ApiSalesTerritoryHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTerritoryHistory>())).Returns(Task.FromResult(new SalesTerritoryHistory()));
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesTerritoryHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        var model = new ApiSalesTerritoryHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTerritoryHistory>())).Returns(Task.FromResult(new SalesTerritoryHistory()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritoryHistory()));
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        UpdateResponse<ApiSalesTerritoryHistoryResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesTerritoryHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISalesTerritoryHistoryRepository>();
                        var model = new ApiSalesTerritoryHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SalesTerritoryHistoryService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
                                                                       mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SalesTerritoryHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>884741074f97b32b4893782a4a2bad61</Hash>
</Codenesium>*/
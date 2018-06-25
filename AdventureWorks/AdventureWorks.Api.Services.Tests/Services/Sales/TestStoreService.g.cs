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
        [Trait("Table", "Store")]
        [Trait("Area", "Services")]
        public partial class StoreServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var records = new List<Store>();
                        records.Add(new Store());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiStoreResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var record = new Store();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ApiStoreResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Store>(null));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ApiStoreResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var model = new ApiStoreRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Store>())).Returns(Task.FromResult(new Store()));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        CreateResponse<ApiStoreResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StoreModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStoreRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Store>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var model = new ApiStoreRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Store>())).Returns(Task.FromResult(new Store()));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StoreModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStoreRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Store>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var model = new ApiStoreRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.StoreModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void BySalesPersonID_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var records = new List<Store>();
                        records.Add(new Store());
                        mock.RepositoryMock.Setup(x => x.BySalesPersonID(It.IsAny<int?>())).Returns(Task.FromResult(records));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiStoreResponseModel> response = await service.BySalesPersonID(default(int?));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BySalesPersonID(It.IsAny<int?>()));
                }

                [Fact]
                public async void BySalesPersonID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        mock.RepositoryMock.Setup(x => x.BySalesPersonID(It.IsAny<int?>())).Returns(Task.FromResult<List<Store>>(new List<Store>()));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiStoreResponseModel> response = await service.BySalesPersonID(default(int?));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BySalesPersonID(It.IsAny<int?>()));
                }

                [Fact]
                public async void ByDemographics_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var records = new List<Store>();
                        records.Add(new Store());
                        mock.RepositoryMock.Setup(x => x.ByDemographics(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiStoreResponseModel> response = await service.ByDemographics(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDemographics(It.IsAny<string>()));
                }

                [Fact]
                public async void ByDemographics_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        mock.RepositoryMock.Setup(x => x.ByDemographics(It.IsAny<string>())).Returns(Task.FromResult<List<Store>>(new List<Store>()));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiStoreResponseModel> response = await service.ByDemographics(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDemographics(It.IsAny<string>()));
                }

                [Fact]
                public async void Customers_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        var records = new List<Customer>();
                        records.Add(new Customer());
                        mock.RepositoryMock.Setup(x => x.Customers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiCustomerResponseModel> response = await service.Customers(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Customers(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Customers_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStoreRepository>();
                        mock.RepositoryMock.Setup(x => x.Customers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Customer>>(new List<Customer>()));
                        var service = new StoreService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.StoreModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLStoreMapperMock,
                                                       mock.DALMapperMockFactory.DALStoreMapperMock,
                                                       mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                       mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiCustomerResponseModel> response = await service.Customers(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Customers(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>bfac0ee7e2e240df0d74753bea458688</Hash>
</Codenesium>*/
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
        [Trait("Table", "BusinessEntity")]
        [Trait("Area", "Services")]
        public partial class BusinessEntityServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var records = new List<BusinessEntity>();
                        records.Add(new BusinessEntity());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiBusinessEntityResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var record = new BusinessEntity();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        ApiBusinessEntityResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<BusinessEntity>(null));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        ApiBusinessEntityResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var model = new ApiBusinessEntityRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntity>())).Returns(Task.FromResult(new BusinessEntity()));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        CreateResponse<ApiBusinessEntityResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BusinessEntity>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var model = new ApiBusinessEntityRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntity>())).Returns(Task.FromResult(new BusinessEntity()));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BusinessEntity>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var model = new ApiBusinessEntityRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityAddresses_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var records = new List<BusinessEntityAddress>();
                        records.Add(new BusinessEntityAddress());
                        mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityAddresses_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityAddress>>(new List<BusinessEntityAddress>()));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var records = new List<BusinessEntityContact>();
                        records.Add(new BusinessEntityContact());
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void BusinessEntityContacts_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        mock.RepositoryMock.Setup(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityContact>>(new List<BusinessEntityContact>()));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiBusinessEntityContactResponseModel> response = await service.BusinessEntityContacts(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BusinessEntityContacts(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void People_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        var records = new List<Person>();
                        records.Add(new Person());
                        mock.RepositoryMock.Setup(x => x.People(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiPersonResponseModel> response = await service.People(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.People(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void People_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityRepository>();
                        mock.RepositoryMock.Setup(x => x.People(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Person>>(new List<Person>()));
                        var service = new BusinessEntityService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.BusinessEntityModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock,
                                                                mock.BOLMapperMockFactory.BOLBusinessEntityContactMapperMock,
                                                                mock.DALMapperMockFactory.DALBusinessEntityContactMapperMock,
                                                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
                                                                mock.DALMapperMockFactory.DALPersonMapperMock);

                        List<ApiPersonResponseModel> response = await service.People(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.People(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>6a18d8b15df283c6c72de57afb839dab</Hash>
</Codenesium>*/
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
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "Services")]
        public partial class BusinessEntityAddressServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var records = new List<BusinessEntityAddress>();
                        records.Add(new BusinessEntityAddress());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var record = new BusinessEntityAddress();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        ApiBusinessEntityAddressResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<BusinessEntityAddress>(null));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        ApiBusinessEntityAddressResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var model = new ApiBusinessEntityAddressRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntityAddress>())).Returns(Task.FromResult(new BusinessEntityAddress()));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        CreateResponse<ApiBusinessEntityAddressResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBusinessEntityAddressRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<BusinessEntityAddress>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var model = new ApiBusinessEntityAddressRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<BusinessEntityAddress>())).Returns(Task.FromResult(new BusinessEntityAddress()));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBusinessEntityAddressRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<BusinessEntityAddress>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var model = new ApiBusinessEntityAddressRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByAddressID_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var records = new List<BusinessEntityAddress>();
                        records.Add(new BusinessEntityAddress());
                        mock.RepositoryMock.Setup(x => x.ByAddressID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.ByAddressID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAddressID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByAddressID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        mock.RepositoryMock.Setup(x => x.ByAddressID(It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityAddress>>(new List<BusinessEntityAddress>()));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.ByAddressID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAddressID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByAddressTypeID_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        var records = new List<BusinessEntityAddress>();
                        records.Add(new BusinessEntityAddress());
                        mock.RepositoryMock.Setup(x => x.ByAddressTypeID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.ByAddressTypeID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAddressTypeID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByAddressTypeID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBusinessEntityAddressRepository>();
                        mock.RepositoryMock.Setup(x => x.ByAddressTypeID(It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityAddress>>(new List<BusinessEntityAddress>()));
                        var service = new BusinessEntityAddressService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.BusinessEntityAddressModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
                                                                       mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

                        List<ApiBusinessEntityAddressResponseModel> response = await service.ByAddressTypeID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByAddressTypeID(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>36551d44e383b4fb8b95a07ec186e043</Hash>
</Codenesium>*/
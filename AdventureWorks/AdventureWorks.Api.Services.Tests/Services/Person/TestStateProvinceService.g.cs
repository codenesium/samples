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
        [Trait("Table", "StateProvince")]
        [Trait("Area", "Services")]
        public partial class StateProvinceServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var records = new List<StateProvince>();
                        records.Add(new StateProvince());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        List<ApiStateProvinceResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var record = new StateProvince();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<StateProvince>(null));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var model = new ApiStateProvinceRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StateProvince>())).Returns(Task.FromResult(new StateProvince()));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        CreateResponse<ApiStateProvinceResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<StateProvince>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var model = new ApiStateProvinceRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StateProvince>())).Returns(Task.FromResult(new StateProvince()));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<StateProvince>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var model = new ApiStateProvinceRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var record = new StateProvince();

                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.ByName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.ByName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByStateProvinceCodeCountryRegionCode_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var record = new StateProvince();

                        mock.RepositoryMock.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.ByStateProvinceCodeCountryRegionCode(default (string), default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByStateProvinceCodeCountryRegionCode_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        mock.RepositoryMock.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        ApiStateProvinceResponseModel response = await service.ByStateProvinceCodeCountryRegionCode(default (string), default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void Addresses_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        var records = new List<Address>();
                        records.Add(new Address());
                        mock.RepositoryMock.Setup(x => x.Addresses(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        List<ApiAddressResponseModel> response = await service.Addresses(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Addresses(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Addresses_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IStateProvinceRepository>();
                        mock.RepositoryMock.Setup(x => x.Addresses(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Address>>(new List<Address>()));
                        var service = new StateProvinceService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock,
                                                               mock.BOLMapperMockFactory.BOLAddressMapperMock,
                                                               mock.DALMapperMockFactory.DALAddressMapperMock);

                        List<ApiAddressResponseModel> response = await service.Addresses(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Addresses(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>740b8cbffde24b7a8903134070a5d9dc</Hash>
</Codenesium>*/
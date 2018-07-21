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
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "Services")]
        public partial class CountryRegionServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var records = new List<CountryRegion>();
                        records.Add(new CountryRegion());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        List<ApiCountryRegionResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var record = new CountryRegion();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        ApiCountryRegionResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        ApiCountryRegionResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var model = new ApiCountryRegionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRegion>())).Returns(Task.FromResult(new CountryRegion()));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        CreateResponse<ApiCountryRegionResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRegionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CountryRegion>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var model = new ApiCountryRegionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRegion>())).Returns(Task.FromResult(new CountryRegion()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CountryRegion()));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        UpdateResponse<ApiCountryRegionResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCountryRegionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CountryRegion>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var model = new ApiCountryRegionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var record = new CountryRegion();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        ApiCountryRegionResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CountryRegion>(null));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        ApiCountryRegionResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void StateProvinces_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        var records = new List<StateProvince>();
                        records.Add(new StateProvince());
                        mock.RepositoryMock.Setup(x => x.StateProvinces(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        List<ApiStateProvinceResponseModel> response = await service.StateProvinces(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.StateProvinces(default(string), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void StateProvinces_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionRepository>();
                        mock.RepositoryMock.Setup(x => x.StateProvinces(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<StateProvince>>(new List<StateProvince>()));
                        var service = new CountryRegionService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.CountryRegionModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLCountryRegionMapperMock,
                                                               mock.DALMapperMockFactory.DALCountryRegionMapperMock,
                                                               mock.BOLMapperMockFactory.BOLStateProvinceMapperMock,
                                                               mock.DALMapperMockFactory.DALStateProvinceMapperMock);

                        List<ApiStateProvinceResponseModel> response = await service.StateProvinces(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.StateProvinces(default(string), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>11771526a4de94f48824ecec3ed7de4f</Hash>
</Codenesium>*/
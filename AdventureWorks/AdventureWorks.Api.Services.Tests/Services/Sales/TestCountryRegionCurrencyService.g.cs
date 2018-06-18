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
        [Trait("Table", "CountryRegionCurrency")]
        [Trait("Area", "Services")]
        public partial class CountryRegionCurrencyServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var records = new List<CountryRegionCurrency>();
                        records.Add(new CountryRegionCurrency());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        List<ApiCountryRegionCurrencyResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var record = new CountryRegionCurrency();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        ApiCountryRegionCurrencyResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<CountryRegionCurrency>(null));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        ApiCountryRegionCurrencyResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var model = new ApiCountryRegionCurrencyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRegionCurrency>())).Returns(Task.FromResult(new CountryRegionCurrency()));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        CreateResponse<ApiCountryRegionCurrencyResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CountryRegionCurrency>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var model = new ApiCountryRegionCurrencyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CountryRegionCurrency>())).Returns(Task.FromResult(new CountryRegionCurrency()));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCountryRegionCurrencyRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CountryRegionCurrency>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var model = new ApiCountryRegionCurrencyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByCurrencyCode_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        var records = new List<CountryRegionCurrency>();
                        records.Add(new CountryRegionCurrency());
                        mock.RepositoryMock.Setup(x => x.ByCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        List<ApiCountryRegionCurrencyResponseModel> response = await service.ByCurrencyCode(default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCurrencyCode(It.IsAny<string>()));
                }

                [Fact]
                public async void ByCurrencyCode_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRegionCurrencyRepository>();
                        mock.RepositoryMock.Setup(x => x.ByCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<List<CountryRegionCurrency>>(new List<CountryRegionCurrency>()));
                        var service = new CountryRegionCurrencyService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.CountryRegionCurrencyModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLCountryRegionCurrencyMapperMock,
                                                                       mock.DALMapperMockFactory.DALCountryRegionCurrencyMapperMock);

                        List<ApiCountryRegionCurrencyResponseModel> response = await service.ByCurrencyCode(default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCurrencyCode(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>8c7bc88d43dc5d0206a96a7a332e0261</Hash>
</Codenesium>*/
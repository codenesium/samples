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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "Services")]
        public partial class CountryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var records = new List<Country>();
                        records.Add(new Country());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        List<ApiCountryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var record = new Country();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        ApiCountryResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        ApiCountryResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var model = new ApiCountryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        CreateResponse<ApiCountryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Country>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var model = new ApiCountryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Country>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var model = new ApiCountryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Provinces_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var records = new List<Province>();
                        records.Add(new Province());
                        mock.RepositoryMock.Setup(x => x.Provinces(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        List<ApiProvinceResponseModel> response = await service.Provinces(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Provinces(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Provinces_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        mock.RepositoryMock.Setup(x => x.Provinces(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Province>>(new List<Province>()));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLProvinceMapperMock,
                                                         mock.DALMapperMockFactory.DALProvinceMapperMock);

                        List<ApiProvinceResponseModel> response = await service.Provinces(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Provinces(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>57894592b5c3df7aa0a22224c7a8152e</Hash>
</Codenesium>*/
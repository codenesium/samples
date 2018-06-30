using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        ApiCountryResponseModel response = await service.Get(default(int));

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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        ApiCountryResponseModel response = await service.Get(default(int));

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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

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
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void CountryRequirements_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var records = new List<CountryRequirement>();
                        records.Add(new CountryRequirement());
                        mock.RepositoryMock.Setup(x => x.CountryRequirements(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        List<ApiCountryRequirementResponseModel> response = await service.CountryRequirements(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.CountryRequirements(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void CountryRequirements_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        mock.RepositoryMock.Setup(x => x.CountryRequirements(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CountryRequirement>>(new List<CountryRequirement>()));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        List<ApiCountryRequirementResponseModel> response = await service.CountryRequirements(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.CountryRequirements(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Destinations_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        var records = new List<Destination>();
                        records.Add(new Destination());
                        mock.RepositoryMock.Setup(x => x.Destinations(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        List<ApiDestinationResponseModel> response = await service.Destinations(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Destinations(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Destinations_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICountryRepository>();
                        mock.RepositoryMock.Setup(x => x.Destinations(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Destination>>(new List<Destination>()));
                        var service = new CountryService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLCountryMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryMapperMock,
                                                         mock.BOLMapperMockFactory.BOLCountryRequirementMapperMock,
                                                         mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
                                                         mock.BOLMapperMockFactory.BOLDestinationMapperMock,
                                                         mock.DALMapperMockFactory.DALDestinationMapperMock);

                        List<ApiDestinationResponseModel> response = await service.Destinations(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Destinations(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e4af8e6d8e6df712caa049a69955c225</Hash>
</Codenesium>*/
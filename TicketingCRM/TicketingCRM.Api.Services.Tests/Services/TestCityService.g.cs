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
        [Trait("Table", "City")]
        [Trait("Area", "Services")]
        public partial class CityServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var records = new List<City>();
                        records.Add(new City());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        List<ApiCityResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var record = new City();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        ApiCityResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<City>(null));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        ApiCityResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var model = new ApiCityRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<City>())).Returns(Task.FromResult(new City()));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        CreateResponse<ApiCityResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCityRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<City>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var model = new ApiCityRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<City>())).Returns(Task.FromResult(new City()));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<City>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var model = new ApiCityRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void GetProvinceId_Exists()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var records = new List<City>();
                        records.Add(new City());
                        mock.RepositoryMock.Setup(x => x.GetProvinceId(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        List<ApiCityResponseModel> response = await service.GetProvinceId(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProvinceId(It.IsAny<int>()));
                }

                [Fact]
                public async void GetProvinceId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        mock.RepositoryMock.Setup(x => x.GetProvinceId(It.IsAny<int>())).Returns(Task.FromResult<List<City>>(new List<City>()));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        List<ApiCityResponseModel> response = await service.GetProvinceId(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProvinceId(It.IsAny<int>()));
                }

                [Fact]
                public async void Events_Exists()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        var records = new List<Event>();
                        records.Add(new Event());
                        mock.RepositoryMock.Setup(x => x.Events(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        List<ApiEventResponseModel> response = await service.Events(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Events(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Events_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICityRepository>();
                        mock.RepositoryMock.Setup(x => x.Events(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
                        var service = new CityService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLCityMapperMock,
                                                      mock.DALMapperMockFactory.DALCityMapperMock,
                                                      mock.BOLMapperMockFactory.BOLEventMapperMock,
                                                      mock.DALMapperMockFactory.DALEventMapperMock);

                        List<ApiEventResponseModel> response = await service.Events(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Events(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>8d0a57b87550a219eb911caa8ac9b84f</Hash>
</Codenesium>*/